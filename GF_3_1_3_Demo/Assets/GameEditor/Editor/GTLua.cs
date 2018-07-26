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
    private string m_filesConfigFile = Application.dataPath+"/GameMain/Scripts/Lua/LuaFilesConfig.cs";

    public GTLua()
    {
        Debug.Log("m_filesConfigFile:"+m_filesConfigFile);
    }

    /// <summary>
    /// 生成Lua文件配置CS
    /// </summary>
    public void GenerateLuaFileConfig()
    {
        string rootPath = Application.dataPath + "/XLua/Resources/";
        string suffix = ".lua.txt";
        CollectFilesWithSuffix(rootPath, ".lua.txt", ref m_fileList);

        using (StreamWriter sw = new StreamWriter(File.Open(m_filesConfigFile, FileMode.Create),new UTF8Encoding()))
        {
            sw.Write(@"using System.Collections.Generic;");
            sw.Write(@"
/// <summary>
/// 所有Lua文件配置
/// 由编辑器自动生成，不要修改！
/// </summary>
public static class LuaFilesConfig
{
    public static List<LuaFileInfo> FilesConfigList = new List<LuaFileInfo>() 
    {");
            sw.Write("\n");
            foreach (string file in m_fileList)
            {
               string path = Utility.Path.GetRegularPath(file);
               string tempName = path.Substring(path.IndexOf("Resources")+10);
               string luaName = tempName.Substring(0, tempName.Length - suffix.Length);
               sw.Write("\t\t");
               sw.Write(string.Format("new LuaFileInfo(\"{0}\"),\n", luaName));
            }
            sw.Write(@"
    };
}");     

            sw.Flush();
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
