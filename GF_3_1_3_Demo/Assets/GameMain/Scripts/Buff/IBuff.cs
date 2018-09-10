//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;

/// <summary>
/// Buff接口
/// </summary>
public interface IBuff
{
    /// <summary>
    /// 开始
    /// </summary>
    void OnEnter();
    /// <summary>
    /// 轮询
    /// </summary>
    /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
    /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
    void OnUpdate(float elapseSeconds, float realElapseSeconds);
    /// <summary>
    /// 退出
    /// </summary>
    void OnExit();
}
