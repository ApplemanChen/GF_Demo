//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using UnityGameFramework.Runtime;
using GameFramework;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using UnityEngine;

/// <summary>
/// 资源更新流程
/// </summary>
public class ProcedureUpdateResource : GameProcedureBase
{
    private bool m_IsUpdateAllComplete = false;

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        m_IsUpdateAllComplete = false;
        GameManager.Event.Subscribe(ResourceCheckCompleteEventArgs.EventId,OnResourceCheckComplete);
        GameManager.Event.Subscribe(ResourceUpdateSuccessEventArgs.EventId,OnResourceUpdateSuccess);
        GameManager.Event.Subscribe(ResourceUpdateAllCompleteEventArgs.EventId,OnResourceUpdateAllComplete);

        GameManager.Resource.CheckResources();
    }


    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if(m_IsUpdateAllComplete)
        {
            Log.Info("更新后，最新当前资源适用游戏版本: ApplicableGameVersion : {0}.", GameManager.Resource.ApplicableGameVersion);
            Log.Info("更新后，最新内部资源版本号: {0}.", GameManager.Resource.InternalResourceVersion);
            ChangeState<ProcedurePreload>(procedureOwner);
        }
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        GameManager.Event.Unsubscribe(ResourceCheckCompleteEventArgs.EventId, OnResourceCheckComplete);
        GameManager.Event.Unsubscribe(ResourceUpdateSuccessEventArgs.EventId, OnResourceUpdateSuccess);
        GameManager.Event.Unsubscribe(ResourceUpdateAllCompleteEventArgs.EventId, OnResourceUpdateAllComplete);

        base.OnLeave(procedureOwner, isShutdown);
    }

    private void OnResourceCheckComplete(object sender, GameFramework.Event.GameEventArgs e)
    {
        ResourceCheckCompleteEventArgs evt = (ResourceCheckCompleteEventArgs)e;
        int updateCount = evt.UpdateCount;
        if (updateCount <= 0)
        {
            Log.Info("无需更新资源。");
            m_IsUpdateAllComplete = true;
            return;
        }

        Log.Info("需要更新的资源有{0}个。", updateCount);
        //更新资源
        GameManager.Resource.UpdateResources();
    }

    private void OnResourceUpdateSuccess(object sender, GameFramework.Event.GameEventArgs e)
    {
        ResourceUpdateSuccessEventArgs evt = (ResourceUpdateSuccessEventArgs)e;

        Log.Info("更新文件{0}完成！资源大小:{1}", evt.Name, evt.Length);
    }

    private void OnResourceUpdateAllComplete(object sender, GameFramework.Event.GameEventArgs e)
    {
        Log.Info("所有资源更新完毕！");
        m_IsUpdateAllComplete = true;
    }
}
