//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework;
using GameFramework.DataTable;
using GameFramework.Procedure;
using GameFramework.UI;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

[XLua.LuaCallCSharp]
public static class UIExtension
{
    public static IEnumerator FadeToAlpha(this CanvasGroup canvasGroup, float alpha, float duration)
    {
        float time = 0f;
        float originalAlpha = canvasGroup.alpha;
        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(originalAlpha, alpha, time / duration);
            yield return new WaitForEndOfFrame();
        }

        canvasGroup.alpha = alpha;
    }

    public static IEnumerator FadeToScale(this RectTransform rectTransform,Vector3 endScale,float duration)
    {
        float time = 0f;
        Vector3 orginScale = rectTransform.localScale;
        Vector3 tweenScale;
        while(time < duration)
        {
            time += Time.deltaTime;
            tweenScale = new Vector3(Mathf.Lerp(orginScale.x, endScale.x, time / duration), Mathf.Lerp(orginScale.y, endScale.y, time / duration), 1);
            rectTransform.localScale = tweenScale;
            yield return new WaitForEndOfFrame();
        }
    }

    public static IEnumerator SmoothValue(this Slider slider, float value, float duration)
    {
        float time = 0f;
        float originalValue = slider.value;
        while (time < duration)
        {
            time += Time.deltaTime;
            slider.value = Mathf.Lerp(originalValue, value, time / duration);
            yield return new WaitForEndOfFrame();
        }

        slider.value = value;
    }

    public static bool HasUIForm(this UIComponent uiComponent, UIFormId uiFormId, string uiGroupName = null)
    {
        return uiComponent.HasUIForm((int)uiFormId, uiGroupName);
    }

    public static bool HasUIForm(this UIComponent uiComponent, int uiFormId, string uiGroupName = null)
    {
        IDataTable<DRUIForm> dtUIForm = GameManager.DataTable.GetDataTable<DRUIForm>();
        DRUIForm drUIForm = dtUIForm.GetDataRow(uiFormId);
        if (drUIForm == null)
        {
            return false;
        }

        string assetName = AssetUtility.GetUIFormAsset(drUIForm.AssetName);
        if (string.IsNullOrEmpty(uiGroupName))
        {
            return uiComponent.HasUIForm(assetName);
        }

        IUIGroup uiGroup = uiComponent.GetUIGroup(uiGroupName);
        if (uiGroup == null)
        {
            return false;
        }

        return uiGroup.HasUIForm(assetName);
    }

    public static NGuiForm GetUIForm(this UIComponent uiComponent, int uiFormId, string uiGroupName = null)
    {
        IDataTable<DRUIForm> dtUIForm = GameManager.DataTable.GetDataTable<DRUIForm>();
        DRUIForm drUIForm = dtUIForm.GetDataRow(uiFormId);
        if (drUIForm == null)
        {
            return null;
        }

        string assetName = AssetUtility.GetUIFormAsset(drUIForm.AssetName);
        UIForm uiForm = null;
        if (string.IsNullOrEmpty(uiGroupName))
        {
            uiForm = uiComponent.GetUIForm(assetName);
            if (uiForm == null)
            {
                Log.Info("Null11");
                return null;
            }

            return (NGuiForm)uiForm.Logic;
        }

        IUIGroup uiGroup = uiComponent.GetUIGroup(uiGroupName);
        if (uiGroup == null)
        {
            return null;
        }

        uiForm = (UIForm)uiGroup.GetUIForm(assetName);
        if (uiForm == null)
        {
            return null;
        }

        return (NGuiForm)uiForm.Logic;
    }

    public static NGuiForm GetUIForm(this UIComponent uiComponent, UIFormId uiFormId, string uiGroupName = null)
    {
        return uiComponent.GetUIForm((int)uiFormId, uiGroupName);
    }

    public static void CloseUIForm(this UIComponent uiComponent, NGuiForm uiForm)
    {
        uiComponent.CloseUIForm(uiForm.UIForm);
    }


    public static void CloseUIForm(this UIComponent uiComponent, UIFormId uiFormId)
    {
        NGuiForm uiForm = uiComponent.GetUIForm(uiFormId);
        uiComponent.CloseUIForm(uiForm);
    }

    public static void CloseUIForm(this UIComponent uiComponent,string uiFormId)
    {
        UIFormId formId = (UIFormId)Enum.Parse(typeof(UIFormId), uiFormId);

        CloseUIForm(uiComponent,formId);
    }


    public static int? OpenUIForm(this UIComponent uiComponent,string uiFormId,object userData = null)
    {
        UIFormId formId = (UIFormId)Enum.Parse(typeof(UIFormId), uiFormId);
        return uiComponent.OpenUIForm(formId,userData);
    }

    public static int? OpenUIForm(this UIComponent uiComponent, UIFormId uiFormId, object userData = null)
    {
        return uiComponent.OpenUIForm((int)uiFormId, userData);
    }

    public static int? OpenUIForm(this UIComponent uiComponent, int uiFormId, object userData = null)
    {
        IDataTable<DRUIForm> dtUIForm = GameManager.DataTable.GetDataTable<DRUIForm>();
        DRUIForm drUIForm = dtUIForm.GetDataRow(uiFormId);
        if (drUIForm == null)
        {
            Log.Warning("Can not load UI form '{0}' from data table.", uiFormId.ToString());
            return null;
        }

        string assetName = AssetUtility.GetUIFormAsset(drUIForm.AssetName);
        if (!drUIForm.AllowMultiInstance)
        {
            if (uiComponent.IsLoadingUIForm(assetName))
            {
                return null;
            }

            if (uiComponent.HasUIForm(assetName))
            {
                return null;
            }
        }

        return uiComponent.OpenUIForm(assetName, drUIForm.UIGroupName, drUIForm.PauseCoveredUIForm, userData);
    }

    /// <summary>
    /// 打开对话框
    /// </summary>
    /// <param name="uiComponent"></param>
    /// <param name="dialogParams"></param>
    public static void OpenDialog(this UIComponent uiComponent, DialogParams dialogParams)
    {
        uiComponent.OpenUIForm(UIFormId.DialogForm, dialogParams);
    }
}
