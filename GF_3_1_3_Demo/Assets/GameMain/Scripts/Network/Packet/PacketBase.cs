using GameFramework;
using GameFramework.Network;
using ProtoBuf;
using System;

/// <summary>
/// 消息包基类
/// </summary>
public abstract class PacketBase : Packet,IExtensible
{
    private IExtension m_ExtensionObject;

    public PacketBase()
    {
        m_ExtensionObject = null;
    }

    public abstract PacketType PacketType
    {
        get;
    }

    /// <summary>
    /// 获取拓展对象
    /// </summary>
    /// <param name="createIfMissing"></param>
    /// <returns></returns>
    public IExtension GetExtensionObject(bool createIfMissing)
    {
        return Extensible.GetExtensionObject(ref m_ExtensionObject,createIfMissing);
    }

    public override int Id
    {
        get 
        {
            string className = this.GetType().Name.ToUpper();
            int id = (int)Enum.Parse(typeof(PacketId),className);
            return id;
        }
    }

}