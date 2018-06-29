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

    public float energy = 100;
    public float appitite = 0.1f;
    public float moveCost = 4;
    public float age;
    public float lifespan;

    public int ageGroup;
    /*
     * 0 = Baby
     * 1 = Child
     * 2 = Teenager
     * 3 = Young Adult
     * 4 = Adult
     * 5 = Elderly
     */


    // Use this for initialization
    void Start () {
        player = this.transform;
        age = 0;
	}
	
	// Update is called once per frame
	void Update () {

        age = age + Time.deltaTime;

        if (age > lifespan){Death();}
        if (energy <= 0) { Death(); }


        switch (ageGroup)
        {
            //////////////////////////////    0 = Baby           //////////////////////////////
            case 0:
                break;

            //////////////////////////////    1 = Child          //////////////////////////////
            case 1:
                break;

            //////////////////////////////    2 = Teenager       //////////////////////////////
            case 2:
                break;

            //////////////////////////////    3 = Young Adult    //////////////////////////////
            case 3:
                break;

            //////////////////////////////    4 = Adult          //////////////////////////////
            case 4:
                break;

            //////////////////////////////    5 = Elderly        //////////////////////////////
            case 5:
                break;
        }


        

        moveSpeed = energy / 20;

        if (Input.GetAxisRaw("Horizontal") > 0.1f|| Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f));
            energy = energy - moveCost*Time.deltaTime;
        }

        if (Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f)
        {
            transform.Translate(new Vector2(0f,Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime));
            energy = energy - moveCost * Time.deltaTime;
        }

        test = FloorToInt(player.position/1.75f);

        TilemapController Script = GameObject.FindGameObjectWithTag("GameController").GetComponent<TilemapController>();
        energy = energy + Script.Eat(test,appitite);

        if (energy > 100){energy = 100;}
    }

    void Death()
    {
        gameObject.SetActive(false);
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
