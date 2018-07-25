//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;

/// <summary>
/// 版本信息
/// </summary>
[Serializable]
public class VersionInfo
{
    /// <summary>
    /// 最新游戏版本
    /// </summary>
    public string LatestGameVersion;
    /// <summary>
    /// 最新资源适用的游戏版本列表
    /// </summary>
    public string ApplicableGameVersion;
    /// <summary>
    /// 最新内部资源版本号
    /// </summary>
    public int LatestInternalResourceVersion;
    /// <summary>
    /// 资源更新地址
    /// </summary>
    public string ResourceUpdateUrl;

    /// <summary>
    /// GameResourceVersion.xml 中 ResourceLength
    /// </summary>
    public int ResourceLength;
    /// <summary>
    /// GameResourceVersion.xml 中 ResourceHashCode
    /// </summary>
    public int ResourceHashCode;
    /// <summary>
    /// GameResourceVersion.xml 中 ResourceZipLength
    /// </summary>
    public int ResourceZipLength;
    /// <summary>
    /// GameResourceVersion.xml 中 ResourceZipHashCode
    /// </summary>
    public int ResourceZipHashCode;
}