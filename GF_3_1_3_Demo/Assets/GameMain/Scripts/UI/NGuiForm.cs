//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
using DG.Tweening;

/// <summary>
/// NGUI 界面（基类）
/// </summary>
public abstract class NGuiForm : UIFormLogic
{
    public const int DepthFactor = 100;
    private static UIFont s_MainFont = null;

    private UIPanel m_UIPanel;

    /// <summary>
    /// 打开/关闭缓动方式
    /// </summary>
    public UITweenType TweenType
    {
        protected set;
        get;
    }

    /// <summary>
    /// 缓动时间
    /// </summary>
    public float TweenDuration
    {
        protected set;
        get;
    }

    public int OriginalDepth
    {
        private set;
        get;
    }

    public int Depth
    {
        get
        {
            return m_UIPanel.depth;
        }
    }

    public UIWidget BackgroundWidget
    {
        protected set;
        get;
    }

    public void Close()
    {
        Close(false);
    }

    public void Close(bool ignoreTween)
    {
        if(ignoreTween)
        {
            GameManager.UI.CloseUIForm(this);
        }else
        {
            PlayCloseTween();
        }
    }

    public void PlayUISound(int uiSoundId)
    {
        GameManager.Sound.PlayUISound(uiSoundId);
    }

    public static void SetMainFont(UIFont mainFont)
    {
        if (mainFont == null)
        {
            Log.Error("Main font is invalid.");
            return;
        }

        s_MainFont = mainFont;

        GameObject go = new GameObject();
        go.AddComponent<UILabel>().bitmapFont = mainFont;
        Destroy(go);
    }

    protected internal override void OnInit(object userData)
    {
        base.OnInit(userData);

        //界面命名
        Name = CachedTransform.name.Replace("(Clone)", "");

        if (TweenDuration <= 0)
            TweenDuration = 0.3f;

        m_UIPanel = gameObject.GetOrAddComponent<UIPanel>();
        OriginalDepth = m_UIPanel.depth;

        //缓动对象
        Transform bgTrans = null;
        bgTrans = CachedTransform.Find("Background");
        if(bgTrans != null)
        {
            BackgroundWidget = bgTrans.GetComponent<UIWidget>();
        }

        ////打开启动界面时，由于字体还未加载出来，使用默认字体
        if (Name != UIFormId.LaunchForm.ToString())
        {
            UILabel[] texts = GetComponentsInChildren<UILabel>(true);
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].bitmapFont = s_MainFont;
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

        if(BackgroundWidget != null)
        {
            PlayOpenTween();
        }else
        {
            OnOpenComplete();
        }
    }

    protected virtual void OnOpenComplete()
    {

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

    protected internal override void OnClose(object userData)
    {
        base.OnClose(userData);
    }


    protected internal override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
    {
        int oldDepth = Depth;
        base.OnDepthChanged(uiGroupDepth, depthInUIGroup);
        int deltaDepth = NGuiGroupHelper.DepthFactor * uiGroupDepth + DepthFactor * depthInUIGroup - oldDepth + OriginalDepth;
        
        UIPanel[] panels = GetComponentsInChildren<UIPanel>();
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].depth += deltaDepth;
        }
    }

    private void PlayOpenTween()
    {
        switch(TweenType)
        {
            case UITweenType.Fade:
                BackgroundWidget.alpha = 0;
                DOTween.To(
                    () => BackgroundWidget.alpha,
                    (x)=>{BackgroundWidget.alpha = x;},
                    1,
                    TweenDuration
                    ).OnComplete(
                        ()=>{ OnOpenComplete();}
                    );
                break;
            case UITweenType.Scale:
                BackgroundWidget.transform.localScale = Vector3.zero;
                BackgroundWidget.transform.DOScale(Vector3.one, TweenDuration).OnComplete(() => { OnOpenComplete(); });
                break;
            default:
                OnOpenComplete();
                break;
        }
    }

    private void PlayCloseTween()
    {
        switch(TweenType)
        {
            case UITweenType.Fade:
                DOTween.To(
                    () => BackgroundWidget.alpha,
                    (x)=>{BackgroundWidget.alpha = x;},
                    0,
                    TweenDuration
                    ).OnComplete(
                        ()=>{ GameManager.UI.CloseUIForm(this);}
                    );
                break;
            case UITweenType.Scale:
                BackgroundWidget.transform.DOScale(Vector3.zero, TweenDuration).OnComplete(() => { GameManager.UI.CloseUIForm(this); });
                break;
            default:
                GameManager.UI.CloseUIForm(this);
                break;
        }
    }
}