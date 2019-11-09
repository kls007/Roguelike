using Shuai;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KuoZhan : EditorWindow
{
    [MenuItem("GameObject/ShuaiElement #1", false, 30)]
    //[MenuItem("Shuai/ShuaiElement #1", false, 30)]
    private static void Shuai_Item()
    {
        Object[] selectGameObjects = Selection.objects;

        //for (int i = 0; i < gameObjects.Length; i++)
        //{
            GameObject selectGameObject_0 = selectGameObjects[0] as GameObject;
            Item[] items = selectGameObject_0.transform.GetComponentsInChildren<Item>();
            
            for (int i = 0; i < items.Length; i++)
            {
                Item item = items[i];
                GameObject child = item.gameObject;
                SpriteRenderer sprite = child.transform.GetComponent<SpriteRenderer>();
                SpriteRes res = child.transform.GetComponent<SpriteRes>();
                sprite.sprite = res.spriteList[item.id - 1];

                Debug.Log(item.id);
            }
        //}
    }

}
