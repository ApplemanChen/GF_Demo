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
using System;

/// <summary>
/// 加载Lua流程
/// </summary>
public class ProcedureLoadLua : GameProcedureBase
{
    private List<LuaFileInfo> m_LuaFileInfos = new List<LuaFileInfo>();
    private Dictionary<string, bool> m_loadedFlag = new Dictionary<string, bool>();
    private bool m_IsLoadedFilesConfig = false;

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        UpdateLaunchTips("正在加载Lua资源...");

        AddEvent();

        m_IsLoadedFilesConfig = false;
        GameManager.Lua.LoadLuaFilesConfig();
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (!m_IsLoadedFilesConfig)
            return;

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
        RemoveEvent();

        GameManager.UI.CloseUIForm(UIFormId.LaunchForm);

        base.OnLeave(procedureOwner, isShutdown);
    }

    private void OnLoadLuaFilesConfgSuccess(object sender, GameEventArgs e)
    {
        LoadLuaFilesConfigSuccessEventArgs evt = (LoadLuaFilesConfigSuccessEventArgs)e;

        //解析lua文件列表
        ParseLuaFilesConfig(evt.Content);

        //开始加载lua文件
        StartLoadLua();

        m_IsLoadedFilesConfig = true;
    }

    private void OnLoadLuaSuccess(object sender, GameEventArgs e)
    {
        LoadLuaSuccessEventArgs evt = (LoadLuaSuccessEventArgs)e;

        m_loadedFlag[evt.LuaName] = true;
    }

    private void ParseLuaFilesConfig(string content)
    {
        m_LuaFileInfos.Clear();
        string[] contentLines = content.Split('\n');
        int len = contentLines.Length;
        for (int i = 0; i < len; i++)
        {
            if (!string.IsNullOrEmpty(contentLines[i]))
            {
                LuaFileInfo info = GameUtility.DeserializeObject<LuaFileInfo>(contentLines[i]);
                m_LuaFileInfos.Add(info);
            }
        }

        Log.Info("m_LuaFileInfos.Count:"+m_LuaFileInfos.Count);
    }

    private void StartLoadLua()
    {
        for (int i = 0; i < m_LuaFileInfos.Count; i++)
        {
            m_loadedFlag.Add(m_LuaFileInfos[i].LuaName, false);
            GameManager.Lua.LoadLuaFile(m_LuaFileInfos[i].LuaName, m_LuaFileInfos[i].AssetName);
        }
    }

    private void AddEvent()
    {
        GameManager.Event.Subscribe(LoadLuaSuccessEventArgs.EventId, OnLoadLuaSuccess);
        GameManager.Event.Subscribe(LoadLuaFilesConfigSuccessEventArgs.EventId, OnLoadLuaFilesConfgSuccess);
    }

    private void RemoveEvent()
    {
        GameManager.Event.Unsubscribe(LoadLuaSuccessEventArgs.EventId, OnLoadLuaSuccess);
        GameManager.Event.Unsubscribe(LoadLuaFilesConfigSuccessEventArgs.EventId, OnLoadLuaFilesConfgSuccess);
    }

    private void UpdateLaunchTips(string tips)
    {
        GameManager.Event.Fire(this, ReferencePool.Acquire<LaunchFormUpdateTipsEventArgs>().Fill(tips));
    }
}