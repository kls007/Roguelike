using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using UnityEngine.UI;
using XLua;
using Shuai;

public class Test : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tb;

    public Grid grid;
    
    void Awake()
    {
        
    }
    [MenuItem("Tools/检测Text字体设置是否规范")]
    public static void CheckTextFont()
    {
        string[] allPath = AssetDatabase.FindAssets("t:Prefab", new string[] { "Assets/Test" });
        Debug.Log(allPath);
        Debug.Log(allPath.Length);

        for (int i = 0; i < allPath.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(allPath[i]);
            var obj = AssetDatabase.LoadAssetAtPath(path, typeof(GameObject)) as GameObject;
            if (obj != null)
            {
                Image image = obj.transform.Find("main/Button_close").GetComponent<Image>();
                Debug.Log(image);

                //var texts = obj.GetComponentsInChildren<Text>();
                //foreach (var text in texts)
                //{
                //    if (text.font.name == "RADIO" || text.font.name == "eurostile" || text.font.name == "Arial")
                //    {
                //        Debug.Log("预制体：[" + obj.name + "] 的组件 [" + text.name + "] 有误");
                //        //                        break;
                //    }
                //}
            }
        }
    }

  

    //一键修改预设里面的图片
    [MenuItem("Custom Editor/ChangeIconName")]
    static void BuildPCChangeIconName()
    {
        Debug.Log(Application.dataPath);
        //存放预设目录
        string path = Application.dataPath + "/Test/";
        Debug.Log(path);
        List<GameObject> files = new List<GameObject>();
        string[] filePaths = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
        for (int i = 0; i < filePaths.Length; ++i)
        {
            if (filePaths[i].Contains(".meta"))
                continue;
            //string filePath = cut2AssetFolder(filePaths[i]);
            //GameObject file = AssetDatabase.LoadAssetAtPath(filePath, typeof(GameObject)) as GameObject;
            //if (file != null)
            //    files.Add(file);
        }
    }

        void ExplosionLogic(Vector3Int cellPos)
    {
        tilemap.SetTile(cellPos, null);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            //animator.Play("Attack_Animation");
            tilemap.ClearAllTiles();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S");
            //animation.Play();
            //animator.StartPlayback();

            TileBase tb1 = tilemap.GetTile(new Vector3Int(0, 0, 0));
            Debug.Log(tb1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D");

            TileBase tb1 = tilemap.GetTile(new Vector3Int(0, 0, 0));
            Debug.Log(tb1);
            tilemap.SetTile(Vector3Int.zero, tb);
        }
    }
    
}
