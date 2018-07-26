//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;
using XLua;

/// <summary>
/// Lua界面
/// </summary>
public class LuaForm : UGuiForm
{
    private string luaManager = "Manager/LuaFormManager";
    private string managerClass = "LuaFormManager";
    private string formName = "";
    private LuaTable m_FormManagerLuaTable;

    protected internal override void OnInit(object userData)
    {
        base.OnInit(userData);

        formName = Name;
    }

    protected internal override void OnOpen(object userData)
    {
        base.OnOpen(userData);

        //先执行界面Lua，将Form注册到LuaFormManager中
        LuaTable luaTable = GameManager.Lua.GetLuaTable(luaManager, managerClass, "FormIDToLuaName");
        string luaName = luaTable.Get<string>(formName);
        GameManager.Lua.DoLuaFile(luaName);
        luaTable.Dispose();

        //再调用LuaFormManager的方法
        m_FormManagerLuaTable = GameManager.Lua.GetClassLuaTable(luaManager, managerClass);
        if(m_FormManagerLuaTable != null)
        {
            GameManager.Lua.CallLuaFunction(m_FormManagerLuaTable,"Open",formName,CachedTransform);
        }
    }

    protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);

        if (m_FormManagerLuaTable != null)
        {
            GameManager.Lua.CallLuaFunction(m_FormManagerLuaTable, "OnUpdate",formName, elapseSeconds, realElapseSeconds);
        }
    }

    protected internal override void OnClose(object userData)
    {
        base.OnClose(userData);

        if (m_FormManagerLuaTable != null)
        {
            GameManager.Lua.CallLuaFunction(m_FormManagerLuaTable, "OnClose", formName);
        }
    }

    protected override void OnOpenComplete()
    {
        base.OnOpenComplete();

        if (m_FormManagerLuaTable != null)
        {
            GameManager.Lua.CallLuaFunction(m_FormManagerLuaTable, "OnOpenComplete", formName);
        }
    }
}
