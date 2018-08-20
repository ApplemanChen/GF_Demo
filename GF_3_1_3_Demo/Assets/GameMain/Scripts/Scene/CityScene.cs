//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using GameFramework;
using UnityGameFramework.Runtime;
using UnityEngine;

/// <summary>
/// 主城场景
/// </summary>
public class CityScene : SceneBase
{
    private Camera m_SceneCamera;

    public CityScene(int sceneId):base(sceneId)
    {

    }

    public override SceneType SceneType
    {
        get { return SceneType.City; }
    }

    protected override void OnInit()
    {
        Log.Info("SceneName:"+SceneName);

        ResetMainCamera();
    }

    protected override void OnEnter()
    {
        //TODO:加载主角
        GameManager.Entity.ShowPlayer(new PlayerData(GameManager.Entity.GenerateSerialId(), 10001));
    }

    protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {

    }

    protected override void OnExit()
    {

    }

    private void ResetMainCamera()
    {
        //用主相机替代场景摄像机

        GameObject sceneCameraGo = GameObject.Find("SceneCamera");
        if (sceneCameraGo == null)
        {
            Log.Error("CityScene: => {0}.unity中没有SceneCamera的摄像机对象! 请检查!", SceneName);
            return;
        }

        m_SceneCamera = sceneCameraGo.GetComponent<Camera>();
        if (m_SceneCamera == null)
        {
            Log.Error("CityScene: => {0}.unity中SceneCamera没有挂组件Camera! 请检查!");
            return;
        }

        m_SceneCamera.gameObject.SetActive(true);

        Camera mainCamera = GameManager.Camera.GetCamera(CameraLayer.Main);
        mainCamera.transform.position = m_SceneCamera.transform.position;
        mainCamera.transform.localRotation = m_SceneCamera.transform.localRotation;
        mainCamera.nearClipPlane = m_SceneCamera.nearClipPlane;
        mainCamera.farClipPlane = m_SceneCamera.farClipPlane;
        mainCamera.orthographicSize = m_SceneCamera.orthographicSize;
        mainCamera.orthographic = m_SceneCamera.orthographic;

        //禁用场景内的摄像机
        m_SceneCamera.gameObject.SetActive(false);
    }
}
