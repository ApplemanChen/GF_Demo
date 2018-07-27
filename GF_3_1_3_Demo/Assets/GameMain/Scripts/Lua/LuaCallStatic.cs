//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

/// <summary>
/// Lua调用的常用方法
/// </summary>
public class LuaCallStatic
{
    public static void LuaCloseForm(string uiFormId)
    {
        GameManager.UI.CloseUIForm(uiFormId);
    }
}