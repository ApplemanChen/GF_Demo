//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework.Event;

/// <summary>
/// 加载ProtoPb文件成功事件
/// </summary>
public sealed class LoadProtoPbSuccessEventArgs : GameEventArgs
{
    public static int EventId = typeof(LoadProtoPbSuccessEventArgs).GetHashCode();

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
    /// 解析出来的Proto字节
    /// </summary>
    public byte[] ProtoBytes
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
        ProtoBytes = default(byte[]);
        ProtoName = default(string);
    }

    public LoadProtoPbSuccessEventArgs Fill(string assetName,string protoName,byte[] protoBytes)
    {
        AssetName = assetName;
        ProtoName = protoName;
        ProtoBytes = protoBytes;

        return this;
    }
}