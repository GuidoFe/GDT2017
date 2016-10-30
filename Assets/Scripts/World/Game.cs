using UnityEngine;
using System.Collections;

public class Game:MonoBehaviour {
    Matrix m;
    void Start() {
        m = GetComponent<Matrix>();
        m.generateLevel(50, 50);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
