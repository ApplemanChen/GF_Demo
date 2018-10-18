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
using System;

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
    private List<LuaFileInfo> m_LuaFileInfos;
    //private Dictionary<string, string> m_CacheProtoDict;
    private Dictionary<string, byte[]> m_CacheProtoPbDict;

    /// <summary>
    /// Lua文件列表信息
    /// </summary>
    public List<LuaFileInfo> LuaFileInfos
    {
        get
        {
            return m_LuaFileInfos;
        }
    }

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
        m_LuaFileInfos = new List<LuaFileInfo>();
        //m_CacheProtoDict = new Dictionary<string, string>();
        m_CacheProtoPbDict = new Dictionary<string, byte[]>();
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
        //m_CacheProtoDict.Clear();
        m_CacheProtoPbDict.Clear();

        if(m_LuaEnv != null)
        {
            m_LuaEnv.Dispose();
            m_LuaEnv = null;
        }
    }

    /// <summary>
    /// 加载lua文件列表
    /// </summary>
    public void LoadLuaFilesConfig()
    {
        LoadAssetCallbacks callBacks = new LoadAssetCallbacks(OnLoadLuaFilesConfigSuccess, OnLoadLuaFilesConfigFailure);
        string assetName = AssetUtility.GetLuaFileConfig();
        m_ResourceComponent.LoadAsset(assetName, callBacks);
    }

    /// <summary>
    /// 解析Lua文件配置列表
    /// </summary>
    /// <param name="content">配置列表内容</param>
    public void ParseLuaFilesConfig(string content)
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

    }

    /// <summary>
    /// 初始化 Lua 环境第三方库接口
    /// </summary>
    public void InitLuaEnvExternalInterface()
    {
        m_LuaEnv.AddBuildin("rapidjson", XLua.LuaDLL.Lua.LoadRapidJson);
        m_LuaEnv.AddBuildin("lpeg", XLua.LuaDLL.Lua.LoadLpeg);
        m_LuaEnv.AddBuildin("pb", XLua.LuaDLL.Lua.LoadLuaProfobuf);
    }

    /// <summary>
    /// 执行lua文件
    /// </summary>
    /// <param name="luaName"></param>
    public void DoLuaFile(string luaName)
    {
        if(m_CacheLuaDict.ContainsKey(luaName))
        {
            try
            {
                if(m_LuaEnv != null)
                {
                    string luaString = m_CacheLuaDict[luaName];
                    m_LuaEnv.DoString(luaString);
                }
            }catch(Exception exception)
            {
                Log.Error(exception.Message);
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
            m_EventComponent.Fire(this, ReferencePool.Acquire<LoadLuaSuccessEventArgs>().Fill(assetName, luaName, m_CacheLuaDict[luaName]));
            return;
        }

        m_ResourceComponent.LoadAsset(assetName,callBacks,luaName);
    }

    /// <summary>
    /// (方式1)加载Proto文件
    /// </summary>
    /// <param name="protoName"></param>
    //public void LoadProtoFile(string protoName)
    //{
    //    LoadAssetCallbacks callBacks = new LoadAssetCallbacks(OnLoadProtoAssetSuccess);

    //    string assetName = AssetUtility.GetProtoAsset(protoName);

    //    if (m_CacheProtoDict.ContainsKey(protoName))
    //    {
    //        m_EventComponent.Fire(this, ReferencePool.Acquire<LoadProtoSuccessEventArgs>().Fill(assetName, protoName, m_CacheProtoDict[protoName]));
    //        return;
    //    }

    //    m_ResourceComponent.LoadAsset(assetName, callBacks, protoName);
    //}

    /// <summary>
    /// (方式2)加载ProtoPb文件
    /// </summary>
    /// <param name="protoName"></param>
    public void LoadProtoPbFile(string protoName)
    {
        LoadAssetCallbacks callBacks = new LoadAssetCallbacks(OnLoadProtoPbAssetSuccess);

        string assetName = AssetUtility.GetProtoPbAsset(protoName);

        if (m_CacheProtoPbDict.ContainsKey(protoName))
        {
            m_EventComponent.Fire(this, ReferencePool.Acquire<LoadProtoPbSuccessEventArgs>().Fill(assetName, protoName, m_CacheProtoPbDict[protoName]));
            return;
        }

        m_ResourceComponent.LoadAsset(assetName, callBacks, protoName);
    }

    /// <summary>
    /// 获取全局类的LuaTable
    /// </summary>
    /// <param name="luaName"></param>
    /// <param name="className"></param>
    /// <param name="?"></param>
    /// <returns></returns>
    public LuaTable GetClassLuaTable(string luaName,string className)
    {
        if (m_CacheLuaDict.ContainsKey(luaName))
        {
            LuaTable classLuaTable = m_LuaEnv.Global.Get<LuaTable>(className);
            return classLuaTable;
        }
        else
        {
            Log.Error("Lua file '{0}' is not load,please execute LoadLuaFile() first.", luaName);
            return null;
        }
    }



    /// <summary>
    /// 获取LuaTable
    /// </summary>
    /// <param name="luaName"></param>
    /// <param name="className"></param>
    /// <param name="tableName"></param>
    /// <returns></returns>
    public LuaTable GetLuaTable(string luaName,string className,string tableName)
    {
        if (m_CacheLuaDict.ContainsKey(luaName))
        {
            LuaTable classLuaTable = m_LuaEnv.Global.Get<LuaTable>(className);
            LuaTable luaTable = classLuaTable.Get<LuaTable>(tableName);
            classLuaTable.Dispose();
            classLuaTable = null;
            return luaTable;
        }
        else
        {
            Log.Error("Lua file '{0}' is not load,please execute LoadLuaFile() first.", luaName);
            return null;
        }
    }

    /// <summary>
    /// 调用Lua方法
    /// </summary>
    /// <param name="funcName"></param>
    public void CallLuaFunction(LuaTable luaTable,string funcName,params object[] param)
    {
        if(luaTable != null)
        {
            try
            {
                LuaFunction luaFunction = luaTable.Get<LuaFunction>(funcName);
                luaFunction.Call(param);
                luaFunction.Dispose();
                luaFunction = null;
            }catch(Exception exception)
            {
                Log.Error(exception.Message);
            }
        }else
        {
            Log.Error("LuaTable is invalid.");
        }
    }

    /// <summary>
    /// 调用Lua方法
    /// </summary>
    /// <param name="luaName"></param>
    /// <param name="className"></param>
    /// <param name="funcName"></param>
    /// <param name="parms"></param>
    public void CallLuaFunction(string luaName,string className,string funcName, params object[] parms)
    {
       if(m_CacheLuaDict.ContainsKey(luaName))
        {
           try
           {
               LuaTable classLuaTable = m_LuaEnv.Global.Get<LuaTable>(className);
               LuaFunction luaFunc = classLuaTable.Get<LuaFunction>(funcName);
               luaFunc.Call(parms);
               classLuaTable.Dispose();
               luaFunc.Dispose();
               classLuaTable = null;
               luaFunc = null;
           }catch(Exception exception)
           {
               Log.Error(exception.Message);
           }
        }
       else
       {
           Log.Error("Lua file '{0}' is not load,please execute LoadLuaFile() first.", luaName);
       }
    }

    private void OnLoadLuaFilesConfigFailure(string assetName, LoadResourceStatus status, string errorMessage, object userData)
    {
        Log.Info("Load LuaFilesConfig: '{0}' failure.", assetName);
        m_EventComponent.Fire(this, ReferencePool.Acquire<LoadLuaFilesConfigFailureEventArgs>().Fill(assetName, errorMessage));
    }

    private void OnLoadLuaFilesConfigSuccess(string assetName, object asset, float duration, object userData)
    {
        TextAsset textAsset = (TextAsset)asset;
        Log.Info("Load LuaFilesConfig: '{0}' success.", assetName);

        string content = textAsset.text;
        //开始解析Lua配置文件列表
        ParseLuaFilesConfig(content);

        m_EventComponent.Fire(this, ReferencePool.Acquire<LoadLuaFilesConfigSuccessEventArgs>().Fill(assetName, content));
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
        m_EventComponent.Fire(this,ReferencePool.Acquire<LoadLuaSuccessEventArgs>().Fill(assetName,luaName,textAsset.text));
    }

    //private void OnLoadProtoAssetSuccess(string assetName, object asset, float duration, object userData)
    //{
    //    string protoName = (string)userData;

    //    if (m_CacheProtoDict.ContainsKey(protoName))
    //    {
    //        Log.Warning("CacheLuaDict has exist proto file '{0}'.", protoName);
    //        return;
    //    }

    //    TextAsset textAsset = (TextAsset)asset;
    //    m_CacheProtoDict.Add(protoName, textAsset.text);

    //    Log.Info("Load proto '{0}' success.", protoName);
    //    m_EventComponent.Fire(this, ReferencePool.Acquire<LoadProtoSuccessEventArgs>().Fill(assetName, protoName, textAsset.text));
    //}

    private void OnLoadProtoPbAssetSuccess(string assetName, object asset, float duration, object userData)
    {
        string protoName = (string)userData;

        if (m_CacheProtoPbDict.ContainsKey(protoName))
        {
            Log.Warning("m_CacheProtoPbDict has exist proto file '{0}'.", protoName);
            return;
        }

        TextAsset textAsset = (TextAsset)asset;
        m_CacheProtoPbDict.Add(protoName, textAsset.bytes);

        Log.Info("Load proto pb '{0}' success.", protoName);
        m_EventComponent.Fire(this, ReferencePool.Acquire<LoadProtoPbSuccessEventArgs>().Fill(assetName, protoName,textAsset.bytes ));
    }

    private void OnLoadLuaAssetFailure(string assetName, string dependencyAssetName, int loadedCount, int totalCount, object userData)
    {
        string luaName = (string)userData;
        string errorMessage = string.Format("Load lua file failed. The file is {0}. ", assetName);
        m_EventComponent.Fire(this, ReferencePool.Acquire<LoadLuaFailureEventArgs>().Fill(assetName, luaName, errorMessage));
    }
}
