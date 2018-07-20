//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using UnityGameFramework.Runtime;

/// <summary>
/// 场景基类
/// </summary>
public abstract class SceneBase
{
    public SceneBase(int sceneId)
    {
        SceneId = sceneId;
        SceneName = GameManager.Scene.GetSceneName(SceneId);

        OnInit();
    }

    /// <summary>
    /// 场景id
    /// </summary>
    public int SceneId
    {
        private set;
        get;
    }

    /// <summary>
    /// 场景名
    /// </summary>
    public string SceneName
    {
        private set;
        get;
    }

    /// <summary>
    /// 场景类型
    /// </summary>
    public abstract SceneType SceneType
    {
        get;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    protected abstract void OnInit();

    /// <summary>
    /// 进入场景
    /// </summary>
    protected abstract void OnEnter();

    /// <summary>
    /// 轮训
    /// </summary>
    protected abstract void OnUpdate(float elapseSeconds, float realElapseSeconds);

    /// <summary>
    /// 退出场景
    /// </summary>
    protected abstract void OnExit();

    #region 公用方法
    public void Update(float elapseSeconds, float realElapseSeconds)
    {
        OnUpdate(elapseSeconds,realElapseSeconds);
    }

    public void Enter()
    {
        OnEnter();
    }

    public void Exit()
    {
        OnExit();
    }

    #endregion
}
