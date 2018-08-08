//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using UnityEngine;
using GameFramework;
using System.Collections.Generic;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Event;
using GameFramework.DataTable;

/// <summary>
/// 加载Lua流程
/// </summary>
public class ProcedureLoadLua : GameProcedureBase
{
    private List<LuaFileInfo> m_LuaFileInfos = LuaFilesConfig.FilesConfigList;
    private Dictionary<string, bool> m_loadedFlag = new Dictionary<string, bool>();

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        UpdateLaunchTips("正在加载Lua资源...");

        GameManager.Event.Subscribe(LoadLuaSuccessEventArgs.EventId, OnLoadLuaSuccess);

        for (int i = 0; i < m_LuaFileInfos.Count;i++ )
        {
            m_loadedFlag.Add(m_LuaFileInfos[i].LuaName,false);
            GameManager.Lua.LoadLuaFile(m_LuaFileInfos[i].LuaName,m_LuaFileInfos[i].AssetName);
        }
    }


    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        
        foreach(var item in m_loadedFlag)
        {
            if(item.Value == false)
            {
                return;
            }
        }

        UpdateLaunchTips("资源预加载完成。");

        GameManager.Lua.DoLuaFile("main");
        GameManager.Lua.DoLuaFile("Manager/LuaFormManager");

        ChangeState<ProcedureMenu>(procedureOwner);
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        GameManager.Event.Unsubscribe(LoadLuaSuccessEventArgs.EventId, OnLoadLuaSuccess);

        GameManager.UI.CloseUIForm(UIFormId.LaunchForm);

        base.OnLeave(procedureOwner, isShutdown);
    }

    private void OnLoadLuaSuccess(object sender, GameEventArgs e)
    {
        LoadLuaSuccessEventArgs evt = (LoadLuaSuccessEventArgs)e;

        m_loadedFlag[evt.LuaName] = true;
    }

    private void UpdateLaunchTips(string tips)
    {
        GameManager.Event.Fire(this, ReferencePool.Acquire<LaunchFormUpdateTipsEventArgs>().Fill(tips));
    }
}