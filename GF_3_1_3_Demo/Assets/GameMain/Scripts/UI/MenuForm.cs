//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using GameFramework;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using GameFramework.Event;

/// <summary>
/// 菜单界面
/// </summary>
public class MenuForm : NGuiForm
{
    private UIButton _btn;
    private ProcedureMenu _procedure;

    protected internal override void OnInit(object userData)
    {
        base.OnInit(userData);

        _procedure = (ProcedureMenu)userData;

        _btn = CachedTransform.Find("Button").GetComponent<UIButton>();
        UIEventListener.Get(_btn.gameObject).onClick = OnBtnClick;

        //GameManager.Event.Subscribe(LuaEventId.TestLuaEvent,OnLuaEventSend);
    }

    //private void OnLuaEventSend(object sender, GameEventArgs e)
    //{
    //    LuaSendEventArgs evt = (LuaSendEventArgs)e;

    //    Log.Info("C# receive:{0}",evt.Sender);
    //    Log.Info("C# receive:{0}", evt.Param[1]);
    //}

    protected internal override void OnOpen(object userData)
    {
        base.OnOpen(userData);

        //GameManager.UI.OpenUIForm(UIFormId.LoginForm,new object[] { "aaa","bbb"});
    }

    private void OnBtnClick(GameObject go)
    {
        GameManager.UI.OpenDialog(new DialogParams()
        {
            Mode = 2,
            Title = GameManager.Localization.GetString("Dialog.Title"),
            Message = GameManager.Localization.GetString("Dialog.EnterMessage"),
            OnClickConfirm = OnDialogConfirm,
        });
    }

    private void OnDialogConfirm(object userData)
    {
        _procedure.IsEnterScene = true;
    }
}