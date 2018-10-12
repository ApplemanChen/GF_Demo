using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.Text;
using System.IO;
using GameFramework;
using GameFramework.Event;

namespace GT
{
    /// <summary>
    /// Lua相关工具
    /// </summary>
    public class GTLua
    {
        private List<string> m_fileList = new List<string>();
        private string m_filesConfigFile = Application.dataPath + "/GameMain/Config/LuaFilesConfig.json";
        private Dictionary<string, bool> m_loadedFlag;

        public GTLua()
        {

        }

        private void AddEvent()
        {
            GameManager.Event.Subscribe(LoadLuaSuccessEventArgs.EventId, OnLoadLuaSuccess);
            GameManager.Event.Subscribe(LoadLuaFilesConfigSuccessEventArgs.EventId, OnLoadLuaFilesConfgSuccess);
        }

        private void RemoveEvent()
        {
            GameManager.Event.Unsubscribe(LoadLuaSuccessEventArgs.EventId, OnLoadLuaSuccess);
            GameManager.Event.Unsubscribe(LoadLuaFilesConfigSuccessEventArgs.EventId, OnLoadLuaFilesConfgSuccess);
        }

        /// <summary>
        /// 运行模式下，重新加载lua
        /// </summary>
        public void ReloadLuaOnPlaying()
        {
            //编辑器模式下
            if (GameManager.Base.EditorResourceMode)
            {
                EditorUtility.DisplayProgressBar("正在重新加载Lua文件","正在加载...",0);

                AddEvent();

                //加载Lua配置文件
                GameManager.Lua.LoadLuaFilesConfig();
            }
        }

        private void StartLoadLua()
        {
            m_loadedFlag = new Dictionary<string, bool>();

            List<LuaFileInfo> m_LuaFileInfos = GameManager.Lua.LuaFileInfos;
            for (int i = 0; i < m_LuaFileInfos.Count; i++)
            {
                m_loadedFlag[m_LuaFileInfos[i].LuaName] = false;
                GameManager.Lua.LoadLuaFile(m_LuaFileInfos[i].LuaName, m_LuaFileInfos[i].AssetName);
            }
        }

        private void OnLoadLuaFilesConfgSuccess(object sender, GameEventArgs e)
        {
            //开始加载lua文件
            StartLoadLua();
        }

        private void OnLoadLuaSuccess(object sender, GameEventArgs e)
        {
            LoadLuaSuccessEventArgs evt = (LoadLuaSuccessEventArgs)e;

            m_loadedFlag[evt.LuaName] = true;

            if (CheckIsAllLoaded())
            {
                RemoveEvent();
                EditorUtility.ClearProgressBar();
                Debug.Log("All lua files is reloaded !");
            }
        }

        private bool CheckIsAllLoaded()
        {
            foreach(bool value in m_loadedFlag.Values)
            {
                if(value==false)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 生成Lua文件配置
        /// </summary>
        public void GenerateLuaFileConfig()
        {
            string rootPath = Application.dataPath + "/XLua/Resources/";
            string suffix = ".lua.txt";
            GTUtility.CollectFilesWithSuffix(rootPath, ".lua.txt", ref m_fileList);

            StringBuilder sb = new StringBuilder();

            foreach (string file in m_fileList)
            {
                string path = Utility.Path.GetRegularPath(file);
                string tempName = path.Substring(path.IndexOf("Resources") + 10);
                string luaName = tempName.Substring(0, tempName.Length - suffix.Length);
                string json = GameUtility.SerializeObject<LuaFileInfo>(new LuaFileInfo(luaName));
                //Debug.Log("json:" + json);
                sb.Append(json);

                sb.Append("\n");
            }

            using (FileStream stream = new FileStream(m_filesConfigFile, FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(stream);
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
            }

            AssetDatabase.Refresh();
        }
    }
}
