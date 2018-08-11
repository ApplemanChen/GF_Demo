//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework;
using GameFramework.Event;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
using XLua;

/// <summary>
/// Lua调用的常用方法 ( 需要Wrap!)
/// </summary>
public class LuaCallStatic
{
    public static void LuaCloseForm(string uiFormId)
    {
        GameManager.UI.CloseUIForm(uiFormId);
    }

    public static void LuaOpenForm(string uiFormId,object userData = null)
    {
        GameManager.UI.OpenUIForm(uiFormId,userData);
    }

    public static void AddButtonClick(GameObject go, UIEventListener.VoidDelegate onBtnClick)
    {
        UIEventListener.Get(go).onClick += onBtnClick;
    }

    public static void RemoveButtonClick(GameObject go, UIEventListener.VoidDelegate onBtnClick)
    {
        UIEventListener.Get(go).onClick -= onBtnClick; 
    }

    public static void AddButtonClick(GameObject go, UnityAction onBtnClick)
    {
        Button btn = go.GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(onBtnClick);
        }
        else
        {
            Log.Error("LuaCallStatic => GameObject '{0}' not have Button Component !", go.name);
        }
    }

    public static void RemoveButtonClick(GameObject go, UnityAction onBtnClick)
    {
        Button btn = go.GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.RemoveListener(onBtnClick);
            btn.onClick = null;
        }
        else
        {
            Log.Error("LuaCallStatic => GameObject '{0}' not have Button Component !", go.name);
        }
    }

    public static void AddEvent(int eventId, EventHandler<GameEventArgs> onEventHandler)
    {
        GameManager.Event.Subscribe(eventId, onEventHandler);
    }

    public static void RemoveEvent(int eventId, EventHandler<GameEventArgs> onEventHandler)
    {
        GameManager.Event.Unsubscribe(eventId, onEventHandler);
    }

    public static void FireEvent(int eventId,string sender,object[] param)
    {
        GameManager.Event.Fire(sender, ReferencePool.Acquire<LuaSendEventArgs>().Fill(eventId,sender,param));
    }
}