using Shuai;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KuoZhan : EditorWindow
{
    //[MenuItem("Shuai/ShuaiElement #1", false, 30)]
    [MenuItem("GameObject/ShuaiElement #3", false, 10)]
    private static void Shuai_Item()
    {
        Object[] selectGameObjects = Selection.objects;

        //for (int i = 0; i < gameObjects.Length; i++)
        //{
            GameObject selectGameObject_0 = selectGameObjects[0] as GameObject;
            Element[] elements = selectGameObject_0.transform.GetComponentsInChildren<Element>();
            Debug.Log(elements.Length);

            for (int i = 0; i < elements.Length; i++)
            {
                Element element = elements[i];
                GameObject child = element.gameObject;
                SpriteRenderer sprite = child.transform.GetComponent<SpriteRenderer>();
                SpriteRes res = child.transform.GetComponent<SpriteRes>();
                sprite.sprite = res.spriteList[element.id - 1];

                Debug.Log(element.id);
            }
        //}
    }

    [MenuItem("GameObject/选中物体的所有带Element的子物体的父节点设为选中物体 #4", false, 10)]
    private static void Shuai_Item22()
    {
        Object[] selectGameObjects = Selection.objects;
        GameObject selectGameObject_0 = selectGameObjects[0] as GameObject;

        Element[] elements = selectGameObject_0.transform.GetComponentsInChildren<Element>();
        Debug.Log(elements.Length);

        for (int i = 0; i < elements.Length; i++)
        {
            Element element = elements[i];
            Transform child = element.transform;
            child.transform.parent = selectGameObject_0.transform;

            //SpriteRenderer sprite = child.transform.GetComponent<SpriteRenderer>();
            //SpriteRes res = child.transform.GetComponent<SpriteRes>();
            //sprite.sprite = res.spriteList[element.id - 1];

            //Debug.Log(element.id);
        }

    }

}
