﻿//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Localization;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using UnityEngine;

/// <summary>
/// 启动流程
/// </summary>
public class ProcedureLaunch:GameProcedureBase
{
    private string[] _configs = new string[] { "BuildConfig", "ServerConfig" };
    private List<string> _loadedConfigList = new List<string>();

    private bool _isConfigInitComplete = false;
    private bool _isLanguageInitComplete = false;
    private bool _isQualityInitComplete = false;
    private bool _isSoundInitComplete = false;

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        _isConfigInitComplete = false;
        _isLanguageInitComplete = false;
        _isQualityInitComplete = false;
        _isSoundInitComplete = false;

        SubscribeEvents();

        //游戏基础配置信息：把一些数据以 Json 的格式写入 Config.txt，供游戏逻辑读取。
        InitBaseConfig();
        //语言配置初始化
        InitLanguageSetting();
        //画质配置初始化：
        InitQualitySetting();
        //声音配置初始化
        InitSoundSetting();
        //TODO:其他初始化工作
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if(_isConfigInitComplete && _isLanguageInitComplete && _isQualityInitComplete && _isSoundInitComplete)
        {
            ChangeState<ProcedureSplash>(procedureOwner);
        }
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
            GameManager.Config.LoadConfig(_configs[i], AssetUtility.GetBaseConfigAsset(_configs[i]));
        }
    }

    /// <summary>
    /// 初始化语言配置
    /// </summary>
    private void InitLanguageSetting()
    {
        if(GameManager.Base.EditorResourceMode && GameManager.Base.EditorLanguage != Language.Unspecified)
        {
            //编辑器模式下用已指定的语言
            return;
        }

        Language language = GameManager.Localization.Language;
        string languageSetting = GameManager.Setting.GetString(Const.SettingKey.Language);
        if(!string.IsNullOrEmpty(languageSetting))
        {
            try
            {
                language = (Language)Enum.Parse(typeof(Language), languageSetting);
            }catch
            {
                Log.Error("Localization saved language can't convert to enum value.The string is {0}.",languageSetting);
            }
        }

        if (language != Language.English
            && language != Language.ChineseSimplified)
        {
            // 若是暂不支持的语言，则使用英语
            language = Language.English;

            GameManager.Setting.SetString(Const.SettingKey.Language, language.ToString());
            GameManager.Setting.Save();
        }

        GameManager.Localization.Language = language;

        _isLanguageInitComplete = true;
        Log.Info("PrecedureLaunch ==> Language setting init complete!");
    }

    /// <summary>
    /// 初始化画质配置
    /// </summary>
    public void InitQualitySetting()
    {
        //此处可拓展为根据不同机型模型进行画质配置，根据检测到的硬件信息 Assets/Main/Configs/DeviceModelConfig 和用户配置数据，设置即将使用的画质选项。
        QualityLevel defaultQuality = QualityLevel.Good;
        int settingQuality = GameManager.Setting.GetInt(Const.SettingKey.Quality, (int)defaultQuality);
        QualitySettings.SetQualityLevel(settingQuality);

        _isQualityInitComplete = true;
        Log.Info("PrecedureLaunch ==> Quality setting init complete!");
    }

    /// <summary>
    /// 初始化声音设置
    /// </summary>
    public void InitSoundSetting()
    {
        GameManager.Sound.SetMute("Music", GameManager.Setting.GetBool(Const.SettingKey.MusicMuted, false));
        GameManager.Sound.SetMute("Sound", GameManager.Setting.GetBool(Const.SettingKey.SoundMuted, false));
        GameManager.Sound.SetMute("UISound", GameManager.Setting.GetBool(Const.SettingKey.UISoundMuted, false));
        GameManager.Sound.SetVolume("Music", GameManager.Setting.GetFloat(Const.SettingKey.MusicVolume,0.3f));
        GameManager.Sound.SetVolume("Sound", GameManager.Setting.GetFloat(Const.SettingKey.SoundVolume,1f));
        GameManager.Sound.SetVolume("UISound", GameManager.Setting.GetFloat(Const.SettingKey.UISoundVolume,1f));

        _isSoundInitComplete = true;
        Log.Info("PrecedureLaunch ==> Sound setting init complete!");
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
            Log.Info("PrecedureLaunch ==> Base config init complete!");
        }
    }
}