//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework;
using GameFramework.Network;
using System.Collections.Generic;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Event;
using GameFramework.Resource;
using UnityEngine;

/// <summary>
/// 预加载流程
/// </summary>
public class ProcedurePreload : GameProcedureBase
{
    //加载资源标识
    private Dictionary<string, bool> m_LoadResFlag = new Dictionary<string, bool>();

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        SubscribeEvents();

        PreloadResources();
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        
        foreach(bool item in m_LoadResFlag.Values)
        {
            if(!item)
            {
                return;
            }
        }

        ChangeState<ProcedureLoadLua>(procedureOwner);
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        UnsubscribeEvents();

        m_LoadResFlag.Clear();
        base.OnLeave(procedureOwner, isShutdown);
    }

    private void UpdateLaunchTips(string tips)
    {
        GameManager.Event.Fire(this, ReferencePool.Acquire<LaunchFormUpdateTipsEventArgs>().Fill(tips));
    }

    /// <summary>
    /// 预加载资源
    /// </summary>
    private void PreloadResources()
    {
        UpdateLaunchTips("正在预加载配置表资源...");
        LoadDatable("UIForm");
        LoadDatable("Music");
        LoadDatable("Scene");
        LoadDatable("Entity");

        UpdateLaunchTips("正在预加载语言字典资源...");
        LoadDictionary("Default");
        UpdateLaunchTips("正在预加载字体资源...");
        //LoadUGUIFont("MainFont");
        LoadNGUIFont("UIFont");
    }

    //加载数据表
    private void LoadDatable(string dataTableName)
    {
        m_LoadResFlag.Add(string.Format("Datable.{0}",dataTableName),false);
        GameManager.DataTable.LoadDataTable(dataTableName);
    }

    //加载本地化字典
    private void LoadDictionary(string dictionaryName)
    {
        m_LoadResFlag.Add(string.Format("Dictionary.{0}",dictionaryName),false);
        GameManager.Localization.LoadDictionary(dictionaryName);
    }

    //加载字体
    //private void LoadUGUIFont(string fontName)
    //{
    //    m_LoadResFlag.Add(string.Format("Font.{0}", fontName), false);
    //    GameManager.Resource.LoadAsset(AssetUtility.GetFontAsset(fontName), new LoadAssetCallbacks(
    //        (assetName, asset, duration, userData) =>
    //        {
    //            m_LoadResFlag[string.Format("Font.{0}", fontName)] = true;
    //            UGuiForm.SetMainFont((Font)asset);
    //            Log.Info("Load font '{0}' OK.", fontName);
    //        },

    //        (assetName, status, errorMessage, userData) =>
    //        {
    //            Log.Error("Can not load font '{0}' from '{1}' with error message '{2}'.", fontName, assetName, errorMessage);
    //        }));
    //}

    private void LoadNGUIFont(string fontName)
    {
        m_LoadResFlag.Add(string.Format("Font.{0}", fontName), false);
        GameManager.Resource.LoadAsset(AssetUtility.GetFontAsset(fontName), new LoadAssetCallbacks(
            (assetName, asset, duration, userData) =>
            {
                m_LoadResFlag[string.Format("Font.{0}", fontName)] = true;
                GameObject fontAtlas = (GameObject)asset;
                NGuiForm.SetMainFont(fontAtlas.GetComponent<UIFont>());
                Log.Info("Load font '{0}' OK.", fontName);
            },

            (assetName, status, errorMessage, userData) =>
            {
                Log.Error("Can not load font '{0}' from '{1}' with error message '{2}'.", fontName, assetName, errorMessage);
            }));
    }

    private void SubscribeEvents()
    {
        GameManager.Event.Subscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
        GameManager.Event.Subscribe(LoadDataTableFailureEventArgs.EventId, OnLoadDataTableFailure);
        GameManager.Event.Subscribe(LoadDictionarySuccessEventArgs.EventId,OnLoadDictionarySuccess);
        GameManager.Event.Subscribe(LoadConfigSuccessEventArgs.EventId, OnLoadConfigSuccess);
    }

    private void UnsubscribeEvents()
    {
        GameManager.Event.Unsubscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
        GameManager.Event.Unsubscribe(LoadDataTableFailureEventArgs.EventId, OnLoadDataTableFailure);
        GameManager.Event.Unsubscribe(LoadDictionarySuccessEventArgs.EventId, OnLoadDictionarySuccess);
        GameManager.Event.Unsubscribe(LoadConfigSuccessEventArgs.EventId, OnLoadConfigSuccess);
    }

    private void OnLoadConfigSuccess(object sender, GameFramework.Event.GameEventArgs e)
    {
        LoadConfigSuccessEventArgs evt = (LoadConfigSuccessEventArgs)e;
        string flagKey = string.Format("Config.{0}",evt.ConfigName);
        m_LoadResFlag[flagKey] = true;
    }

    private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
    {
        LoadDataTableSuccessEventArgs evt = (LoadDataTableSuccessEventArgs)e;

        string flagKey = string.Format("Datable.{0}", evt.DataTableName);
        m_LoadResFlag[flagKey] = true;

        Log.Info("Preload asset {0} success.",flagKey);
    }
    private void OnLoadDataTableFailure(object sender, GameEventArgs e)
    {
        LoadDataTableFailureEventArgs evt = (LoadDataTableFailureEventArgs)e;

        Log.Error("Load data table faild. The error message:"+evt.ErrorMessage);
    }

    private void OnLoadDictionarySuccess(object sender,GameEventArgs e)
    {
        LoadDictionarySuccessEventArgs evt = (LoadDictionarySuccessEventArgs)e;

        string flagKey = string.Format("Dictionary.{0}", evt.DictionaryName);
        m_LoadResFlag[flagKey] = true;
        Log.Info("Preload asset {0} success.", flagKey);
    }
}
