using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.Text;
using System.IO;
using GameFramework;

/// <summary>
/// Lua相关工具
/// </summary>
public class GTLua
{
    private List<string> m_fileList = new List<string>();
    private string m_filesConfigFile = Application.dataPath + "/GameMain/Config/LuaFilesConfig.json";

    public GTLua()
    {

    }

    /// <summary>
    /// 生成Lua文件配置CS
    /// </summary>
    public void GenerateLuaFileConfig()
    {
        string rootPath = Application.dataPath + "/XLua/Resources/";
        string suffix = ".lua.txt";
        CollectFilesWithSuffix(rootPath, ".lua.txt", ref m_fileList);

        StringBuilder sb = new StringBuilder();

        foreach(string file in m_fileList)
        {
            string path = Utility.Path.GetRegularPath(file);
            string tempName = path.Substring(path.IndexOf("Resources") + 10);
            string luaName = tempName.Substring(0, tempName.Length - suffix.Length);
            string json = GameUtility.SerializeObject<LuaFileInfo>(new LuaFileInfo(luaName));
            Debug.Log("json:"+json);
            sb.Append(json);
            
            sb.Append("\n");
        }

        using (FileStream stream = new FileStream(m_filesConfigFile,FileMode.Create))
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.Write(sb.ToString());
            sw.Flush();
            sw.Close();
        }

        AssetDatabase.Refresh();
    }

    /// <summary>
    /// 收集指定目录下指定后缀名的所有文件
    /// </summary>
    /// <param name="rootPath"></param>
    /// <param name="suffix"></param>
    /// <param name="fileList"></param>
    private void CollectFilesWithSuffix(string rootPath,string suffix,ref List<string> fileList)
    {
        string[]    dirs = Directory.GetDirectories(rootPath);
        foreach(string path in dirs)
        {
            CollectFilesWithSuffix(path,suffix,ref fileList);
        }

        string[] files = Directory.GetFiles(rootPath);
        foreach(string filePath in files)
        {
            if (filePath.Substring(filePath.IndexOf(".")) == suffix)
            {
                fileList.Add(filePath);
            }
        }
    }
}
