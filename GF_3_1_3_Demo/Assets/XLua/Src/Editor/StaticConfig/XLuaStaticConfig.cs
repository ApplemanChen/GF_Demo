//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using XLua;

/// <summary>
/// XLua静态Wrap配置类
/// </summary>
public static class XLuaStaticConfig
{
    [LuaCallCSharp]
    public static List<Type> luaCallCshapTypeList = new List<Type>() 
    {
        typeof(GameManager),
        typeof(BaseConfigComponent),
    };
}