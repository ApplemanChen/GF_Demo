//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;

/// <summary>
/// Buff持有者接口
/// </summary>
public interface IBuffOwner
{
    /// <summary>
    /// 所有Buff列表
    /// </summary>
    IList<IBuff> BuffList { get; }

    /// <summary>
    /// 添加Buff
    /// </summary>
    /// <param name="buff"></param>
    void AddBuff(IBuff buff);

    /// <summary>
    /// 移除Buff
    /// </summary>
    /// <param name="buff"></param>
    void RemoveBuff(IBuff buff);
}

