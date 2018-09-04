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
    private static int s_BuffTypeDepth = 1000000;
    private static int s_BuffSubTypeDepth = 10000;
    /// <summary>
    /// 全局临时BuffId
    /// </summary>
    private static int s_TempBuffId = 0;

    /// <summary>
    /// 生成BuffId
    /// </summary>
    /// <param name="buffType"></param>
    /// <param name="buffSubType"></param>
    /// <returns></returns>
    public static int GenerateBuffId(int buffType)
    {
        s_TempBuffId++;
        //临时值达到子类型深度最大值，重置0
        if (s_TempBuffId >= s_BuffSubTypeDepth)
        {
            s_TempBuffId = 0;
        }
        return buffType * s_BuffTypeDepth + s_TempBuffId;
    }
}