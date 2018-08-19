//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Event;
using UnityGameFramework.Runtime;

/// <summary>
/// 主城流程
/// </summary>
public class ProcedureCity : GameProcedureBase
{
    private CityScene m_Scene;


    protected override void OnInit(ProcedureOwner procedureOwner)
    {
        base.OnInit(procedureOwner);


    }

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        int sceneId = procedureOwner.GetData<VarInt>(Const.ProcedureDataKey.NextSceneId).Value;
        m_Scene = new CityScene(sceneId);
        m_Scene.Enter();

        //GameManager.UI.OpenUIForm(UIFormId.MenuForm);
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if(m_Scene != null)
        {
            m_Scene.Update(elapseSeconds,realElapseSeconds);
        }
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        m_Scene.Exit();
        m_Scene = null;

        base.OnLeave(procedureOwner, isShutdown);
    }
}
