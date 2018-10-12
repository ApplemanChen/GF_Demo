//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;

namespace GT
{
    /// <summary>
    /// 通用工具方法
    /// </summary>
    public static class GTUtility
    {
        /// <summary>
        /// 收集指定目录下指定后缀名的所有文件
        /// </summary>
        /// <param name="rootPath"></param>
        /// <param name="suffix"></param>
        /// <param name="fileList"></param>
        public static void CollectFilesWithSuffix(string rootPath, string suffix, ref List<string> fileList)
        {
            string[] dirs = Directory.GetDirectories(rootPath);
            foreach (string path in dirs)
            {
                CollectFilesWithSuffix(path, suffix, ref fileList);
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
}
