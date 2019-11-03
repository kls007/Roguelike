using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using XLua;

public class Test : MonoBehaviour
{
    public Animator animator;
    public Animation animation;

    public Tilemap tilemap;
    public TileBase tb;

    public Grid grid;
    void Awake()
    {
        
    }


    void ExplosionLogic(Vector3Int cellPos)
    {
        tilemap.SetTile(cellPos, null);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Debug.Log("1");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            //Debug.Log(Input.mousePosition);
            //Debug.Log(mousePos);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            Debug.Log(hit.collider);
            if (hit.collider && (hit.collider.tag == "door" || hit.collider.tag == "item"))
            {
                Destroy(hit.collider.gameObject);
            }
            


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                //划出射线，只有在scene视图中才能看到
                Debug.DrawLine(ray.origin, hitInfo.point);
                GameObject gameObj = hitInfo.collider.gameObject;
                Debug.Log("click object name is " + gameObj.name);
                //当射线碰撞目标为boot类型的物品，执行拾取操作
                //if (gameObj.tag == "boot")
                //{
                    Debug.Log("pickup!");
                //}
            }
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
