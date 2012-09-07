using UnityEngine;
using System.Collections;

public class CirclePlantPrefabScript : MonoBehaviour {
	
	public float attractionPower;
	public float health;
	public float healthTotal;
	public float pollenSpeed;
	public float pollenTotal;

	void Start () {
		attractionPower = 10;
	}
	
	void FixedUpdate () {
		if (transform.lossyScale.x < pollenTotal) {
			transform.localScale += new Vector3 (pollenSpeed, pollenSpeed, pollenSpeed) / 100;
		}
	}
}
