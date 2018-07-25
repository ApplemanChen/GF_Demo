//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework;
using System.Collections.Generic;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Event;

/// <summary>
/// 加载Lua流程
/// </summary>
public class ProcedureLoadLua : GameProcedureBase
{
    private List<LuaFileInfo> m_LuaFileInfos = new List<LuaFileInfo>();
    private string LuaRootPath = "Assets/XLua/Resources/";
    private Dictionary<string, bool> m_loadedFlag = new Dictionary<string, bool>();

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        GameManager.Event.Subscribe(LoadLuaSuccessEventArgs.EventId, OnLoadLuaSuccess);

        m_LuaFileInfos.Add(new LuaFileInfo("main"));

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

        GameManager.Lua.DoLuaFile("main");

        ChangeState<ProcedureMenu>(procedureOwner);
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        GameManager.Event.Unsubscribe(LoadLuaSuccessEventArgs.EventId, OnLoadLuaSuccess);        

        base.OnLeave(procedureOwner, isShutdown);
    }

    private void OnLoadLuaSuccess(object sender, GameEventArgs e)
    {
        LoadLuaSuccessEventArgs evt = (LoadLuaSuccessEventArgs)e;

        m_loadedFlag[evt.LuaName] = true;
    }
}