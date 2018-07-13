using GameFramework.Network;

/// <summary>
/// 消息处理基类
/// </summary>
public abstract class PacketHandlerBase : IPacketHandler
{
    public abstract int Id
    {
        get;
    }

    public abstract void Handle(object sender, Packet packet);
}
