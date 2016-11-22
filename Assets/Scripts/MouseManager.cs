using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {
    RaycastHit hitInfo;
    public GameObject mouseGrid;
    Vector3 drawPoint = Vector3.zero; //punto di spawn del tile
    int nLayers; // n GameObjects figli dell'oggetto, che hanno il compito di tenere uno sprite.
    // Use this for initialization
    void Start () {
        mouseGrid = Instantiate(Resources.Load("Prefabs/selectionGrid", typeof(GameObject)) as GameObject);
        mouseGrid.name = "mouseGrid";
        mouseGrid.SetActive(false);
        nLayers = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Cursor.visible) {
            mouseGrid.SetActive(true);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo)) {
                drawPoint = hitInfo.point;
                drawPoint.z = -2;
                drawPoint.x = Mathf.Floor(drawPoint.x) + 0.5f;
                drawPoint.y = Mathf.Floor(drawPoint.y) + 0.5f;
                mouseGrid.transform.position = drawPoint;
            }
            else mouseGrid.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Lanca un raggio "dallo schermo" alla scena
            if (Physics.Raycast(ray, out hitInfo)) {
                //Debug.Log("Hit");
                drawPoint = hitInfo.point; 
                Vector2 matrixPos = new Vector2(Mathf.Floor(drawPoint.x), Mathf.Floor(drawPoint.y)); //Coord nella matrice
                if (GetComponent<Game>().matrix[(int)matrixPos.x, (int)matrixPos.y] == null) { //se l'oggetto tessera non � ancora stato creato
                    drawPoint.z = 0;
                    drawPoint.x = Mathf.Floor(drawPoint.x) + 0.5f;
                    drawPoint.y = Mathf.Floor(drawPoint.y) + 0.5f;
                    GameObject Tile = Instantiate(Resources.Load("Prefabs/Tile", typeof(GameObject)) as GameObject); //Creazione del tile
                    Tile.transform.position = drawPoint; //lo sposta in drawpoint
                    Tile.name = "Tile " + matrixPos.x + "," + matrixPos.y; //lo nomina con le sue coordinate
                    Tile.GetComponent<TileScript>().matrixPos = matrixPos;
                    Tile.GetComponent<TileScript>().addSprite("road_v_v_b");
                    GetComponent<Game>().matrix[(int)matrixPos.x, (int)matrixPos.y] = Tile;
                }
                else {
                    GetComponent<Game>().matrix[(int)matrixPos.x, (int)matrixPos.y].GetComponent<TileScript>().addSprite("road_v_v_b");
                } 
            }
        }
	}
}
