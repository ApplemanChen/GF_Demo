//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;

/// <summary>
/// Buff基类
/// </summary>
public abstract class BuffBase : IBuff
{
    private BuffData m_BuffData;
    private int m_BuffId;
    protected bool m_IsRunning;
    public BuffBase(BuffData buffData)
    {
        m_BuffData = buffData;
        m_BuffId = BuffUtility.GenerateBuffId();

        OnInit();
    }

    #region 基本生命周期方法
    /// <summary>
    /// 初始化
    /// </summary>
    public virtual void OnInit()
    {

    }

    /// <summary>
    /// Buff开始
    /// </summary>
    public virtual void OnEnter()
    {
        m_IsRunning = true;
    }

    /// <summary>
    /// 轮询
    /// </summary>
    /// <param name="elapseSeconds">逻辑时间</param>
    /// <param name="realElapseSeconds">真实流逝时间</param>
    public virtual void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {

    }

    /// <summary>
    /// Buff结束
    /// </summary>
    public virtual void OnExit()
    {
        m_IsRunning = false;
    }

    #endregion

    #region 公共接口
    /// <summary>
    /// 停止Buff
    /// </summary>
    public virtual void Stop()
    {
        m_IsRunning = false;
    }

    #endregion

    /// <summary>
    /// Buff父节点
    /// </summary>
    public BuffBase ParentBuff
    {
        get;
        set;
    }

    public int BuffId
    {
        get
        {
            return m_BuffId;
        }
    }

    /// <summary>
    /// Buff数据
    /// </summary>
    public BuffData BuffData
    {
        get
        {
            return m_BuffData;
        }
    }

    /// <summary>
    /// 是否在运行
    /// </summary>
    public bool IsRunning
    {
        get
        {
            return m_IsRunning;
        }
    }
}
