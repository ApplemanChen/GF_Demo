//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework;
using GameFramework.DataTable;
using UnityGameFramework.Runtime;

public static class SceneExtension
{
    /// <summary>
    /// 获取场景配置数据
    /// </summary>
    /// <param name="sceneComponent"></param>
    /// <param name="sceneId"></param>
    public static DRScene GetDRScene(this SceneComponent sceneComponent, int sceneId)
    {
        IDataTable<DRScene> dtScene = GameManager.DataTable.GetDataTable<DRScene>();
        DRScene drScene = dtScene.GetDataRow(sceneId);
        if (drScene == null)
        {
            Log.Warning("Can not load scene '{0}' from data table.", sceneId.ToString());
            return null;
        }

        return drScene;
    }

    /// <summary>
    /// 获取场景名
    /// </summary>
    /// <param name="sceneComponent"></param>
    /// <param name="sceneId"></param>
    /// <returns></returns>
    public static string GetSceneName(this SceneComponent sceneComponent,int sceneId)
    {
        DRScene drScene = sceneComponent.GetDRScene(sceneId);
        if(drScene != null)
        {
            return drScene.AssetName;
        }

        return "";
    }
}