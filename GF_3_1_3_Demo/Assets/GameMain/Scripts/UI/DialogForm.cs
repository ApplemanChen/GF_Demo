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

public class DialogForm : UGuiForm
{
    private Text _titleText;
    private Text _messageText;
    private GameObject _curShowBtnGroup;

    //数据
    private DialogParams _dialogParams;
    private object _userData;

    protected internal override void OnInit(object userData)
    {
        base.OnInit(userData);

        m_TweenType = UITweenType.Scale;

        _dialogParams = (DialogParams)userData;
        _userData = _dialogParams.UserData;

        for (int i = 1; i <=3;i++ )
        {
            GameObject go = CachedTransform.Find("Mask/Background/ButtonGroup" + i).gameObject;
            go.SetActive(i==_dialogParams.Mode);
            if(i == _dialogParams.Mode)
            {
                _curShowBtnGroup = go;
            }
        }

        _titleText = CachedTransform.Find("Mask/Background/TitleBar/Text").GetComponent<Text>();
        _messageText = CachedTransform.Find("Mask/Background/Message").GetComponent<Text>();
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
            btnConfirm.GetComponent<Button>().onClick.AddListener(OnBtnConfirmClick);

            Text txtConfirm = btnConfirm.transform.Find("Text").GetComponent<Text>();
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
            btnCancel.GetComponent<Button>().onClick.AddListener(OnBtnCancelClick);

            Text txtCancel = btnCancel.transform.Find("Text").GetComponent<Text>();
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
            btnOther.GetComponent<Button>().onClick.AddListener(OnBtnOtherClick);

            Text txtOther = btnOther.transform.Find("Text").GetComponent<Text>();
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

    private void OnBtnConfirmClick()
    {
        Close();

        if (_dialogParams != null && _dialogParams.OnClickConfirm != null)
        {
            _dialogParams.OnClickConfirm(_userData);
        }
    }

    private void OnBtnCancelClick()
    {
        Close();

        if (_dialogParams != null && _dialogParams.OnClickCancel != null)
        {
            _dialogParams.OnClickCancel(_userData);
        }
    }

    private void OnBtnOtherClick()
    {
        Close();

        if (_dialogParams != null && _dialogParams.OnClickOther != null)
        {
            _dialogParams.OnClickOther(_userData);
        }
    }
}
