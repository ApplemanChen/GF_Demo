//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;

/// <summary>
/// Buff数据
/// </summary>
public class BuffData
{
    public BuffData()
    {
        
    }

    /// <summary>
    /// 类型
    /// </summary>
    public BuffType BuffType
    {
        get;
        set;
    }

    /// <summary>
    /// 生命周期
    /// </summary>
    public float LifeTime
    {
        get;
        set;
    }
}
