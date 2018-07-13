using System;
using ProtoBuf;

[Serializable, ProtoContract(Name = @"CSHeartBeat")]
public class CSHeartBeat : CSPacketBase
{
    public override int Id
    {
        get 
        { 
            return 1; 
        }
    }

    [ProtoMember(1)]
    public int Pos
    {
        set;
        get;
    }

    public override void Clear()
    {

    }

}
