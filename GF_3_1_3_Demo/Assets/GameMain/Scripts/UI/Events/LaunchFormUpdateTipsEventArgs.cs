//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework;
using UnityGameFramework.Runtime;
using GameFramework.Event;

/// <summary>
/// 启动界面更新提示事件
/// </summary>
public class LaunchFormUpdateTipsEventArgs : GameEventArgs
{
    public static int EventId = typeof(LaunchFormUpdateTipsEventArgs).GetHashCode();
    public override int Id
    {
        get { return EventId; }
    }

    public string Tips
    {
        private set;
        get;
    }

    public override void Clear()
    {
        Tips = default(string);
    }

    public LaunchFormUpdateTipsEventArgs Fill(string tips)
    {
        this.Tips = tips;

        return this;
    }
}
