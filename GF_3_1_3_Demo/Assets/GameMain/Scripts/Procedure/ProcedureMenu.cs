//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Event;
using UnityGameFramework.Runtime;

/// <summary>
/// 主菜单流程
/// </summary>
public class ProcedureMenu : GameProcedureBase
{
    private bool m_IsEnterScene;

    /// <summary>
    /// 是否切换场景
    /// </summary>
    public bool IsEnterScene
    {
        get { return m_IsEnterScene; }
        set { m_IsEnterScene = value; }
    }

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        m_IsEnterScene = false;
        GameManager.UI.OpenUIForm(UIFormId.LoginForm);
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        
        if(m_IsEnterScene)
        {
            GameManager.UI.CloseUIForm(UIFormId.LoginForm);

            procedureOwner.SetData<VarInt>(Const.ProcedureDataKey.NextSceneId,(int)SceneId.MainScene);
            ChangeState<ProcedureChangeScene>(procedureOwner);
        }
    }
}