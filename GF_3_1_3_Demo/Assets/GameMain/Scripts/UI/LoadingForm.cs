//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using UnityGameFramework.Runtime;
using UnityEngine.UI;
using GameFramework;
using GameFramework.Event;

/// <summary>
/// 加载界面
/// </summary>
public class LoadingForm : NGuiForm
{
    private UISlider m_Slider;

    protected internal override void OnInit(object userData)
    {
        base.OnInit(userData);

        TweenType = UITweenType.None;

        GameManager.Event.Subscribe(LoadSceneUpdateEventArgs.EventId, OnLoadSceneUpdate);

        m_Slider = CachedTransform.Find("Slider").GetComponent<UISlider>();
        m_Slider.value = 0;
    }

    protected internal override void OnOpen(object userData)
    {
        base.OnOpen(userData);
    }

    protected internal override void OnClose(object userData)
    {
        GameManager.Event.Unsubscribe(LoadSceneUpdateEventArgs.EventId, OnLoadSceneUpdate);

        m_Slider = null;
        base.OnClose(userData);
    }

    public void UpdatePercent(float value)
    {
        m_Slider.value = value;
    }

    private void OnLoadSceneUpdate(object sender, GameEventArgs e)
    {
        LoadSceneUpdateEventArgs ne = (LoadSceneUpdateEventArgs)e;

        UpdatePercent(ne.Progress);
    }
}
