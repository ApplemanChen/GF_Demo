//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 游戏实体
/// </summary>
public abstract class GameEntity : EntityLogic
{
    [SerializeField]
    private EntityData m_EntityData = null;

    public int Id
    {
        get
        {
            return Entity.Id;
        }
    }

    public Animation CachedAnimation
    {
        get;
        private set;
    }

    public Animator CachedAnimator
    {
        get;
        private set;
    }

    protected internal override void OnInit(object userData)
    {
        base.OnInit(userData);
        CachedAnimation = GetComponent<Animation>();
        CachedAnimator = GetComponent<Animator>();
    }

    protected internal override void OnShow(object userData)
    {
        base.OnShow(userData);

        m_EntityData = userData as EntityData;
        if (m_EntityData == null)
        {
            Log.Error("Entity data is invalid.");
            return;
        }

        Name = string.Format("[Entity {0}]", Id.ToString());
        CachedTransform.localPosition = m_EntityData.Position;
        CachedTransform.localRotation = m_EntityData.Rotation;
        CachedTransform.localScale = Vector3.one;
    }

    protected internal override void OnHide(object userData)
    {
        base.OnHide(userData);
    }

    protected internal override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
    {
        base.OnAttached(childEntity, parentTransform, userData);
    }

    protected internal override void OnDetached(EntityLogic childEntity, object userData)
    {
        base.OnDetached(childEntity, userData);
    }

    protected internal override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
    {
        base.OnAttachTo(parentEntity, parentTransform, userData);
    }

    protected internal override void OnDetachFrom(EntityLogic parentEntity, object userData)
    {
        base.OnDetachFrom(parentEntity, userData);
    }

    protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);
    }
}
