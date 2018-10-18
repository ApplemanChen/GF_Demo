//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework.Event;

/// <summary>
/// 加载Proto成功事件
/// </summary>
public sealed class LoadProtoSuccessEventArgs : GameEventArgs
{
    public static int EventId = typeof(LoadProtoSuccessEventArgs).GetHashCode();

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
    /// Proto名
    /// </summary>
    public string ProtoName
    {
        private set;
        get;
    }

    /// <summary>
    /// 解析出来的Proto字符串
    /// </summary>
    public string ProtoString
    {
        private set;
        get;
    }

    /// <summary>
    /// 清理加载成功事件。
    /// </summary>
    public override void Clear()
    {
        AssetName = default(string);
        ProtoString = default(string);
        ProtoName = default(string);
    }

    public LoadProtoSuccessEventArgs Fill(string assetName,string protoName,string protoString)
    {
        AssetName = assetName;
        ProtoName = protoName;
        ProtoString = protoString;

        return this;
    }
}