using UnityEngine;
using System.Collections;

public class Tile:MonoBehaviour{
    public static int l = 100; //lato
    string SpritePath = "tile";
    GameObject tile;
    Vector3 initPosition;
    public Tile()
    {

    }
    public Tile(float posx, float posy){
        //Debug.Log("Sprite creato");
        initPosition = new Vector3(posx, posy, 2);
    }
	// Use this for initialization
	void Start () {
        this.transform.position = initPosition;
        this.gameObject.AddComponent<SpriteRenderer>();
        tile.GetComponent<SpriteRenderer>().sprite = Resources.Load(SpritePath, typeof(Sprite)) as Sprite;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
