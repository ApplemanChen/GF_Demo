//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using GameFramework.Event;

/// <summary>
/// 加载lua文件列表成功事件
/// </summary>
public sealed class LoadLuaFilesConfigSuccessEventArgs:GameEventArgs
{
    public static int EventId = typeof(LoadLuaFilesConfigSuccessEventArgs).GetHashCode();

    public override int Id
    {
        get { return EventId; }
    }

    public string AssetName
    {
        private set;
        get;
    }

    public string Content
    {
        private set;
        get;
    }

    public override void Clear()
    {
        EventId = default(int);
    }

    /// <summary>
    /// 填充事件参数
    /// </summary>
    public LoadLuaFilesConfigSuccessEventArgs Fill(string assetName,string content)
    {
        this.AssetName = assetName;
        this.Content = content;

        return this;
    }
}
