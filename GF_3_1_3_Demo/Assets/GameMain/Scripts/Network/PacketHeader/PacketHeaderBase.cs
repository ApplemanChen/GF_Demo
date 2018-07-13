using GameFramework;
using GameFramework.Network;
using ProtoBuf;
using System;

/// <summary>
/// 消息包头基类
/// </summary>
public abstract class PacketHeaderBase : IPacketHeader , IReference
{

    public abstract PacketType PacketType
    {
        get;
    }

    /// <summary>
    /// 消息id
    /// </summary>
    public abstract int Id
    {
        get;
        set;
    }

    /// <summary>
    /// 消息包长度
    /// </summary>
    public abstract int PacketLength
    {
        set;
        get;
    }

    /// <summary>
    /// 消息是否合法
    /// </summary>
    /// <returns></returns>
    public bool IsValid()
    {
        return PacketType != PacketType.Undefined && Id > 0 && PacketLength > 0;
    }

    /// <summary>
    /// 清理
    /// </summary>
    public void Clear()
    {
        Id = 0;
        PacketLength = 0;
    }
}