//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework;
using UnityGameFramework.Runtime;
using UnityEngine;

/// <summary>
/// 自定义基础配置组件
/// </summary>
public class BaseConfigComponent:GameFrameworkComponent
{
    private ConfigComponent m_ConfigComponent;

    [SerializeField]
    private TextAsset m_BuildConfig;
    [SerializeField]
    private TextAsset m_ServerConfig;
    [SerializeField]
    private TextAsset m_DefaultConfig;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        m_ConfigComponent = GameEntry.GetComponent<ConfigComponent>();
        if (m_ConfigComponent == null)
        {
            Log.Fatal("Config component is invalid.");
            return;
        }
    }

    public void InitBuildConfig()
    {
        if(!m_ConfigComponent.ParseConfig(m_BuildConfig.text))
        {
            Log.Error("Build config parse failure.");
            return;
        }

        GameManager.Base.GameVersion = m_ConfigComponent.GetString(Const.BuildConfigKey.GameVersion);
        GameManager.Base.InternalApplicationVersion = m_ConfigComponent.GetInt(Const.BuildConfigKey.InternalVersion);
    }

    public void InitServerConfig()
    {
        if(!m_ConfigComponent.ParseConfig(m_ServerConfig.text))
        {
            Log.Error("Server config parse failure.");
            return;
        }

        NetworkExtension.GameServerIP = GameManager.Config.GetString(Const.ServerConfigKey.GameServerIP);
        NetworkExtension.GameServerPort = GameManager.Config.GetInt(Const.ServerConfigKey.GameServerPort);
    }
}