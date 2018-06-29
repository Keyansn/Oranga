using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour
{
    public IDictionary<string, MapTileClass> tileDictionary = new Dictionary <string, MapTileClass>();
    //public List<maptileclass> tileInfo = new List<maptileclass>();
    //public TileData tileDataHolder;
    public Tilemap tilemap;
    public TileBase highfood;
    public TileBase midfood;
    public TileBase lowfood;

    // Use this for initialization
    void Start() {
        Createthemap();
    }
    // Update is called once per frame
    void Update()
    {

        print(tileDictionary["1,1"]);
        print(tileDictionary["2,1"].food);
        //print(tilemap.localBounds);
        
        for (int i = -5; i < 5; i++)
        {
            for (int j = -5; j < 5; j++)
            {
                //FOOD CALCULATIONS 

                float foodHolder;
                foodHolder = tileDictionary[i + "," + j].food;

                foodHolder = foodHolder + 0.1f * Time.deltaTime;
                if (foodHolder > 5)
                {
                    foodHolder = 5;
                }

                if (foodHolder >= 4)
                {
                    tilemap.SetTile(new Vector3Int(i, j, 1), highfood);
                }

                if ((2 < foodHolder)&&(foodHolder<4))
                {
                    tilemap.SetTile(new Vector3Int(i, j, 1), midfood);
                }

                if (2 > foodHolder)
                {
                    tilemap.SetTile(new Vector3Int(i, j, 1), lowfood);
                }



                tileDictionary[i + "," + j].food = foodHolder;
            }
        }
    }

    public float Eat(Vector3Int loc, float _appitite)
    {
        tileDictionary[loc.x + "," + loc.y].food = tileDictionary[loc.x + "," + loc.y].food - _appitite*Time.deltaTime;
        if(tileDictionary[loc.x + "," + loc.y].food < 0)
        {
            tileDictionary[loc.x + "," + loc.y].food = 0;
        }

        return _appitite * Time.deltaTime;
    }


    void Createthemap()
    {
        for (int i = -5; i < 5; i++)
        {
            for (int j = -5; j < 5; j++)
            {
                tilemap.SetTile(new Vector3Int(i, j, 1), highfood);

                string temp = i + "," + j;
                
                tileDictionary.Add(temp,new MapTileClass(1,1));
                //coords.Clear();
            }

            //tilemap.SetTile(new Vector3Int(1,1,1), tb);
        }
    }

    
}

[System.Serializable]
public class MapTileClass
{

    //  CLASS VARIABLES
    public float food;
    public float temp;

    //  CLASS CONSTRUCTORS
    public MapTileClass(float _food, float _temp)
    {
        food = _food;
        temp = _temp;
    }

    //  CLASS METHODS
}
