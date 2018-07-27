//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using XLua;
using UnityGameFramework.Runtime;
using UnityEditor;

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
        typeof(LuaCallStatic),
    };

    [CSharpCallLua]
    public static List<Type> cshapCallLuaTypeList = new List<Type>()
    {
        typeof(UnityEngine.Events.UnityAction),
    };

    /// <summary>
    /// 生成Wrap代码后，刷新下
    /// </summary>
    [CSObjectWrapEditor.GenCodeMenu]
    private static void AfterGenWrapCode()
    {
        AssetDatabase.Refresh();
    }
}