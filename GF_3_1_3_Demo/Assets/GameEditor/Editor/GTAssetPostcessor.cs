using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

/// <summary>
/// 自定义资源导入器
/// </summary>
public class GTAssetPostcessor : AssetPostprocessor {

    /// <summary>
    /// 资源处理
    /// </summary>
    /// <param name="importedAssets">导入的资源</param>
    /// <param name="deletedAssets">删除的资源</param>
    /// <param name="movedAssets">移动后的资源</param>
    /// <param name="movedFromAssetPaths">移动前资源</param>
    public static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        List<string> luaList = new List<string>();
        string luaSuffix = ".lua.txt";

        //导入
        foreach(string item in importedAssets)
        {
            if(item.Substring(item.Length-8,8).Equals(luaSuffix))
            {
                luaList.Add(item);
            }
        }

        //删除
        foreach(string item in deletedAssets)
        {
            if (item.Substring(item.Length - 8, 8).Equals(luaSuffix))
            {
                luaList.Add(item);
            }
        }

        //移动后
        foreach (string item in movedAssets)
        {
            if (item.Substring(item.Length - 8, 8).Equals(luaSuffix))
            {
                luaList.Add(item);
            }
        }

        //有lua文件资源操作，就重新生成列表
        if(luaList.Count > 0)
        {
            GT.GameTools.GenerateLuaFilesConfig();

            //编辑器运行模式下，可直接修改lua,并直接运行检测，不用重新运行一次游戏！
            if(Application.isPlaying)
            {
                GT.GameTools.ReloadLuaOnPlaying();
            }
        }
    }
}
