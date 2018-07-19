//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;

/// <summary>
/// 相机全局组件
/// </summary>
[DisallowMultipleComponent]
[AddComponentMenu("Game Framework/Custom/Camera")]
public sealed class CameraComponent : GameFrameworkComponent
{
    private IDictionary<string, Camera> m_CameraDict;


    protected override void Awake()
    {
        base.Awake();
        
        m_CameraDict = new Dictionary<string,Camera>();
    }

    void Start()
    {
        Camera[] cameras = transform.GetComponentsInChildren<Camera>(true);
        int len = cameras.Length;
        for (int i = 0; i < len;i++ )
        {
            m_CameraDict.Add(cameras[i].name,cameras[i]);
        }
    }

    /// <summary>
    /// 获取某个相机
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Camera GetCamera(string name)
    {
        Camera camera = null;
        if(m_CameraDict.TryGetValue(name,out camera))
        {
            return camera;
        }else
        {
            Log.Warning("The camera name is invalid.");
            return null;
        }
    }
}
