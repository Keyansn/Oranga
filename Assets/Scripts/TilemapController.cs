using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour
{

    public TileData tileDataHolder;
    public Tilemap tilemap;
    public TileBase tb;

    // Use this for initialization
    void Start () {
        createthemap();
    }	
	// Update is called once per frame
	void Update () {
        print(tilemap.localBounds);

    }

    void createthemap()
    {
        for (int i = -5; i < 5; i++)
        {
            for (int j = -5; j < 5; j++)
            {
                tilemap.SetTile(new Vector3Int(i, j, 1), tb);
            }
            //tilemap.SetTile(new Vector3Int(1,1,1), tb);
        }
    }

    
}
