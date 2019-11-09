﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using UnityEngine.UI;
using XLua;
using Shuai;
  

////// 将目录下所有图片转成Sprite prefab

public class Test : MonoBehaviour
{

    private const string ORIGIN_DIR = "\\Test\\1"; //需要转换的目录(手动修改目录)    

    private const string TARGET_DIR = "\\Test\\2"; //转换后放入prefab的目录  
    void Awake()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D");
        }
    }


    ////// 将目录下所有图片转成Sprite prefab
    [MenuItem("Tools/batchCreateSpritePrefabInPath")]
    public static void batchCreateSpritePrefabInPath()
    {
        string targetDir = Application.dataPath + TARGET_DIR;
        string originDir = Application.dataPath + ORIGIN_DIR;

        //if (!Directory.Exists(originDir))
        //{
        //    EditorUtility.DisplayDialog("错误", originDir.Replace("\\", "/") + "目录不存在", "确定"); return;
        //}
        //if (!File.Exists(targetDir)) Directory.CreateDirectory(targetDir);

        ////如果目录不存在创建空的目标目录        
        DirectoryInfo originDirInfo = new DirectoryInfo(originDir);

        //创建prefab
        makeSpritePrefabs(originDirInfo.GetFiles("*.jpg", SearchOption.AllDirectories), targetDir);
        makeSpritePrefabs(originDirInfo.GetFiles("*.png", SearchOption.AllDirectories), targetDir);
        EditorUtility.ClearProgressBar();
    }

    ////// 将目录下所有图片转成prefab

    ///[MenuItem("Tools/batch/batchCreateImagePrefabInPath")]    

    //    public static void batchCreateImagePrefabInPath()
    //    {

    //        string targetDir = Application.dataPath + TARGET_DIR;

    //        string originDir = Application.dataPath + ORIGIN_DIR;

    //        if (!Directory.Exists(originDir)) { EditorUtility.DisplayDialog("错误", originDir.Replace("\\", "/") + "目录不存在", "确定"); return; }

    //        if (!File.Exists(targetDir)) Directory.CreateDirectory(targetDir); //如果目录不存在创建空的目标目录        DirectoryInfo originDirInfo = new DirectoryInfo(originDir);        //创建prefab        makeImagePrefabs(originDirInfo.GetFiles("*.jpg", SearchOption.AllDirectories), targetDir);        makeImagePrefabs(originDirInfo.GetFiles("*.png", SearchOption.AllDirectories), targetDir);        EditorUtility.ClearProgressBar();    }    ////// 创建image的Prefabs

    ////////文件数据    ///目标目录    

    //    private static void makeImagePrefabs(FileInfo[] files, string targetDir)

    //    {
    //        foreach (FileInfo file in files)

    //        {

    //            //获取全路径            

    //            string allPath = file.FullName;

    //            MonoBehaviour.print(allPath);

    //            //获取资源路径            

    //            string assetPath = allPath.Substring(allPath.IndexOf("Assets"));

    //            MonoBehaviour.print("assetPath " + assetPath);

    //            //加载贴图            

    //            Sprite sprite = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Sprite)) as Sprite;

    //            //创建绑定了贴图的 GameObject 对象            

    //            GameObject go = new GameObject(sprite.name);

    //            go.AddComponent().sprite = sprite;

    //            go.GetComponent().sizeDelta = new Vector2(sprite.rect.width, sprite.rect.height);

    //            EditorUtility.DisplayProgressBar("创建" + sprite.name, "创建" + sprite.name, 1f);

    //            //获取图片名称            

    //            string imageName = assetPath.Replace("Assets" + ORIGIN_DIR + "\\", "");

    //            //去掉后缀            

    //            imageName = imageName.Substring(0, imageName.IndexOf("."));

    //            //得到最终路径            

    //            string prefabPath = targetDir + "\\" + imageName + ".prefab";

    //            //得到应用当前目录的路径            

    //            prefabPath = prefabPath.Substring(prefabPath.IndexOf("Assets"));

    //            //创建目录            

    //            Directory.CreateDirectory(prefabPath.Substring(0, prefabPath.LastIndexOf("\\")));

    //            //生成预制件            

    //            PrefabUtility.CreatePrefab(prefabPath.Replace("\\", "/"), go);

    //            //销毁对象            

    //            GameObject.DestroyImmediate(go);
    //        }

    //        EditorUtility.ClearProgressBar();
    //    }

    //    ////// 创建sprite的Prefabs

    //    //////文件数据    ///目标目录   

    private static void makeSpritePrefabs(FileInfo[] files, string targetDir)
    {

        foreach (FileInfo file in files)
        {

            //获取全路径            

            string allPath = file.FullName;

            MonoBehaviour.print(allPath);

            //获取资源路径            

            string assetPath = allPath.Substring(allPath.IndexOf("Assets"));

            MonoBehaviour.print("assetPath " + assetPath);

            //加载贴图            

            Sprite sprite = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Sprite)) as Sprite;

            //创建绑定了贴图的 GameObject 对象            

            GameObject go = new GameObject(sprite.name);
            go.AddComponent<SpriteRenderer>().sprite = sprite;

            EditorUtility.DisplayProgressBar("创建" + sprite.name, "创建" + sprite.name, 1f);

            //获取图片名称

            string imageName = assetPath.Replace("Assets" + ORIGIN_DIR + "\\", "");

            //去掉后缀

            imageName = imageName.Substring(0, imageName.IndexOf("."));

            //得到最终路径

            string prefabPath = targetDir + "\\" + imageName + ".prefab";

            //得到应用当前目录的路径

            prefabPath = prefabPath.Substring(prefabPath.IndexOf("Assets"));

            //创建目录

            Directory.CreateDirectory(prefabPath.Substring(0, prefabPath.LastIndexOf("\\")));

            //生成预制件

            PrefabUtility.CreatePrefab(prefabPath.Replace("\\", "/"), go);

            //销毁对象

            GameObject.DestroyImmediate(go);

        }

        EditorUtility.ClearProgressBar();

    }

    //}


}
