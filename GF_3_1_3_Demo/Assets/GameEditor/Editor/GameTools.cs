using UnityEngine;
using System.Collections;
using UnityEditor;

namespace GT
{
    /// <summary>
    /// 自定义编辑器工具
    /// </summary>
    public static class GameTools
    {
        private static GTLua s_luaTool = new GTLua();

        /// <summary>
        /// 显示作者信息
        /// </summary>
        [MenuItem("GameTools/作者：一条猪儿虫")]
        private static void AuthorName()
        {
            Debug.Log("作者：一条猪儿虫，^_^, Email:1184923569@qq.com");
        }

        [MenuItem("GameTools/生成所有Lua文件信息配置LuaFilesConfig.json")]
        public static void GenerateLuaFilesConfig()
        {
            s_luaTool.GenerateLuaFileConfig();
        }

        /// <summary>
        /// 运行模式下，重新加载lua
        /// </summary>
        public static void ReloadLuaOnPlaying()
        {
            //编辑器模式下才启用
            if(GameManager.Base.EditorResourceMode)
            {
                s_luaTool.ReloadLuaOnPlaying();
            }
        }
    }
}