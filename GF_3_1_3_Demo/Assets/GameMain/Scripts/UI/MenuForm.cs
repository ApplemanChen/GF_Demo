//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using GameFramework;
using UnityEngine.UI;


/// <summary>
/// 菜单界面
/// </summary>
public class MenuForm : UGuiForm
{
    private Button _btn;

    protected internal override void OnInit(object userData)
    {
        base.OnInit(userData);

        _btn = CachedTransform.Find("Panel/Button").GetComponent<Button>();

        _btn.onClick.AddListener(OnBtnClick);
    }

    private void OnBtnClick()
    {
        Log.Info("Button Click!!");   
    }
}