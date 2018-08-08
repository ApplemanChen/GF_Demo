//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework;
using UnityGameFramework.Runtime;
using UnityEngine.UI;

/// <summary>
/// 启动窗口
/// </summary>
public class LaunchForm : NGuiForm
{
    private UILabel m_Text;

    protected internal override void OnInit(object userData)
    {
        base.OnInit(userData);

        TweenType = UITweenType.None;

        m_Text = CachedTransform.Find("Label").GetComponent<UILabel>();
    }

    private void OnUpdateTips(object sender, GameFramework.Event.GameEventArgs e)
    {
        LaunchFormUpdateTipsEventArgs evt = (LaunchFormUpdateTipsEventArgs)e;

        m_Text.text = evt.Tips;
    }

    protected internal override void OnOpen(object userData)
    {
        base.OnOpen(userData);

        GameManager.Event.Subscribe(LaunchFormUpdateTipsEventArgs.EventId, OnUpdateTips);
    }

    protected override void OnOpenComplete()
    {
        base.OnOpenComplete();
    }

    protected internal override void OnClose(object userData)
    {
        GameManager.Event.Unsubscribe(LaunchFormUpdateTipsEventArgs.EventId, OnUpdateTips);

        base.OnClose(userData);
    }
}
