using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using XLua;

public class Test : MonoBehaviour
{
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
