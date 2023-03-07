using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Sxer.Tool
{
 /*
 * Application.dataPath：
 *                  Windows：应用目录/【appname】_Data
 *                  Editor：工程目录/Assets
 *                  IOS：
 *                  Mac：
 *                  Android：/data/app/【package name】-1/base.apk
 * 
 * Application.streamingAssetsPath：
 *                  Windows：应用目录/【appname】_Data/StreamingAssets
 *                  Editor：工程目录/Assets/StreamingAssets
 *                  IOS：
 *                  Mac：
 * (只读)           Android：jar:file:///data/app/【package name】-1/base.apk!/assets
 * 
 * Application.persistentDataPath：数据持久化路径 
 *                  Windows：C:\Users\【username】\AppData\LocalLow\【company name】\【product name】
 *                  Editor：C:\Users\【username】\AppData\LocalLow\【company name】\【product name】
 *                  IOS：
 *                  Mac：
 * (热更，可读可写)  Android：/storage/emulated/0/Android/data/【package name】/files
 * 
 * Application.temporaryCachePath：临时数据缓存目录
 *                  Windows：C:\Users\【username】\AppData\Local\Temp\【company name】\【product name】
 *                  Editor：C:\Users\【username】\AppData\Local\Temp\【company name】\【product name】
 *                  IOS：
 *                  Mac：
 *                  Android：/storage/emulated/0/Android/data/【package name】/cache
 * 
 * 
 * 
 */
    public static class PathHelper
    {
        //1.通过C#的方式来获取目录
        //2.通过unity的方式来获取目录

        //3.一些对路径的处理操作，需要用到System.IO里的api帮助【C#的一些系统api需要测试能否跨平台以及跨平台的效果】
        //  如果用到一些处理路径的api是否对不同平台有影响

        //




        //获取当前工程路径
        public static string TestApi()
        {
            Debug.Log( PathCut(Application.temporaryCachePath,2));
            return Application.temporaryCachePath;
            //Directory.GetCurrentDirectory(_path);
        }

        public static string GetFileNameFromPath(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        /// <summary>
        /// 获取工程的根目录（即编辑器中项目的Assets同级目录，打包PC的exe同级目录）
        /// </summary>
        /// <returns></returns>
        public static string GetProjectRoot()
        {
            return PathCut(Application.dataPath, 1);
            //return System.Environment.CurrentDirectory;（此api会受进程调用关系的影响）
            //return Directory.GetCurrentDirectory();（此api会受进程调用关系的影响）
        }


        //static void PathSHow()
        //{
        //    ;
        //    Application.streamingAssetsPath;
        //    Application.persistentDataPath;
        //    Application.temporaryCachePath;
        //}


        /// <summary>
        /// 剔除当前路径的多个层级
        /// </summary>
        /// <param name="pathStr"></param>
        /// <param name="splitCount">剔除层级数</param>
        /// <returns></returns>
        private static string PathCut(string pathStr, int splitCount)
        {
            string[] temps = pathStr.Split('/');
            //剔除后两个 是exe路径
            //再剔除5个 是播放器路径
            string newStr = string.Empty;
            for (int i = 0; i < temps.Length - splitCount; i++)
            {
                newStr += temps[i] + "/";
            }
            return newStr.Substring(0,newStr.Length-1);
        }
    }
}

