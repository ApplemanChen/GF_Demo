using System.Net;
using GameFramework;
using GameFramework.Network;
using UnityGameFramework.Runtime;

public static class NetworkExtension
{
    /// <summary>
    /// 游戏服ip
    /// 从ServerConfig中读取
    /// </summary>
    public static string GameServerIP
    {
        get;
        set;
    }

    /// <summary>
    /// 游戏服端口
    /// 从ServerConfig中读取
    /// </summary>
    public static int GameServerPort
    {
        get;
        set;
    }

    /// <summary>
    /// 游戏网络频道
    /// </summary>
    public static INetworkChannel  GameChannel
    {
        get;
        set;
    }

    /// <summary>
    /// 创建网络频道
    /// </summary>
    /// <param name="networkComponent"></param>
    /// <param name="channelName"></param>
    public static void CreateNetworkChannel(this NetworkComponent networkComponent,string channelName)
    {
        NetworkChannelHelper helper = new NetworkChannelHelper();
        NetworkExtension.GameChannel = networkComponent.CreateNetworkChannel(channelName,helper);
    }

    /// <summary>
    /// 连接游戏服
    /// </summary>
    /// <param name="networkComponent"></param>
    public static void ConnectGameChannel(this NetworkComponent networkComponent)
    {
        if(NetworkExtension.GameChannel != null)
        {
            NetworkExtension.GameChannel.Connect(IPAddress.Parse(NetworkExtension.GameServerIP), NetworkExtension.GameServerPort);
        }else
        {
            Log.Error("Please 'CreateNetworkChannel' first !!");
        }
    }

    /// <summary>
    /// 发游戏消息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="networkComponent"></param>
    /// <param name="packet"></param>
    public static void Send<T>(this NetworkComponent networkComponent,T packet) where T:CSPacketBase
    {
        if (NetworkExtension.GameChannel!= null)
        {
            NetworkExtension.GameChannel.Send<T>(packet);
        }else
        {
            Log.Error("Please 'CreateNetworkChannel' first !!");
        }
    }
}