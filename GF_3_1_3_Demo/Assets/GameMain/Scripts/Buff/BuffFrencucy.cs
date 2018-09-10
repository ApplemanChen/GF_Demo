//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using GameFramework;

/// <summary>
/// 间隔buff
/// </summary>
public class BuffFrencucy:BuffBase
{
    private float m_FrencucyCount;

    /// <summary>
    /// 频率间隔事件
    /// </summary>
    public float FrencucyTime
    {
        get;
        private set;
    }

    /// <summary>
    /// 间隔回调
    /// </summary>
    public GameFrameworkAction FrencucyAction
    {
        get;
        private set;
    }

    /// <summary>
    /// 实例化
    /// </summary>
    /// <param name="data">Buff数据</param>
    /// <param name="frencucyTime">间隔时间</param>
    /// <param name="action">回调</param>
    public BuffFrencucy(BuffData data,float frencucyTime,GameFrameworkAction action):base(data)
    {
        this.FrencucyTime = frencucyTime;
        this.FrencucyAction = action;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        m_FrencucyCount = 0;
    }

    public override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);

        m_FrencucyCount += elapseSeconds;
        if(m_FrencucyCount>=FrencucyTime)
        {
            m_FrencucyCount = 0;
            if(FrencucyAction != null)
            {
                FrencucyAction();
            }
        }
    }

    public override void OnExit()
    {
        base.OnExit();

        m_FrencucyCount = 0;
    }
}
