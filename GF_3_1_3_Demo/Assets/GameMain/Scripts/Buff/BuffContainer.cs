//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityGameFramework.Runtime;

/// <summary>
/// Buff容器
/// </summary>
public class BuffContainer:IBuffOwner
{
    private TestPlayer m_Player;
    private List<BuffBase> m_BuffList;

    public List<BuffBase> BuffList
    {
        get
        {
            return m_BuffList;
        }
    }

    public BuffContainer(TestPlayer player)
    {
        m_Player = player;

        m_BuffList = new List<BuffBase>();

        BuffData data = new BuffData() 
        {
            BuffType = BuffType.Composite,
            LifeTime = 10
        };
        BuffLimitTime buffLimitTime = new BuffLimitTime(data);
        BuffFrencucy buffFren = new BuffFrencucy(data, 1, OnBuffFrenCallBack);
        BuffComposite buffComposite = new BuffComposite(data, buffFren, buffLimitTime);
        buffComposite.OnEnter();

        AddBuff(buffComposite);
    }

    public void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        foreach(BuffBase buff in m_BuffList)
        {
            buff.OnUpdate(elapseSeconds,realElapseSeconds);
        }
    }

    private void OnBuffFrenCallBack()
    {
        m_Player.hp -= 10;
    }

    public void AddBuff(BuffBase buff)
    {
        if(!m_BuffList.Contains(buff))
        {
            m_BuffList.Add(buff);
        }
    }

    public void RemoveBuff(BuffBase buff)
    {
        if(m_BuffList.Contains(buff))
        {
            m_BuffList.Remove(buff);
        }
    }
}
