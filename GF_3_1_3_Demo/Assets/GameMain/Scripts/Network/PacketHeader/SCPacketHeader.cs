using System;
using ProtoBuf;

[Serializable, ProtoContract(Name = @"SCPacketHeader")]
public sealed class SCPacketHeader : PacketHeaderBase
{
    public override PacketType PacketType
    {
        get 
        {
            return PacketType.ServerToClient;
        }
    }

    //必须要加这个特性，否则Proto解析不了该属性
    /// <summary>
    /// 消息id
    /// </summary>
    [ProtoMember(1)]
    public override int Id
    {
        get;
        set;
    }

    /// <summary>
    /// 消息长度
    /// </summary>
    [ProtoMember(2)]
    public override int PacketLength
    {
        get;
        set;
    }
}
