//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------


using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// NGUI 界面组辅助器
/// </summary>
public class NGuiGroupHelper : UIGroupHelperBase
{
    public const int DepthFactor = 10000;

    private int m_Depth = 0;
    private UIPanel m_CachedPanel = null;

    /// <summary>
    /// 设置界面组深度。
    /// </summary>
    /// <param name="depth">界面组深度。</param>
    public override void SetDepth(int depth)
    {
        m_Depth = depth;
        m_CachedPanel.depth = DepthFactor * depth;
    }

    private void Awake()
    {
        m_CachedPanel = gameObject.GetOrAddComponent<UIPanel>();
    }

    private void Start()
    {
        m_CachedPanel.sortingOrder = DepthFactor * m_Depth;
    }
}
