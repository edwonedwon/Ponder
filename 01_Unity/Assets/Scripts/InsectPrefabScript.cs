using UnityEngine;
using System.Collections;

public class InsectPrefabScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(RandomMovement(), RandomMovement(), RandomMovement());
	}
	
	float RandomMovement() {
		return Random.Range(-1, 1) / 10f;
	}
}
