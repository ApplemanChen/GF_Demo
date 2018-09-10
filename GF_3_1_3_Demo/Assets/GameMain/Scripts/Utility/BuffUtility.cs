//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;

/// <summary>
/// Buff相关工具类
/// </summary>
public static class BuffUtility
{
    /// <summary>
    /// 全局临时BuffId
    /// </summary>
    private static int s_TempBuffId = 0;

    /// <summary>
    /// 生成BuffId
    /// </summary>
    /// <returns></returns>
    public static int GenerateBuffId()
    {
        return ++s_TempBuffId;
    }
}