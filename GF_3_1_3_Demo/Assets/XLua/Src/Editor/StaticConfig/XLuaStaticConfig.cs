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
using GameFramework;
using GameFramework.Event;

/// <summary>
/// XLua静态Wrap配置类
/// </summary>
public static class XLuaStaticConfig
{
    [LuaCallCSharp]
    public static List<Type> luaCallCshapTypeList = new List<Type>()
    {
        typeof(GameManager),
        typeof(LuaCallStatic),
        typeof(DialogParams),
        typeof(LuaSendEventArgs),
        typeof(LuaEventId),
        typeof(UILabel),
        typeof(UIInput),
        typeof(UIButton),
        typeof(UIScrollView),
        typeof(LuaComponent),
    };

    [CSharpCallLua]
    public static List<Type> cshapCallLuaTypeList = new List<Type>()
    {
        typeof(UnityEngine.Events.UnityAction),
        typeof(GameFrameworkAction<object>),
        typeof(EventHandler<GameEventArgs>),
        typeof(EventHandler<LuaSendEventArgs>),
        typeof(UIEventListener.VoidDelegate),
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