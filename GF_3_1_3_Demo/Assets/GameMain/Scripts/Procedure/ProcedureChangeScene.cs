//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Event;
using UnityGameFramework.Runtime;
using GameFramework.DataTable;
using GameFramework;

/// <summary>
/// 切换场景流程
/// </summary>
public class ProcedureChangeScene : GameProcedureBase
{
    private bool m_IsChangeSceneComplete = false;
    //private int m_BackgroundMusicId = 0;

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        m_IsChangeSceneComplete = false;

        GameManager.Event.Subscribe(LoadSceneSuccessEventArgs.EventId, OnLoadSceneSuccess);
        GameManager.Event.Subscribe(LoadSceneFailureEventArgs.EventId, OnLoadSceneFailure);
        GameManager.Event.Subscribe(LoadSceneUpdateEventArgs.EventId, OnLoadSceneUpdate);
        GameManager.Event.Subscribe(LoadSceneDependencyAssetEventArgs.EventId, OnLoadSceneDependencyAsset);
        GameManager.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId,OnOpenUIFormSuccess);

        // 停止所有声音
        GameManager.Sound.StopAllLoadingSounds();
        GameManager.Sound.StopAllLoadedSounds();

        // 隐藏所有实体
        GameManager.Entity.HideAllLoadingEntities();
        GameManager.Entity.HideAllLoadedEntities();

        // 卸载所有场景
        string[] loadedSceneAssetNames = GameManager.Scene.GetLoadedSceneAssetNames();
        for (int i = 0; i < loadedSceneAssetNames.Length; i++)
        {
            GameManager.Scene.UnloadScene(loadedSceneAssetNames[i]);
        }

        // 还原游戏速度
        GameManager.Base.ResetNormalGameSpeed();

        GameManager.UI.OpenUIForm(UIFormId.LoadingForm,UIFormId.LoadingForm);
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        GameManager.Event.Unsubscribe(LoadSceneSuccessEventArgs.EventId, OnLoadSceneSuccess);
        GameManager.Event.Unsubscribe(LoadSceneFailureEventArgs.EventId, OnLoadSceneFailure);
        GameManager.Event.Unsubscribe(LoadSceneUpdateEventArgs.EventId, OnLoadSceneUpdate);
        GameManager.Event.Unsubscribe(LoadSceneDependencyAssetEventArgs.EventId, OnLoadSceneDependencyAsset);
        GameManager.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

        base.OnLeave(procedureOwner, isShutdown);
    }

    private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
    {
        OpenUIFormSuccessEventArgs evt = (OpenUIFormSuccessEventArgs)e;

        if((UIFormId)evt.UserData == UIFormId.LoadingForm)
        {
            int sceneId = ProcedureOwner.GetData<VarInt>(Const.ProcedureDataKey.NextSceneId).Value;
            IDataTable<DRScene> dtScene = GameManager.DataTable.GetDataTable<DRScene>();
            DRScene drScene = dtScene.GetDataRow(sceneId);
            if (drScene == null)
            {
                Log.Warning("Can not load scene '{0}' from data table.", sceneId.ToString());
                return;
            }
            GameManager.Scene.LoadScene(AssetUtility.GetSceneAsset(drScene.AssetName), this);
            //m_BackgroundMusicId = drScene.BgmId;
        }

    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (!m_IsChangeSceneComplete)
        {
            return;
        }

        ChangeState<ProcedureCity>(procedureOwner);
    }

    private void OnLoadSceneSuccess(object sender, GameEventArgs e)
    {
        LoadSceneSuccessEventArgs ne = (LoadSceneSuccessEventArgs)e;
        if (ne.UserData != this)
        {
            return;
        }

        Log.Info("Load scene '{0}' OK.", ne.SceneAssetName);

        //if (m_BackgroundMusicId > 0)

        //{
        //    GameManager.Sound.PlayMusic(m_BackgroundMusicId);
        //}

        GameManager.UI.CloseUIForm(UIFormId.LoadingForm);

        m_IsChangeSceneComplete = true;
    }

    private void OnLoadSceneFailure(object sender, GameEventArgs e)
    {
        LoadSceneFailureEventArgs ne = (LoadSceneFailureEventArgs)e;
        if (ne.UserData != this)
        {
            return;
        }

        Log.Error("Load scene '{0}' failure, error message '{1}'.", ne.SceneAssetName, ne.ErrorMessage);
    }

    private void OnLoadSceneUpdate(object sender, GameEventArgs e)
    {
        LoadSceneUpdateEventArgs ne = (LoadSceneUpdateEventArgs)e;
        if (ne.UserData != this)
        {
            return;
        }

        Log.Info("Load scene '{0}' update, progress '{1}'.", ne.SceneAssetName, ne.Progress.ToString("P2"));
    }

    private void OnLoadSceneDependencyAsset(object sender, GameEventArgs e)
    {
        LoadSceneDependencyAssetEventArgs ne = (LoadSceneDependencyAssetEventArgs)e;
        if (ne.UserData != this)
        {
            return;
        }

        Log.Info("Load scene '{0}' dependency asset '{1}', count '{2}/{3}'.", ne.SceneAssetName, ne.DependencyAssetName, ne.LoadedCount.ToString(), ne.TotalCount.ToString());
    }
}

