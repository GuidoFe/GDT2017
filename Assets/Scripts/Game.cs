using UnityEngine;
using System.Collections;

public class Game:MonoBehaviour {
    public GameObject terrain;
    public GameObject[,] matrix;
    void Start() { 
        matrix = generateLevel(50, 50, "grass");
        terrain.name = "Terrain";
    }
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject[,] generateLevel(int nx, int ny, string nameTerrain) {
        terrain = Instantiate (Resources.Load("Prefabs/Terrain", typeof(GameObject))) as GameObject; //Istanzia il quad terrain 1x1
        terrain.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_MainTex", Resources.Load("Sprites/" + nameTerrain) as Texture); //setta la texture
        terrain.transform.position = new Vector3(nx/2, ny/2, 1); //lo sposta in modo che i bordi inferiori della griglia coincidano con gli assi
        terrain.transform.localScale = new Vector3(nx, ny, 1); //Scala la mesh
        terrain.GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(nx, ny); //scala la texture a scacchiera
        GameObject[,] m = new GameObject[nx, ny];
        return m;
    }
}
