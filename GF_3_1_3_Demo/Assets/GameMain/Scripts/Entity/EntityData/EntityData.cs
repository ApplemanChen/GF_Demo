//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 实体数据
/// </summary>
public abstract class EntityData
{
    [SerializeField]
    private int m_Id;
    [SerializeField]
    private int m_TypeId;
    [SerializeField]
    private Vector3 m_Postion;
    [SerializeField]
    private Quaternion m_Rotation;

    public EntityData(int id,int typeId)
    {
        m_Id = id;
        m_TypeId = typeId;
    }

    /// <summary>
    /// 实体编号
    /// </summary>
    public int Id
    {
        get
        {
            return m_Id;
        }
    }

    /// <summary>
    /// 实体类型编号
    /// </summary>
    public int TypeId
    {
        get
        {
            return m_TypeId;
        }
    }

    /// <summary>
    /// 实体位置
    /// </summary>
    public Vector3 Position
    {
        get
        {
            return m_Postion;
        }

        set
        {
            m_Postion = value;
        }
    }

    /// <summary>
    /// 实体朝向
    /// </summary>
    public Quaternion Rotation
    {
        get
        {
            return m_Rotation;
        }

        set
        {
            m_Rotation = value;
        }
    }
}
