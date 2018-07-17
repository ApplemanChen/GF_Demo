//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using GameFramework;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

/// <summary>
/// 启动流程
/// </summary>
public class ProcedureLaunch:GameProcedureBase
{
    private string[] _configs = new string[] { "BuildConfig", "ServerConfig" };
    private List<string> _loadedConfigList = new List<string>();

    private bool _isConfigInitComplete = false;

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        SubscribeEvents();

        //游戏基础配置信息：把一些数据以 Json 的格式写入 Config.txt，供游戏逻辑读取。
        InitBaseConfig();
        //TODO:语言配置初始化
        InitLanguageSetting();
        //TODO:声音配置初始化
        //TODO:画质配置初始化：根据检测到的硬件信息 Assets/Main/Configs/DeviceModelConfig 和用户配置数据，设置即将使用的画质选项。
        //TODO:其他初始化工作
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);


    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        UnsubscribEvents();

        base.OnLeave(procedureOwner, isShutdown);
    }

    private void SubscribeEvents()
    {
        GameManager.Event.Subscribe(UnityGameFramework.Runtime.LoadConfigSuccessEventArgs.EventId,OnLoadConfigSuccess);
    }

    private void UnsubscribEvents()
    {
        GameManager.Event.Unsubscribe(UnityGameFramework.Runtime.LoadConfigSuccessEventArgs.EventId, OnLoadConfigSuccess);
    }

    /// <summary>
    /// 初始化基础配置
    /// </summary>
    private void InitBaseConfig()
    {
        for (int i = 0; i < _configs.Length;i++ )
        {
            GameManager.Config.LoadConfig(_configs[i], AssetUtility.GetBuildConfigAsset(_configs[i]));
        }
    }

    /// <summary>
    /// 初始化语言配置
    /// </summary>
    private void InitLanguageSetting()
    {

    }

    private void OnLoadConfigSuccess(object sender, GameFramework.Event.GameEventArgs e)
    {
        LoadConfigSuccessEventArgs evt = (LoadConfigSuccessEventArgs)e;
        if(!_loadedConfigList.Contains(evt.ConfigName))
        {
            _loadedConfigList.Add(evt.ConfigName);
        }

        //配置加载完成，给程序内部字段赋值
        if(_loadedConfigList.Count == _configs.Length)
        {
            GameManager.Base.GameVersion = GameManager.Config.GetString(Const.BuildConfigKey.GameVersion);
            GameManager.Base.InternalApplicationVersion = GameManager.Config.GetInt(Const.BuildConfigKey.InternalVersion);
            NetworkExtension.GameServerIP = GameManager.Config.GetString(Const.ServerConfigKey.GameServerIP);
            NetworkExtension.GameServerPort = GameManager.Config.GetInt(Const.ServerConfigKey.GameServerPort);

            _isConfigInitComplete = true;
            Log.Info("PrecedureLaunch ==> Base config init Complete!");
        }
    }
}