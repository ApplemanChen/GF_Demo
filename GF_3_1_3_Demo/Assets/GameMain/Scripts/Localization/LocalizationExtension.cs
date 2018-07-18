//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using UnityGameFramework.Runtime;

public static class LocalizationExtension
{
    public static void LoadDictionary(this LocalizationComponent localzationComponent,string dictionaryName)
    {
        localzationComponent.LoadDictionary(dictionaryName, AssetUtility.GetDictionaryAsset(dictionaryName));
    }
}
