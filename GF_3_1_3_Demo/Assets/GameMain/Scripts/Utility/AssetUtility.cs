
/// <summary>
/// 资源路径工具类
/// </summary>
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
        return string.Format("Assets/GameMain/Localization/{0}/Fonts/{1}.ttf", GameManager.Localization.Language.ToString(), assetName);
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
}
