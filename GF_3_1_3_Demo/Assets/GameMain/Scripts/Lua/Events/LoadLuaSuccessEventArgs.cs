//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework.Event;

/// <summary>
/// 加载Lua成功事件
/// </summary>
public sealed class LoadLuaSuccessEventArgs : GameEventArgs
{
    public static int EventId = typeof(LoadLuaSuccessEventArgs).GetHashCode();

    public override int Id
    {
        get
        {
            return EventId;
        }
    }

    /// <summary>
    /// 资源名
    /// </summary>
    public string AssetName
    {
        private set;
        get;
    }

    /// <summary>
    /// Lua名
    /// </summary>
    public string LuaName
    {
        private set;
        get;
    }

    /// <summary>
    /// 解析出来的Lua字符串
    /// </summary>
    public string LuaString
    {
        private set;
        get;
    }

    /// <summary>
    /// 清理加载Lua成功事件。
    /// </summary>
    public override void Clear()
    {
        AssetName = default(string);
        LuaString = default(string);
        LuaName = default(string);
    }

    public LoadLuaSuccessEventArgs Fill(string assetName,string luaName,string luaString)
    {
        AssetName = assetName;
        LuaName = luaName;
        LuaString = luaString;

        return this;
    }
}