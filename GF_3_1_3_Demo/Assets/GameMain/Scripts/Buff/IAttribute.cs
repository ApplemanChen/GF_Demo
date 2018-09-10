//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using GameFramework;

/// <summary>
/// 属性接口
/// </summary>
public interface IAttribute
{
    /// <summary>
    /// 属性名
    /// </summary>
    string Key { get; }

    /// <summary>
    /// 设置数据
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void SetData<T>(string key, T value) where T:Variable;

    /// <summary>
    /// 获取数据 
    /// </summary>
    /// <typeparam name="T">数据类型：int,float等</typeparam>
    /// <param name="key">键名</param>
    /// <returns></returns>
    T GetData<T>(string key) where T : Variable;
}
