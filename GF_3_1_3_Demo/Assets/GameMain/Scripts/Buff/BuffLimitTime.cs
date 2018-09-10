//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;

/// <summary>
/// 限时类Buff
/// (控制Buff生命周期)
/// </summary>
public class BuffLimitTime: BuffBase
{
    private float m_LifeTimeCount;

    public BuffLimitTime(BuffData data):base(data)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();

        m_LifeTimeCount = 0;
    }

    public override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);

        if (!m_IsRunning) return;

        m_LifeTimeCount += elapseSeconds;
        if(m_LifeTimeCount >= BuffData.LifeTime)
        {
            //控制父节点退出
            if(ParentBuff != null)
            {
                ParentBuff.OnExit();
            }else
            {
                OnExit();
            }
        }
    }

    public override void OnExit()
    {
        base.OnExit();

        m_LifeTimeCount = 0;
    }
}
