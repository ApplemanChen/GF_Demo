//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using GameFramework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 通用对话框
/// </summary>
public class DialogForm : NGuiForm
{
    private UILabel _titleText;
    private UILabel _messageText;
    private GameObject _curShowBtnGroup;

    //数据
    private DialogParams _dialogParams;
    private object _userData;

    protected internal override void OnInit(object userData)
    {
        base.OnInit(userData);

        TweenType = UITweenType.Scale;
        

        _dialogParams = (DialogParams)userData;
        _userData = _dialogParams.UserData;

        for (int i = 1; i <=3;i++ )
        {
            GameObject go = CachedTransform.Find("Background/ButtonGroup" + i).gameObject;
            go.SetActive(i==_dialogParams.Mode);
            if(i == _dialogParams.Mode)
            {
                _curShowBtnGroup = go;
            }
        }

        _titleText = CachedTransform.Find("Background/TitleBar/Label").GetComponent<UILabel>();
        _messageText = CachedTransform.Find("Background/Message").GetComponent<UILabel>();
    }

    protected internal override void OnOpen(object userData)
    {
        base.OnOpen(userData);

        _titleText.text = _dialogParams.Title;
        _messageText.text = _dialogParams.Message;
        RefreshBtnGroup();
    }

    private void RefreshBtnGroup()
    {
        if (_curShowBtnGroup == null)
            return;

        Transform btnConfirm;
        Transform btnCancel;
        Transform btnOther;

        btnConfirm = _curShowBtnGroup.transform.Find("ButtonConfirm");
        btnCancel = _curShowBtnGroup.transform.Find("ButtonCancel");
        btnOther = _curShowBtnGroup.transform.Find("ButtonOther");

        if(btnConfirm!= null)
        {
            UIEventListener.Get(btnConfirm.gameObject).onClick = OnBtnConfirmClick;

            UILabel txtConfirm = btnConfirm.transform.Find("Label").GetComponent<UILabel>();
            if(string.IsNullOrEmpty(_dialogParams.ConfirmText))
            {
                txtConfirm.text = GameManager.Localization.GetString("Dialog.ConfirmButton");
            }else
            {
                txtConfirm.text = _dialogParams.ConfirmText;
            }
        }

        if (btnCancel != null)
        {
            UIEventListener.Get(btnCancel.gameObject).onClick = OnBtnCancelClick;

            UILabel txtCancel = btnCancel.transform.Find("Label").GetComponent<UILabel>();
            if (string.IsNullOrEmpty(_dialogParams.CancelText))
            {
                txtCancel.text = GameManager.Localization.GetString("Dialog.CancelButton");
            }
            else
            {
                txtCancel.text = _dialogParams.CancelText;
            }
        }

        if (btnOther != null)
        {
            UIEventListener.Get(btnOther.gameObject).onClick = OnBtnOtherClick;

            UILabel txtOther = btnOther.transform.Find("Label").GetComponent<UILabel>();
            if (string.IsNullOrEmpty(_dialogParams.OtherText))
            {
                txtOther.text = GameManager.Localization.GetString("Dialog.OtherButton");
            }
            else
            {
                txtOther.text = _dialogParams.OtherText;
            }
        }
    }

    private void OnBtnConfirmClick(GameObject go)
    {
        Close();

        if (_dialogParams != null && _dialogParams.OnClickConfirm != null)
        {
            _dialogParams.OnClickConfirm(_userData);
        }
    }

    private void OnBtnCancelClick(GameObject go)
    {
        Close();

        if (_dialogParams != null && _dialogParams.OnClickCancel != null)
        {
            _dialogParams.OnClickCancel(_userData);
        }
    }

    private void OnBtnOtherClick(GameObject go)
    {
        Close();

        if (_dialogParams != null && _dialogParams.OnClickOther != null)
        {
            _dialogParams.OnClickOther(_userData);
        }
    }
}
