//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework;
using GameFramework.DataTable;
using System;
using System.Collections.Generic;
using UnityGameFramework.Runtime;

/// <summary>
/// 实体组件拓展方法
/// </summary>
public static class EntityExtension
{
    // 关于 EntityId 的约定：
    // 0 为无效
    // 正值用于和服务器通信的实体（如玩家角色、NPC、怪等，服务器只产生正值）
    // 负值用于本地生成的临时实体（如特效、FakeObject等）
    private static int s_SerialId = 0;

    /// <summary>
    /// 生成实体编号
    /// </summary>
    /// <param name="entityComponent"></param>
    /// <returns></returns>
    public static int GenerateSerialId(this EntityComponent entityComponent)
    {
        return --s_SerialId;
    }

    /// <summary>
    /// 隐藏实体
    /// </summary>
    /// <param name="entityComponent"></param>
    /// <param name="entity"></param>
    public static void HideEntity(this EntityComponent entityComponent, GameEntity entity)
    {
        entityComponent.HideEntity(entity.Entity);
    }

    /// <summary>
    /// 附加子实体
    /// </summary>
    /// <param name="childEntity">要附加的子实体。</param>
    /// <param name="parentEntityId">被附加的父实体的实体编号。</param>
    /// <param name="parentTransformPath">相对于被附加父实体的位置。</param>
    /// <param name="userData">用户自定义数据。</param>
    public static void AttachEntity(this EntityComponent entityComponent, GameEntity entity, int ownerId, string parentTransformPath = null, object userData = null)
    {
        entityComponent.AttachEntity(entity.Entity, ownerId, parentTransformPath, userData);
    }

    /// <summary>
    /// 获取游戏实体
    /// </summary>
    /// <param name="entityComponent"></param>
    /// <param name="entityId"></param>
    /// <returns></returns>
    public static GameEntity GetGameEntity(this EntityComponent entityComponent, int entityId)
    {
        UnityGameFramework.Runtime.Entity entity = entityComponent.GetEntity(entityId);
        if (entity == null)
        {
            return null;
        }

        return (GameEntity)entity.Logic;
    }

    /// <summary>
    /// 显示主角
    /// </summary>
    /// <param name="entityComponent"></param>
    /// <param name="data"></param>

    public static void ShowPlayer(this EntityComponent entityComponent,PlayerData data)
    {
        entityComponent.ShowEntity(typeof(Player),data);
    }

    /// <summary>
    /// 显示实体
    /// </summary>
    /// <param name="entityComponent"></param>
    /// <param name="logicType"></param>
    /// <param name="entityGroup"></param>
    /// <param name="data"></param>
    private static void ShowEntity(this EntityComponent entityComponent, Type logicType, EntityData data)
    {
        if (data == null)
        {
            Log.Warning("Data is invalid.");
            return;
        }

        IDataTable<DREntity> dtEntity = GameManager.DataTable.GetDataTable<DREntity>();
        DREntity drEntity = dtEntity.GetDataRow(data.TypeId);

        string entityGroup = drEntity.EntityGroup;
        if (drEntity == null)
        {
            Log.Warning("Can not load entity id '{0}' from data table.", data.TypeId.ToString());
            return;
        }

        entityComponent.ShowEntity(data.Id, logicType, AssetUtility.GetEntityAsset(drEntity.AssetName), entityGroup, data);
    }
}