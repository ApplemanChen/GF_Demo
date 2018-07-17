//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework;
using GameFramework.Network;
using ProtoBuf;
using System.Net;
using System.IO;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Event;
using System;
using network;

public class ProcedurePreload : GameProcedureBase
{
    private INetworkChannel channel;

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        TestProto();
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

    }

    private void TestProto()
    {
        NetworkChannelHelper helper = new NetworkChannelHelper();
        channel = GameManager.Network.CreateNetworkChannel(Const.ServerConfigKey.GameServerIP,helper);
        channel.Connect(IPAddress.Parse(NetworkExtension.GameServerIP),NetworkExtension.GameServerPort);

        GameManager.Event.Subscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId,OnNetworkConneted);
    }

    private void OnNetworkConneted(object sender, GameEventArgs e)
    {
        Log.Info("连接上服务器~~~");

        cs_login loginInfo = new cs_login();
        loginInfo.account = "1234";
        loginInfo.password = "abc";
        channel.Send<cs_login>(loginInfo);
    }
}
