using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public Tilemap tilemap;
    public TileBase tb;
    public Transform player;
    public Vector3Int test;

    // Use this for initialization
    void Start () {
        player = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Horizontal") > 0.1f|| Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f));
        }

        if (Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f)
        {
            transform.Translate(new Vector2(0f,Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime));
        }

        print((int)player.position.x / 2 + "   "+ (int)player.position.y / 2);
        
        print(tilemap.GetTile(FloorToInt(player.position / 1.75f)));
        test = FloorToInt(player.position/1.75f);
        //print(tilemap.GetTile(new Vector3Int(0,0,0)));

        tilemap.SetColor(test, Color.cyan);
        tilemap.SetTile(test, tb);

    }


    public static Vector3Int FloorToInt(Vector3 v)
    {
        return new Vector3Int(
            Mathf.FloorToInt(v.x),
            Mathf.FloorToInt(v.y),
            Mathf.FloorToInt(v.z)
        );
    }

    public static Vector3Int RoundToInt(Vector3 v)
    {
        return new Vector3Int(
            Mathf.RoundToInt(v.x),
            Mathf.RoundToInt(v.y),
            Mathf.RoundToInt(v.z)
        );
    }
}
