//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Resource;
using GameFramework.Localization;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using UnityEngine;

/// <summary>
/// 启动流程
/// 打开LaunchForm -> 初始化配置
/// </summary>
public class ProcedureLaunch:GameProcedureBase
{
    private bool _isLanguageInitComplete = false;
    private bool _isQualityInitComplete = false;
    private bool _isSoundInitComplete = false;

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        _isLanguageInitComplete = false;
        _isQualityInitComplete = false;
        _isSoundInitComplete = false;

        SubscribeEvents();

        //单机模式下（非编辑器模式）需要初始化资源
        if(!GameManager.Base.EditorResourceMode && GameManager.Resource.ResourceMode == ResourceMode.Package)
        {
            GameManager.Resource.InitResources();
        }else
        {
            OpenLaunchForm();
        }
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if( _isLanguageInitComplete && _isQualityInitComplete && _isSoundInitComplete)
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
        GameManager.Event.Subscribe(UnityGameFramework.Runtime.ResourceInitCompleteEventArgs.EventId,OnResourceInitComplete);
        GameManager.Event.Subscribe(UnityGameFramework.Runtime.OpenUIFormSuccessEventArgs.EventId,OnOpenLaunchFormSuccess);
    }

    private void OnOpenLaunchFormSuccess(object sender, GameFramework.Event.GameEventArgs e)
    {
        InitAll();
    }

    private void UnsubscribEvents()
    {
        GameManager.Event.Unsubscribe(UnityGameFramework.Runtime.ResourceInitCompleteEventArgs.EventId, OnResourceInitComplete);
        GameManager.Event.Unsubscribe(UnityGameFramework.Runtime.OpenUIFormSuccessEventArgs.EventId, OnOpenLaunchFormSuccess);
    }

    private void OnResourceInitComplete(object sender, GameFramework.Event.GameEventArgs e)
    {
        OpenLaunchForm();
    }

    private void OpenLaunchForm()
    {
        //由于启动界面打开时，界面配置还未加载完成，所以必须用这种方法打开，否则会报错！
        GameManager.UI.OpenUIForm(AssetUtility.GetUIFormAsset(UIFormId.LaunchForm.ToString()), "UI");
    }

    private void InitAll()
    {
        //基础配置
        InitBaseConfig();
        //语言配置初始化
        InitLanguageSetting();
        //画质配置初始化：
        InitQualitySetting();
        //声音配置初始化
        InitSoundSetting();
        //TODO:其他初始化工作
    }

    private void UpdateLaunchTips(string tips)
    {
        GameManager.Event.Fire(this, ReferencePool.Acquire<LaunchFormUpdateTipsEventArgs>().Fill(tips));
    }

    /// <summary>
    /// 初始化基础配置
    /// </summary>
    private void InitBaseConfig()
    {
        UpdateLaunchTips("正在进行基础配置...");
        GameManager.BaseConfig.InitBuildConfig();
        GameManager.BaseConfig.InitServerConfig();
        Log.Info("Launch => Base config init complete.");
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
        UpdateLaunchTips("语言配置完成！");
        Log.Info("Launch => Language init complete.");
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
        UpdateLaunchTips("画质配置完成！");
        Log.Info("Launch => Quality init complete.");
    }

    /// <summary>
    /// 初始化声音设置
    /// </summary>
    public void InitSoundSetting()
    {
        GameManager.Sound.AddSoundGroup("Music", 1);
        GameManager.Sound.AddSoundGroup("Sound",10);
        GameManager.Sound.AddSoundGroup("UISound",5);

        GameManager.Sound.SetMute("Music", GameManager.Setting.GetBool(Const.SettingKey.MusicMuted, false));
        GameManager.Sound.SetMute("Sound", GameManager.Setting.GetBool(Const.SettingKey.SoundMuted, false));
        GameManager.Sound.SetMute("UISound", GameManager.Setting.GetBool(Const.SettingKey.UISoundMuted, false));
        GameManager.Sound.SetVolume("Music", GameManager.Setting.GetFloat(Const.SettingKey.MusicVolume,0.3f));
        GameManager.Sound.SetVolume("Sound", GameManager.Setting.GetFloat(Const.SettingKey.SoundVolume,1f));
        GameManager.Sound.SetVolume("UISound", GameManager.Setting.GetFloat(Const.SettingKey.UISoundVolume,1f));

        _isSoundInitComplete = true;
        //Log.Info("PrecedureLaunch ==> Sound setting init complete!");
        UpdateLaunchTips("声音配置完成！");
    }
}