//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;

public static class WebUtility
{

    /// <summary>
    /// 将字符串进行转码，便于特殊字符的网络传输
    /// </summary>
    /// <param name="stringToEscape"></param>
    /// <returns></returns>
    public static string EscapeString(string stringToEscape)
    {
        return Uri.EscapeDataString(stringToEscape);
    }

    /// <summary>
    /// 将字符串转换为它的非转义表示形式(反转码)
    /// </summary>
    /// <param name="stringToUnescape"></param>
    /// <returns></returns>
    public static string UnescapeString(string stringToUnescape)
    {
        return Uri.UnescapeDataString(stringToUnescape);
    }
}
