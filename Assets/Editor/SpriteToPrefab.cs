using Shuai;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SpriteToPrefab : MonoBehaviour
{
    public static string ORIGIN_DIR = "\\Test\\1"; //需要转换的目录(手动修改目录)
    public static string TARGET_DIR = "\\Test\\2"; //转换后放入prefab的目录

    
    [MenuItem("GameObject/图片转Prefab_Item #1", false, 10)]
    public static void SpriteToPrefab_Item()
    {
        batchCreateSpritePrefabInPath(Element.ElementType.Item, "item", "item");
    }

    [MenuItem("GameObject/图片转Prefab_Enemy #2", false, 10)]
    public static void SpriteToPrefab_Enemy()
    {
        batchCreateSpritePrefabInPath(Element.ElementType.Enemy, "enemy","enemy");
    }


    ////// 将目录下所有图片转成Sprite prefab
    public static void batchCreateSpritePrefabInPath(Element.ElementType type, string tag, string layer)
    {
        string targetDir = Application.dataPath + TARGET_DIR;
        string originDir = Application.dataPath + ORIGIN_DIR;

        ////如果目录不存在创建空的目标目录
        DirectoryInfo originDirInfo = new DirectoryInfo(originDir);

        //创建prefab
        makeSpritePrefabs(originDirInfo.GetFiles("*.jpg", SearchOption.AllDirectories), targetDir, type, tag, layer);
        makeSpritePrefabs(originDirInfo.GetFiles("*.png", SearchOption.AllDirectories), targetDir, type, tag, layer);
        EditorUtility.ClearProgressBar();
    }

    private static void makeSpritePrefabs(FileInfo[] files, string targetDir, Element.ElementType type, string tag, string layer)
    {
        //foreach (FileInfo file in files)
        for (int i = 0; i < files.Length; i++)
        {
            //int index = files.indexOf(file);
            FileInfo file = files[i];
            //获取全路径
            string allPath = file.FullName;
            MonoBehaviour.print(allPath);
            Debug.Log(file);

            //获取资源路径            
            string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
            MonoBehaviour.print("assetPath " + assetPath);

            //加载贴图            
            Sprite sprite = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Sprite)) as Sprite;

            //创建绑定了贴图的 GameObject 对象            
            GameObject go = new GameObject(sprite.name);
            go.tag = tag;

            SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = sprite;
            sr.sortingLayerName = layer;

            BoxCollider2D bc2 = go.AddComponent<BoxCollider2D>();
            bc2.isTrigger = true;
            
            Element element = go.AddComponent<Element>();
            element.id = i + 1;
            element.type = type;
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

}
