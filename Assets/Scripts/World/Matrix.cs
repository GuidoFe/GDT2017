using UnityEngine;
using System.Collections;

public class Matrix:MonoBehaviour{
    int x=20;
    int y=20;
    public GameObject[,] world;
    public GameObject map;
    // Use this for initialization
public void Start(){

    }
	// Update is called once per frame
	void Update () {
	
	}

    public void generateLevel(int nx, int ny) {
        map = new GameObject();
        map.name = "map";
        world = new GameObject[nx, ny];
        for(int r = 0; r < ny; r++) {
            for(int c = 0;c < nx; c++) {
                world[c, r] = new GameObject();
                world[c, r].transform.position = new Vector3(c, r, 4);
                world[c, r].transform.SetParent(map.transform);
                world[c, r].name = "Tile [" + c + "," + r + "]";
                world[c, r].AddComponent<SpriteRenderer>();
                world[c, r].GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/tile", typeof(Sprite)) as Sprite;
            }
        }
    }
}
