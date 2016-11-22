using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {
    RaycastHit hitInfo;
    public GameObject mouseGrid;
    Vector3 drawPoint = Vector3.zero;
    // Use this for initialization
    void Start () {
        mouseGrid = Instantiate(Resources.Load("Prefabs/selectionGrid", typeof(GameObject)) as GameObject);
        mouseGrid.name = "mouseGrid";
        mouseGrid.SetActive(false);
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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo)) {
                //Debug.Log("Hit");
                drawPoint = hitInfo.point;
                drawPoint.z = -1;
                drawPoint.x = Mathf.Floor(drawPoint.x) + 0.5f;
                drawPoint.y = Mathf.Floor(drawPoint.y) + 0.5f;
                Vector2 matrixPos = new Vector2(drawPoint.x + Mathf.Floor(this.transform.position.x), drawPoint.y + Mathf.Floor(this.transform.position.y));
                GameObject Tile = Instantiate(Resources.Load("Prefabs/Tile", typeof(GameObject)) as GameObject);
                Tile.transform.position = drawPoint;
                Tile.name = "Tile " + matrixPos.x + "," + matrixPos.y;
                Tile.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/road_v_v_b", typeof(Sprite)) as Sprite;
            }
        }
	}
}
