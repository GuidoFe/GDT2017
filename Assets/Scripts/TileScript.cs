using UnityEngine;
using System.Collections;

public class TileScript:MonoBehaviour{
    public Vector2 matrixPos;
    public GameObject[] layer = new GameObject[8];
    private int nSprites;
	// Use this for initialization
	void Start () {
        matrixPos = Vector2.zero;
        nSprites = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public bool addSprite(string file) {
        if (nSprites < 8) {
            layer[nSprites] = new GameObject();
            Vector3 v = this.transform.position;
            Debug.Log(nSprites);
            v.z = ((float)nSprites) / 10;    
            layer[nSprites].AddComponent<SpriteRenderer>();
            layer[nSprites].GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/" + file, typeof(Sprite)) as Sprite;
            layer[nSprites].transform.parent = this.transform;
            layer[nSprites].transform.position = v;
            nSprites++;
            return true;
        }
        else return false;
    }
}
