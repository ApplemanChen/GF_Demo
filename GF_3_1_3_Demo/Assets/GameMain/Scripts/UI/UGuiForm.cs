//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

#if UGUI

using GameFramework;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

public abstract class UGuiForm : UIFormLogic
{
    public const int DepthFactor = 100;
    private const float FadeTime = 0.5f;

    private static Font s_MainFont = null;
    private Canvas m_CachedCanvas = null;
    private CanvasGroup m_CanvasGroup = null;
    private RectTransform m_RectTrans = null;
    private RectTransform m_BackgroundRectTrans = null;

    protected UITweenType m_TweenType = UITweenType.Fade;

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

    public RectTransform RectTrans
    {
        get
        {
            return m_RectTrans;
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
            StartCoroutine(PlayCloseTween(FadeTime));
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

        //界面命名
        Name = CachedTransform.name.Replace("(Clone)","");

        m_CachedCanvas = gameObject.GetOrAddComponent<Canvas>();
        m_CachedCanvas.overrideSorting = true;
        OriginalDepth = m_CachedCanvas.sortingOrder;

        m_CanvasGroup = gameObject.GetOrAddComponent<CanvasGroup>();

        RectTransform transform = GetComponent<RectTransform>();
        m_RectTrans = transform;
        transform.anchorMin = Vector2.zero;
        transform.anchorMax = Vector2.one;
        transform.anchoredPosition = Vector2.zero;
        transform.sizeDelta = Vector2.zero;

        Transform bgTrans = CachedTransform.Find("Mask/Background");
        if (bgTrans)
        {
            m_BackgroundRectTrans = bgTrans.GetComponent<RectTransform>();
        }

        gameObject.GetOrAddComponent<GraphicRaycaster>();

        //打开启动界面时，由于字体还未加载出来，使用默认字体
        if(Name !=UIFormId.LaunchForm.ToString())
        {
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

    }

    protected internal override void OnOpen(object userData)
    {
        base.OnOpen(userData);

        PlayOpenTween();
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
    
    protected virtual void OnOpenComplete()
    {
        switch(m_TweenType)
        {
            case UITweenType.Fade:
                m_CanvasGroup.alpha = 1f;
                break;
            case UITweenType.Scale:
                m_BackgroundRectTrans.localScale = Vector3.one;
                break;
        }
    }

    private IEnumerator PlayCloseTween(float duration)
    {

        switch (m_TweenType)
        {
            case UITweenType.Fade:
                {
                    yield return m_CanvasGroup.FadeToAlpha(0f, FadeTime);
                }
                break;
            case UITweenType.Scale:
                {
                    if (m_BackgroundRectTrans)
                    {
                        yield return m_BackgroundRectTrans.FadeToScale(Vector3.one * 0.1f, FadeTime);
                    }
                }
                break;
        }

        GameManager.UI.CloseUIForm(this);
    }

    private void PlayOpenTween()
    {
        StopAllCoroutines();

        switch (m_TweenType)
        {
            case UITweenType.Fade:
                {
                    m_CanvasGroup.alpha = 0f;
                    StartCoroutine(OpenByAlpha());
                }
                break;
            case UITweenType.Scale:
                {
                    if (m_BackgroundRectTrans)
                    {
                        m_BackgroundRectTrans.localScale = Vector3.one * 0.1f;
                        StartCoroutine(OpenByScale());
                    }
                }
                break;
        }
    }

    private IEnumerator OpenByAlpha()
    {
        yield return  m_CanvasGroup.FadeToAlpha(1f, FadeTime);
        OnOpenComplete();
    }

    private IEnumerator OpenByScale()
    {
        yield return m_BackgroundRectTrans.FadeToScale(Vector3.one, FadeTime);
        OnOpenComplete();
    }
}

#endif