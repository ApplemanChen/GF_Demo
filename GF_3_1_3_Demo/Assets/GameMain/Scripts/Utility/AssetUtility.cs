
/// <summary>
/// 资源路径工具类
/// </summary>
using System.Collections.Generic;
using System.IO;
public static class AssetUtility {

    /// <summary>
    /// 场景资源
    /// </summary>
    /// <param name="assetName">资源名</param>
    /// <returns></returns>
    public static string GetSceneAsset(string assetName)
    {
        return string.Format("Assets/GameMain/Res/Scenes/{0}.unity", assetName);
    }

    /// <summary>
    /// 实体资源
    /// </summary>
    /// <param name="assetName">资源名</param>
    /// <returns></returns>
    public static string GetEntityAsset(string assetName)
    {
        return string.Format("Assets/GameMain/Res/Entities/{0}.prefab", assetName);
    }

    /// <summary>
    /// 基础配置资源
    /// </summary>
    /// <returns></returns>
    public static string GetBaseConfigAsset(string assetName)
    {
        return string.Format("Assets/GameMain/Config/{0}.txt",assetName);
    }

    /// <summary>
    /// 数据表资源
    /// </summary>
    /// <param name="assetName"></param>
    /// <returns></returns>
    public static string GetDataTableAsset(string assetName)
    {
        return string.Format("Assets/GameMain/Res/DataTables/{0}.json",assetName);
    }

    /// <summary>
    /// 背景音乐资源
    /// </summary>
    /// <param name="assetName"></param>
    /// <returns></returns>
    public static string GetMusicAsset(string assetName)
    {
        return string.Format("Assets/GameMain/Res/Music/{0}.mp3",assetName);
    }

    /// <summary>
    /// 普通音效资源
    /// </summary>
    /// <param name="assetName"></param>
    /// <returns></returns>
    public static string GetSoundAsset(string assetName)
    {
        return string.Format("Assets/GameMain/Res/Sound/{0}.mp3",assetName);
    }

    /// <summary>
    /// 界面音效资源
    /// </summary>
    /// <param name="assetName"></param>
    /// <returns></returns>
    public static string GetUISoundAsset(string assetName)
    {
        return string.Format("Assets/GameMain/Res/UISound/{0}.mp3",assetName);
    }

    /// <summary>
    /// 界面预制体
    /// </summary>
    /// <param name="assetName"></param>
    /// <returns></returns>
    public static string GetUIFormAsset(string assetName)
    {
        return string.Format("Assets/GameMain/Res/UI/UIForms/{0}.prefab", assetName);
    }

    /// <summary>
    /// 本地化字典资源
    /// </summary>
    /// <param name="assetName"></param>
    public static string GetDictionaryAsset(string assetName)
    {
        return string.Format("Assets/GameMain/Localization/{0}/Dictionaries/{1}.xml", GameManager.Localization.Language.ToString(), assetName);
    }

    /// <summary>
    /// 字体资源
    /// </summary>
    /// <param name="assetName"></param>
    /// <returns></returns>
    public static string GetFontAsset(string assetName)
    {
        //UGUI 字体
        //return string.Format("Assets/GameMain/Localization/{0}/Fonts/{1}.ttf", GameManager.Localization.Language.ToString(), assetName);
        //NGUI的UIFont
        return string.Format("Assets/GameMain/Res/UI/Atlas/Font/{0}.prefab",assetName);
    }

    /// <summary>
    /// Lua列表文件
    /// </summary>
    /// <returns></returns>
    public static string GetLuaFileConfig()
    {
        return string.Format("Assets/GameMain/Config/LuaFilesConfig.json");
    }

    /// <summary>
    /// Lua资源
    /// </summary>
    /// <param name="assetName">资源名</param>
    /// <returns></returns>
    public static string GetLuaAsset(string assetName)
    {
        return string.Format("Assets/XLua/Resources/{0}.lua.txt",assetName);
    }

    /// <summary>
    /// Proto资源
    /// </summary>
    /// <param name="proto"></param>
    /// <returns></returns>
    public static string GetProtoAsset(string proto)
    {
        return string.Format("Assets/XLua/Resources/3rd/proto/{0}.lua.txt",proto);
    }

    /// <summary>
    /// Proto.pb资源
    /// </summary>
    /// <param name="proto"></param>
    /// <returns></returns>
    public static string GetProtoPbAsset(string proto)
    {
        return string.Format("Assets/XLua/Resources/3rd/pb/{0}.txt", proto);
    }

    /// <summary>
    /// 获取指定目录下所有指定后缀资源名的文件路径
    /// </summary>
    /// <param name="rootPath">根路径</param>
    /// <param name="suffix">后缀名</param>
    /// <param name="fileList">得到的文件列表</param>
    public static void GetSuffixAssetPaths(string rootPath, string suffix, ref List<string> fileList)
    {
        string[] dirs = Directory.GetDirectories(rootPath);
        foreach (string path in dirs)
        {
            GetSuffixAssetPaths(path, suffix, ref fileList);
        }

        string[] files = Directory.GetFiles(rootPath);
        foreach (string filePath in files)
        {
            if (filePath.Substring(filePath.IndexOf(".")) == suffix)
            {
                fileList.Add(filePath);
            }
        }
    }
}
