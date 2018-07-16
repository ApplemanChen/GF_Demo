//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;
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
        Log.Info("Receive.result:"+info.result);
    }
}