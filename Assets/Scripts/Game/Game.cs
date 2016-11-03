using UnityEngine;
using System.Collections;

public class Game:MonoBehaviour {
    public GameObject terrain;
    void Start() { 
        generateLevel(50, 50, "tile");
        terrain.name = "Terrain";
    }
	// Update is called once per frame
	void Update () {
	
	}

    public void generateLevel(int nx, int ny, string nameTerrain) {
        terrain = Instantiate (Resources.Load("Prefabs/Terrain", typeof(GameObject))) as GameObject;
        terrain.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_MainTex", Resources.Load("Sprites/" + nameTerrain) as Texture);
        terrain.transform.position = Vector3.zero;
        terrain.transform.localScale = new Vector3(nx, ny, 1);
        terrain.GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(nx, ny);
    }
}
