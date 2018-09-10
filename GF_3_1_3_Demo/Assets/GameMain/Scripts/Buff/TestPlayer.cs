//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 测试玩家
/// </summary>
public class TestPlayer:MonoBehaviour
{
    public int maxHp = 100;
    public int hp = 100;

    public UILabel m_HpLabel;
    private BuffContainer m_BuffContainer;

    void Awake()
    {
        m_BuffContainer = new BuffContainer(this);
    }

    void Update()
    {
        m_BuffContainer.OnUpdate(Time.deltaTime, Time.unscaledDeltaTime);

        m_HpLabel.text = hp.ToString();
    }
}