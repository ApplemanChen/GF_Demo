using System;
using System.Reflection;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Network;
using System.IO;
using ProtoBuf;
using ProtoBuf.Meta;

/// <summary>
/// 网络频道辅助器
/// </summary>
public class NetworkChannelHelper : GameFramework.Network.INetworkChannelHelper
{
    private Dictionary<int, Type> m_ServerToClientPacketTypes = new Dictionary<int, Type>();
    private INetworkChannel m_NetworkChannel;

    public NetworkChannelHelper()
    {

    }

    /// <summary>
    /// 初始化网络频道辅助器
    /// </summary>
    /// <param name="networkChannel"></param>
    public void Initialize(INetworkChannel networkChannel)
    {
        m_NetworkChannel = networkChannel;

        //反射查找类型，注册消息包和处理函数
        Type packetBaseType = typeof(SCPacketBase);
        Type packetHandlerBaseType = typeof(PacketHandlerBase);
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type[] types = assembly.GetTypes();
        int len = types.Length;
        for (int i = 0; i < len;i++ )
        {
            if(!types[i].IsClass || types[i].IsAbstract)
            {
                continue;
            }

            if(types[i].BaseType == packetBaseType)
            {
                //注册消息包
                SCPacketBase packetBase = (SCPacketBase)Activator.CreateInstance(types[i]);
                Type packetType = GetServerToClientPacketType(packetBase.Id);
                if(packetType != null)
                {
                    Log.Warning("Already exist packet type '{0}', check '{1}' or '{2}'?.", packetBase.Id.ToString(), packetType.Name, packetBase.GetType().Name);
                    continue;
                }else
                {
                    m_ServerToClientPacketTypes.Add(packetBase.Id, types[i]);
                }
            }else if(types[i].BaseType == packetHandlerBaseType)
            {
                //注册消息处理
                IPacketHandler handler = (IPacketHandler)Activator.CreateInstance(types[i]);
                m_NetworkChannel.RegisterHandler(handler);
            }
        }

        GameManager.Event.Subscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId,OnNetworkConnected);
        GameManager.Event.Subscribe(UnityGameFramework.Runtime.NetworkClosedEventArgs.EventId, OnNetworkClosed);
        GameManager.Event.Subscribe(UnityGameFramework.Runtime.NetworkErrorEventArgs.EventId, OnNetworkError);
        GameManager.Event.Subscribe(UnityGameFramework.Runtime.NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);
        GameManager.Event.Subscribe(UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);
    }

    private Type GetServerToClientPacketType(int id)
    {
        Type packetType = null;
        if(m_ServerToClientPacketTypes.TryGetValue(id,out packetType))
        {
            return packetType;
        }

        return null;
    }

    /// <summary>
    /// **GF程序集内部执行
    /// 反序列化消息包头
    /// </summary>
    /// <param name="source"></param>
    /// <param name="customErrorData"></param>
    /// <returns></returns>
    public IPacketHeader DeserializePacketHeader(Stream source, out object customErrorData)
    {
        // 注意：此函数并不在主线程调用！
        customErrorData = null;
        return Serializer.DeserializeWithLengthPrefix<SCPacketHeader>(source, PrefixStyle.Fixed32);
        //return (IPacketHeader)RuntimeTypeModel.Default.Deserialize(source, ReferencePool.Acquire<SCPacketHeader>(), typeof(SCPacketHeader));
    }

    /// <summary>
    /// **GF程序集内部执行
    /// 反序列化消息包
    /// </summary>
    /// <param name="packetHeader"></param>
    /// <param name="source"></param>
    /// <param name="customErrorData"></param>
    /// <returns></returns>
    public Packet DeserializePacket(IPacketHeader packetHeader, Stream source, out object customErrorData)
    {
        // 注意：此函数并不在主线程调用！
        customErrorData = null;
        
        SCPacketHeader packetHeaderImpl = packetHeader as SCPacketHeader;

        if(packetHeaderImpl == null)
        {
            Log.Warning("Packet header is null.");
            return null;
        }

        Packet packet = null;
        if(packetHeaderImpl.IsValid())
        {
            Type packetType = GetServerToClientPacketType(packetHeaderImpl.Id);

            if(packetType != null)
            {
                packet = (Packet)RuntimeTypeModel.Default.DeserializeWithLengthPrefix(source, ReferencePool.Acquire(packetType), packetType, PrefixStyle.Fixed32, 0);
            }else
            {
                Log.Warning("Can't deserialize packet id '{0}'.",packetHeaderImpl.Id);
            }

        }else
        {
            Log.Warning("Packet header is invalid. Id : {0}",packetHeaderImpl.Id);
        }

        return packet;
    }

    /// <summary>
    /// 序列化消息包
    /// </summary>
    /// <typeparam name="T">消息包类型</typeparam>
    /// <param name="packet">消息包对象</param>
    /// <returns></returns>
    public byte[] Serialize<T>(T packet) where T : Packet
    {
        PacketBase packetImpl = packet as PacketBase;

        if (packetImpl == null)
        {
            Log.Warning("Packet is null.");
            return null;
        }

        if (packetImpl.PacketType != PacketType.ClientToServer)
        {
            Log.Warning("Packet type is invalid.");
            return null;
        }

        // 恐怖的 GCAlloc，这里是例子，不做优化
        using (MemoryStream stream = new MemoryStream())
        {
            //跳过消息头长度（8）的位置开始序列化消息内容
            stream.Position = PacketHeaderLength;
            Serializer.SerializeWithLengthPrefix<T>(stream, packet, PrefixStyle.Fixed32);

            //回头再来序列化消息包头
            stream.Position = 0;
            CSPacketHeader header = ReferencePool.Acquire<CSPacketHeader>();
            header.Id = packet.Id;
            header.PacketLength = (int)stream.Length - PacketHeaderLength;
            Serializer.SerializeWithLengthPrefix(stream, header, PrefixStyle.Fixed32);
            ReferencePool.Release<CSPacketHeader>(header);

            //测试服务器下发的数据
            //stream.Position = 0;
            //SCPacketHeader header = ReferencePool.Acquire<SCPacketHeader>();
            //header.Id = packet.Id;
            //header.PacketLength = (int)stream.Length - PacketHeaderLength;
            //Serializer.SerializeWithLengthPrefix(stream, header, PrefixStyle.Fixed32);
            //ReferencePool.Release<SCPacketHeader>(header);

            return stream.ToArray();
        }
    }

    /// <summary>
    /// 消息包头长度（字节数）
    /// </summary>
    public int PacketHeaderLength
    {
        get 
        {
            //消息长度（int）+ 消息id（int）  = 8
            return sizeof(int) + sizeof(int);
        }
    }

    /// <summary>
    /// 发送心跳包
    /// </summary>
    /// <returns></returns>
    public bool SendHeartBeat()
    {
        m_NetworkChannel.Send<CSHeartBeat>(ReferencePool.Acquire<CSHeartBeat>());
        return true;
    }

    /// <summary>
    /// 关闭并清理网络频道辅助器
    /// </summary>
    public void Shutdown()
    {
        GameManager.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
        GameManager.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkClosedEventArgs.EventId, OnNetworkClosed);
        GameManager.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkErrorEventArgs.EventId, OnNetworkError);
        GameManager.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);
        GameManager.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);

        m_ServerToClientPacketTypes.Clear();
        m_NetworkChannel = null;
    }

    private void OnNetworkMissHeartBeat(object sender, GameFramework.Event.GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs ne = (UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs)e;
        if(ne.NetworkChannel != m_NetworkChannel)
        {
            return;
        }

        if(ne.MissCount > 2)
        {
            ne.NetworkChannel.Close();
        }
    }

    private void OnNetworkCustomError(object sender, GameFramework.Event.GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkCustomErrorEventArgs ne = (UnityGameFramework.Runtime.NetworkCustomErrorEventArgs)e;
        if(ne.NetworkChannel != m_NetworkChannel)
        {
            return;
        }

        if(ne.CustomErrorData != null)
        {
            Log.Error("Network Packet {0} CustomError : {1}.", ne.Id, ne.CustomErrorData);
        }
    }

    private void OnNetworkError(object sender, GameFramework.Event.GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkErrorEventArgs ne = (UnityGameFramework.Runtime.NetworkErrorEventArgs)e;
        if(ne.NetworkChannel != m_NetworkChannel)
        {
            return;
        }

        Log.Error("Network Packet {0} Error : {1}.",ne.Id,ne.ErrorMessage);
    }

    private void OnNetworkClosed(object sender, GameFramework.Event.GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkClosedEventArgs ne = (UnityGameFramework.Runtime.NetworkClosedEventArgs)e;
        if(ne.NetworkChannel != m_NetworkChannel)
        {
            return;
        }

        Log.Error("NetworkChannel {0} is closed.", ne.NetworkChannel.Name);
    }

    private void OnNetworkConnected(object sender, GameFramework.Event.GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkConnectedEventArgs ne = (UnityGameFramework.Runtime.NetworkConnectedEventArgs)e;
        if(ne.NetworkChannel != m_NetworkChannel)
        {
            return;
        }

        Log.Info("NetworkChannel {0} is connected. IP: {1}",ne.NetworkChannel.Name,ne.NetworkChannel.RemoteIPAddress.ToString());
    }
}