//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using GameFramework.Event;

/// <summary>
/// 加载Lua列表文件失败事件
/// </summary>
public sealed class LoadLuaFilesConfigFailureEventArgs:GameEventArgs
{
    public static int EventId = typeof(LoadLuaFilesConfigFailureEventArgs).GetHashCode();
    
    public override int Id
    {
        get
        {
            return EventId;
        }
    }

    public string AssetName
    {
        private set;
        get;
    }

    public string ErrorMessage
    {
        private set;
        get;
    }

    public override void Clear()
    {
        EventId = default(int);
    }

    public LoadLuaFilesConfigFailureEventArgs Fill(string assetName,string errorMsg)
    {
        this.AssetName = assetName;
        this.ErrorMessage = errorMsg;
        return this;
    }
}
