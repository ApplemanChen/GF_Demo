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


/// <summary>
/// 菜单界面
/// </summary>
public class MenuForm : UGuiForm
{
    private Button _btn;
    private ProcedureMenu _procedure;

    protected internal override void OnInit(object userData)
    {
        base.OnInit(userData);

        _procedure = (ProcedureMenu)userData;

        _btn = CachedTransform.Find("Panel/Button").GetComponent<Button>();
        _btn.onClick.AddListener(OnBtnClick);
    }

    private void OnBtnClick()
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