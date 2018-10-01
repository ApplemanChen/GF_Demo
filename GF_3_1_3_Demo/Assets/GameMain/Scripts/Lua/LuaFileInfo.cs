//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;

[Serializable]
public class LuaFileInfo
{
    public LuaFileInfo(string luaName)
    {
        LuaName = luaName;
        AssetName = AssetUtility.GetLuaAsset(luaName);
    }

    public string LuaName
    {
        private set;
        get;
    }

    public string AssetName
    {
        private set;
        get;
    }
}