//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;
using XLua;
using System.Collections.Generic;

/// <summary>
/// Lua界面
/// </summary>
public class LuaForm : NGuiForm
{
    private string m_FormManagerName = "Manager/LuaFormManager";
    private string m_ManagerClass = "LuaFormManager";
    private string m_FormName = "";
    private LuaTable m_FormManagerLuaTable;



    protected internal override void OnInit(object userData)
    {
        base.OnInit(userData);

        m_FormName = Name;
    }

    protected internal override void OnOpen(object userData)
    {
        //先执行界面Lua，将Form注册到LuaFormManager中
        LuaTable luaTable = GameManager.Lua.GetLuaTable(m_FormManagerName, m_ManagerClass, "FormIDToLuaName");
        string luaName = luaTable.Get<string>(m_FormName);
        GameManager.Lua.DoLuaFile(luaName);
        luaTable.Dispose();
        luaTable = null;

        //再调用LuaFormManager的方法
        m_FormManagerLuaTable = GameManager.Lua.GetClassLuaTable(m_FormManagerName, m_ManagerClass);
        if(m_FormManagerLuaTable != null)
        {
            GameManager.Lua.CallLuaFunction(m_FormManagerLuaTable,"Open",m_FormName,CachedTransform, userData);
        }

        base.OnOpen(userData);
    }

    protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);

        if (m_FormManagerLuaTable != null)
        {
            GameManager.Lua.CallLuaFunction(m_FormManagerLuaTable, "OnUpdate",m_FormName, elapseSeconds, realElapseSeconds);
        }
    }

    protected internal override void OnClose(object userData)
    {
        base.OnClose(userData);

        if (m_FormManagerLuaTable != null)
        {
            GameManager.Lua.CallLuaFunction(m_FormManagerLuaTable, "OnClose", m_FormName);
        }
    }

    protected override void OnOpenComplete()
    {
        base.OnOpenComplete();

        if (m_FormManagerLuaTable != null)
        {
            GameManager.Lua.CallLuaFunction(m_FormManagerLuaTable, "OnOpenComplete", m_FormName);
        }
    }

    public void OnDestroy()
    {
        if (m_FormManagerLuaTable != null)
        {
            GameManager.Lua.CallLuaFunction(m_FormManagerLuaTable, "OnDestroy", m_FormName);
        }
        m_FormManagerLuaTable.Dispose();
        m_FormManagerLuaTable = null;
    }


}
