//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework;
using GameFramework.Network;
using ProtoBuf;
using System.Net;
using System.IO;
using System.Collections.Generic;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Event;
using System;
using network;
using GameFramework.Resource;
using UnityEngine;

/// <summary>
/// 预加载流程
/// </summary>
public class ProcedurePreload : GameProcedureBase
{
    private INetworkChannel channel;
    //加载资源标识
    private Dictionary<string, bool> _loadResFlag = new Dictionary<string, bool>();

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        SubscribeEvents();

        PreloadResources();
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        
        foreach(bool item in _loadResFlag.Values)
        {
            if(!item)
            {
                return;
            }
        }

        ChangeState<ProcedureMenu>(procedureOwner);
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        UnsubscribeEvents();

        _loadResFlag.Clear();
        base.OnLeave(procedureOwner, isShutdown);
    }

    /// <summary>
    /// 预加载资源
    /// </summary>
    private void PreloadResources()
    {
        LoadDatable("UIForm");
        LoadDatable("Music");
        LoadDatable("Scene");

        LoadDictionary("Default");

        LoadFont("MainFont");
    }

    //加载数据表
    private void LoadDatable(string dataTableName)
    {
        _loadResFlag.Add(string.Format("Datable.{0}",dataTableName),false);
        GameManager.DataTable.LoadDataTable(dataTableName);
    }

    //加载本地化字典
    private void LoadDictionary(string dictionaryName)
    {
        _loadResFlag.Add(string.Format("Dictionary.{0}",dictionaryName),false);
        GameManager.Localization.LoadDictionary(dictionaryName);
    }

    //加载字体
    private void LoadFont(string fontName)
    {
        _loadResFlag.Add(string.Format("Font.{0}", fontName), false);
        GameManager.Resource.LoadAsset(AssetUtility.GetFontAsset(fontName), new LoadAssetCallbacks(
            (assetName, asset, duration, userData) =>
            {
                _loadResFlag[string.Format("Font.{0}", fontName)] = true;
                UGuiForm.SetMainFont((Font)asset);
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
    }

    private void UnsubscribeEvents()
    {
        GameManager.Event.Unsubscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
        GameManager.Event.Unsubscribe(LoadDataTableFailureEventArgs.EventId, OnLoadDataTableFailure);
        GameManager.Event.Unsubscribe(LoadDictionarySuccessEventArgs.EventId, OnLoadDictionarySuccess);
    }

    private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
    {
        LoadDataTableSuccessEventArgs evt = (LoadDataTableSuccessEventArgs)e;

        string flagKey = string.Format("Datable.{0}", evt.DataTableName);
        _loadResFlag[flagKey] = true;
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
        _loadResFlag[flagKey] = true;
    }

    private void InitNetwork()
    {
        GameManager.Event.Subscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConneted);

        NetworkChannelHelper helper = new NetworkChannelHelper();
        channel = GameManager.Network.CreateNetworkChannel(Const.ServerConfigKey.GameServerIP, helper);
        channel.Connect(IPAddress.Parse(NetworkExtension.GameServerIP), NetworkExtension.GameServerPort);
    }

    private void OnNetworkConneted(object sender, GameEventArgs e)
    {
        Log.Info("连接上服务器~~~");

        cs_login loginInfo = new cs_login();
        loginInfo.account = "1234";
        loginInfo.password = "abc";
        GameManager.Network.Send<cs_login>(loginInfo);
    }
}
