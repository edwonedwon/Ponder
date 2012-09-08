using UnityEngine;
using System.Collections;

public class SnailPrefabScript : MonoBehaviour {
	
	GameObject lichen;
	
	public float speed;

	void Start () {
		lichen = GameObject.Find("Lichen Prefab");
		transform.LookAt(lichen.transform.position);

	}
	
	void Update () {
	}
	
	void FixedUpdate () {
		Vector3 heading = (lichen.transform.position - transform.position).normalized;
//		print (heading);
		print (heading * speed);
		rigidbody.AddForce(heading * speed);
	}
}
