//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;

/// <summary>
/// 组合Buff
/// </summary>
public class BuffComposite : BuffBase
{
    protected List<BuffBase> m_SubBuffList;

    public BuffComposite(BuffData data,params BuffBase[] buffs):base(data)
    {
        //添加子Buff
        if(buffs.Length>0)
        {
            for (int i = 0; i < buffs.Length;i++ )
            {
                buffs[i].ParentBuff = this;
                AddSubBuff(buffs[i]);
            }
        }
    }

    public override void OnInit()
    {
        base.OnInit();

        //如果有子Buff，则遍历子buff
        if (m_SubBuffList != null && m_SubBuffList.Count > 0)
        {
            int count = m_SubBuffList.Count;
            for (int i = 0; i < count; i++)
            {
                m_SubBuffList[i].OnInit();
            }
        }
    }

    public override void OnEnter()
    {
        base.OnEnter();

        //如果有子Buff，则遍历子buff
        if (m_SubBuffList != null && m_SubBuffList.Count > 0)
        {
            int count = m_SubBuffList.Count;
            for (int i = 0; i < count; i++)
            {
                m_SubBuffList[i].OnEnter();
            }
        }

    }

    public override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);

        if (!IsRunning) return;

        //如果有子Buff，则遍历子buff
        if (m_SubBuffList != null && m_SubBuffList.Count > 0)
        {
            int count = m_SubBuffList.Count;
            for (int i = 0; i < count; i++)
            {
                m_SubBuffList[i].OnUpdate(elapseSeconds,realElapseSeconds);
            }
        }
    }

    public override void OnExit()
    {
        base.OnExit();

        //如果有子Buff，则遍历子buff
        if (m_SubBuffList != null && m_SubBuffList.Count > 0)
        {
            int count = m_SubBuffList.Count;
            for (int i = 0; i < count; i++)
            {
                m_SubBuffList[i].OnExit();
            }
        }
    }

    /// <summary>
    /// 添加子Buff
    /// </summary>
    /// <param name="buff"></param>
    public void AddSubBuff(BuffBase buff)
    {
        if (m_SubBuffList == null) m_SubBuffList = new List<BuffBase>();
        if (!m_SubBuffList.Exists((bf) => { return bf.BuffId == buff.BuffId; }))
        {
            m_SubBuffList.Add(buff);
        }
    }

    /// <summary>
    /// 移除子Buff
    /// </summary>
    /// <param name="buff"></param>
    public void RemoveSubBuff(BuffBase buff)
    {
        if (m_SubBuffList != null && m_SubBuffList.Contains(buff))
        {
            m_SubBuffList.Remove(buff);
        }
    }
}