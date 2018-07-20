//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;
using System;

/// <summary>
/// 相机全局组件
/// </summary>
[DisallowMultipleComponent]
[AddComponentMenu("Game Framework/Custom/Camera")]
public sealed class CameraComponent : GameFrameworkComponent
{
    private IDictionary<CameraLayer, Camera> m_CameraDict;


    protected override void Awake()
    {
        base.Awake();
        
        m_CameraDict = new Dictionary<CameraLayer,Camera>();
    }

    void Start()
    {
        foreach(CameraLayer layer in Enum.GetValues(typeof(CameraLayer)))
        {
            Transform trans = transform.Find(layer.ToString()+"Camera");
            if(trans == null)
            {
                Log.Warning(string.Format("Camera component can't find the camera game object. The layer is {0}",layer.ToString()));
                return;
            }

            Camera camera = trans.GetComponent<Camera>();

            if(camera == null)
            {
                Log.Warning(string.Format("Camera component has a game object with no camera. The game object name is {0}.",trans.name));
                return;
            }

            m_CameraDict.Add(layer, camera);
        }

    }

    /// <summary>
    /// 获取某个相机
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Camera GetCamera(CameraLayer layer)
    {
        Camera camera = null;
        if (m_CameraDict.TryGetValue(layer, out camera))
        {
            return camera;
        }else
        {
            Log.Warning("The camera name is invalid.");
            return null;
        }
    }

    /// <summary>
    /// 禁用摄像机
    /// </summary>
    /// <param name="layer"></param>
    public void HideCamera(CameraLayer layer)
    {
        GetCamera(layer).enabled = false;
    }

    /// <summary>
    /// 弃用摄像机
    /// </summary>
    /// <param name="layer"></param>
    public void ShowCamera(CameraLayer layer)
    {
        GetCamera(layer).enabled = true;
    }
}
