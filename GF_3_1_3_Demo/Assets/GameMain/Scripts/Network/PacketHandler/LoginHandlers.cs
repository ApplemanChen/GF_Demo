//登录模块消息处理集合
using GameFramework;
using GameFramework.Network;
using network;

public class SCLoginPacketHandler : PacketHandlerBase
{
    public override int Id
    {
        get { return (int)PacketId.SC_LOGIN; }
    }
    public override void Handle(object sender, Packet packet)
    {
        Log.Info("客户端收到登录返回消息！！！");
        sc_login info = (sc_login)packet;
        Log.Info("Receive.result:" + info.result);
    }
}