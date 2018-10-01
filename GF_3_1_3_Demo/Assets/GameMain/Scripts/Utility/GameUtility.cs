//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/// <summary>
/// 游戏通用工具类
/// </summary>
public static class GameUtility
{
    /// <summary>
    /// 反序列化json
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    /// <returns></returns>
    public static T DeserializeObject<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }

    /// <summary>
    /// 序列化json
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string SerializeObject<T>(T obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
}
