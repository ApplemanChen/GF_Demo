using UnityEngine;
using System.Collections;
using UnityEditor;

namespace GT
{
    public static class GameTools
    {
        /// <summary>
        /// 显示作者信息
        /// </summary>
        [MenuItem("GameTools/作者：一条猪儿虫")]
        private static void AuthorName()
        {
            Debug.Log("作者：一条猪儿虫，^_^, Email:1184923569@qq.com");
        }

        [MenuItem("GameTools/生成所有Lua文件信息配置LuaFilesConfig.cs")]
        public static void GenerateLuaFilesConfig()
        {
            GTLua luaTool = new GTLua();
            luaTool.GenerateLuaFileConfig();
        }
    }
}