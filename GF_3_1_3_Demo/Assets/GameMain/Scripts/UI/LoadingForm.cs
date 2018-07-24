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
public class LoadingForm : UGuiForm
{
    private Slider m_Slider;
    private Text m_PercentText;

    protected internal override void OnInit(object userData)
    {
        base.OnInit(userData);

        m_TweenType = UITweenType.None;

        GameManager.Event.Subscribe(LoadSceneUpdateEventArgs.EventId, OnLoadSceneUpdate);

        m_Slider = CachedTransform.Find("Panel/Slider").GetComponent<Slider>();
        m_Slider.value = 0;
        m_PercentText = CachedTransform.Find("Panel/Percent").GetComponent<Text>();
    }

    protected internal override void OnOpen(object userData)
    {
        base.OnOpen(userData);

        m_PercentText.text = "";
    }

    protected internal override void OnClose(object userData)
    {
        GameManager.Event.Unsubscribe(LoadSceneUpdateEventArgs.EventId, OnLoadSceneUpdate);

        m_Slider = null;
        m_PercentText = null;

        base.OnClose(userData);
    }

    public void UpdatePercent(float value)
    {
        m_PercentText.text = GameManager.Localization.GetString("Loading.Progress", value.ToString("P2"));
        m_Slider.value = value;
    }

    private void OnLoadSceneUpdate(object sender, GameEventArgs e)
    {
        LoadSceneUpdateEventArgs ne = (LoadSceneUpdateEventArgs)e;

        UpdatePercent(ne.Progress);

        //if(ne.Progress >= 1f)
        //{
        //    Close();
        //}
    }
}
