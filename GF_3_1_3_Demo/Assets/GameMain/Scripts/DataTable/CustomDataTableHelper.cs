//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using GameFramework;
using UnityGameFramework.Runtime;
using UnityEngine;
using LitJson;

public class CustomDataTableHelper : DataTableHelperBase
{
    private DataTableComponent m_DataTableComponent = null;
    private ResourceComponent m_ResourceComponent = null;

    /// <summary>
    /// 将要解析的数据表文本分割为数据表行文本。
    /// </summary>
    /// <param name="text">要解析的数据表文本。</param>
    /// <returns>数据表行文本。</returns>
    public override string[] SplitToDataRows(string text)
    {
        List<string> texts = new List<string>();
        string[] rowTexts = DataTableExtension.SplitDataTable(text);
        for (int i = 0; i < rowTexts.Length;i++ )
        {
            if(!string.IsNullOrEmpty(rowTexts[i]))
            {
                texts.Add(rowTexts[i]);
            }
        }

        return texts.ToArray();
    }

    public override void ReleaseDataTableAsset(object dataTableAsset)
    {
        m_ResourceComponent.UnloadAsset(dataTableAsset);
    }

    protected override bool LoadDataTable(Type dataRowType, string dataTableName, string dataTableNameInType, object dataTableAsset, object userData)
    {
        TextAsset textAsset = dataTableAsset as TextAsset;
        if (textAsset == null)
        {
            Log.Warning("Data table asset '{0}' is invalid.", dataTableName);
            return false;
        }

        if (dataRowType == null)
        {
            Log.Warning("Data row type is invalid.");
            return false;
        }

        m_DataTableComponent.CreateDataTable(dataRowType, dataTableNameInType, textAsset.text);
        return true;
    }

    private void Start()
    {
        m_DataTableComponent = GameEntry.GetComponent<DataTableComponent>();
        if (m_DataTableComponent == null)
        {
            Log.Fatal("Data table component is invalid.");
            return;
        }

        m_ResourceComponent = GameEntry.GetComponent<ResourceComponent>();
        if (m_ResourceComponent == null)
        {
            Log.Fatal("Resource component is invalid.");
            return;
        }
    }
}
