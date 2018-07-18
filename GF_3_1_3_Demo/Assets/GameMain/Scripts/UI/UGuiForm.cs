﻿//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

public abstract class UGuiForm : UIFormLogic
{
    public const int DepthFactor = 100;
    private const float FadeTime = 0.3f;

    private static Font s_MainFont = null;
    private Canvas m_CachedCanvas = null;
    private CanvasGroup m_CanvasGroup = null;

    public int OriginalDepth
    {
        get;
        private set;
    }

    public int Depth
    {
        get
        {
            return m_CachedCanvas.sortingOrder;
        }
    }

    public void Close()
    {
        Close(false);
    }

    public void Close(bool ignoreFade)
    {
        StopAllCoroutines();

        if (ignoreFade)
        {
            GameManager.UI.CloseUIForm(this);
        }
        else
        {
            StartCoroutine(CloseCo(FadeTime));
        }
    }

    public void PlayUISound(int uiSoundId)
    {
        GameManager.Sound.PlayUISound(uiSoundId);
    }

    public static void SetMainFont(Font mainFont)
    {
        if (mainFont == null)
        {
            Log.Error("Main font is invalid.");
            return;
        }

        s_MainFont = mainFont;

        GameObject go = new GameObject();
        go.AddComponent<Text>().font = mainFont;
        Destroy(go);
    }

    protected internal override void OnInit(object userData)
    {
        base.OnInit(userData);

        m_CachedCanvas = gameObject.GetOrAddComponent<Canvas>();
        m_CachedCanvas.overrideSorting = true;
        OriginalDepth = m_CachedCanvas.sortingOrder;

        m_CanvasGroup = gameObject.GetOrAddComponent<CanvasGroup>();

        RectTransform transform = GetComponent<RectTransform>();
        transform.anchorMin = Vector2.zero;
        transform.anchorMax = Vector2.one;
        transform.anchoredPosition = Vector2.zero;
        transform.sizeDelta = Vector2.zero;

        gameObject.GetOrAddComponent<GraphicRaycaster>();

        Text[] texts = GetComponentsInChildren<Text>(true);
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].font = s_MainFont;
            if (!string.IsNullOrEmpty(texts[i].text))
            {
                texts[i].text = GameManager.Localization.GetString(texts[i].text);
            }
        }
    }

    protected internal override void OnOpen(object userData)
    {
        base.OnOpen(userData);

        m_CanvasGroup.alpha = 0f;
        StopAllCoroutines();
        StartCoroutine(m_CanvasGroup.FadeToAlpha(1f, FadeTime));
    }

    protected internal override void OnClose(object userData)
    {
        base.OnClose(userData);
    }

    protected internal override void OnPause()
    {
        base.OnPause();
    }

    protected internal override void OnResume()
    {
        base.OnResume();

        m_CanvasGroup.alpha = 0f;
        StopAllCoroutines();
        StartCoroutine(m_CanvasGroup.FadeToAlpha(1f, FadeTime));
    }

    protected internal override void OnCover()
    {
        base.OnCover();
    }

    protected internal override void OnReveal()
    {
        base.OnReveal();
    }

    protected internal override void OnRefocus(object userData)
    {
        base.OnRefocus(userData);
    }

    protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);
    }

    protected internal override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
    {
        int oldDepth = Depth;
        base.OnDepthChanged(uiGroupDepth, depthInUIGroup);
        int deltaDepth = UGuiGroupHelper.DepthFactor * uiGroupDepth + DepthFactor * depthInUIGroup - oldDepth + OriginalDepth;
        Canvas[] canvases = GetComponentsInChildren<Canvas>(true);
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].sortingOrder += deltaDepth;
        }
    }

    private IEnumerator CloseCo(float duration)
    {
        yield return m_CanvasGroup.FadeToAlpha(0f, duration);
        GameManager.UI.CloseUIForm(this);
    }
}
