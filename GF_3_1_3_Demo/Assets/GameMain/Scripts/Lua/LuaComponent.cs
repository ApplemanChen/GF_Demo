//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using UnityEngine;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Resource;
using UnityGameFramework.Runtime;
using XLua;

/// <summary>
/// Lua组件
/// </summary>
public class LuaComponent : GameFrameworkComponent
{
    /// <summary>
    /// 全局唯一Lua虚拟环境
    /// </summary>
    private static LuaEnv m_LuaEnv;
    private ResourceComponent m_ResourceComponent;
    private EventComponent m_EventComponent;
    private Dictionary<string, string> m_CacheLuaDict;

    protected override void Awake()
    {
        base.Awake();

    }

    private void Start()
    {
        m_ResourceComponent = GameEntry.GetComponent<ResourceComponent>();
        m_EventComponent = GameEntry.GetComponent<EventComponent>();
        if(m_ResourceComponent == null)
        {
            Log.Error(" m_ResourceComponent is null.");
            return;
        }

        m_CacheLuaDict = new Dictionary<string, string>();
        m_LuaEnv = new LuaEnv();
    }

    private void Update()
    {
        if(m_LuaEnv != null)
        {
            m_LuaEnv.Tick();
        }
    }
    
    private void OnDestroy()
    {
        m_CacheLuaDict.Clear();

        if(m_LuaEnv != null)
        {
            m_LuaEnv.Dispose();
        }
    }

    /// <summary>
    /// 执行lua文件
    /// </summary>
    /// <param name="luaName"></param>
    public void DoLuaFile(string luaName)
    {
        if(m_CacheLuaDict.ContainsKey(luaName))
        {
            if(m_LuaEnv != null)
            {
                string luaString = m_CacheLuaDict[luaName];
                m_LuaEnv.DoString(luaString);
            }
        }else
        {
            Log.Error("Lua file '{0}' is not load,please execute LoadLuaFile() first.",luaName);
        }
    }

    /// <summary>
    /// 加载lua文件
    /// </summary>
    /// <param name="assetName"></param>
    /// <param name="luaName"></param>
    public void LoadLuaFile(string luaName, string assetName)
    {
        LoadAssetCallbacks callBacks = new LoadAssetCallbacks(OnLoadLuaAssetSuccess,OnLoadLuaAssetFailure); 

        if(m_CacheLuaDict.ContainsKey(luaName))
        {
            m_EventComponent.Fire(this, ReferencePool.Acquire<LoadLuaSuccessEventArgs>().Filll(assetName, luaName, m_CacheLuaDict[luaName]));
            return;
        }

        m_ResourceComponent.LoadAsset(assetName,callBacks,luaName);
    }

    private void OnLoadLuaAssetSuccess(string assetName, object asset, float duration, object userData)
    {
        string luaName = (string)userData;

        if (m_CacheLuaDict.ContainsKey(luaName))
        {
            Log.Warning("CacheLuaDict has exist lua file '{0}'.", luaName);
            return;
        }

        TextAsset textAsset = (TextAsset)asset;
        m_CacheLuaDict.Add(luaName, textAsset.text);

        Log.Info("Load lua '{0}' success.",luaName);
        m_EventComponent.Fire(this,ReferencePool.Acquire<LoadLuaSuccessEventArgs>().Filll(assetName,luaName,textAsset.text));
    }

    private void OnLoadLuaAssetFailure(string assetName, string dependencyAssetName, int loadedCount, int totalCount, object userData)
    {
        string luaName = (string)userData;
        string errorMessage = string.Format("Load lua file failed. The file is {0}. ", assetName);
        m_EventComponent.Fire(this, ReferencePool.Acquire<LoadLuaFailureEventArgs>().Fill(assetName, luaName, errorMessage));
    }
}
