
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
    /// 数据表资源
    /// </summary>
    /// <param name="assetName"></param>
    /// <returns></returns>
    public static string GetDataTableAsset(string assetName)
    {
        return string.Format("Assets/GameMain/Res/DataTables/{0}.json",assetName);
    }
}
