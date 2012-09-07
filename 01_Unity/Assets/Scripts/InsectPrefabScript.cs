using UnityEngine;
using System.Collections;

public class InsectPrefabScript : MonoBehaviour {
	
	private GameObject mainTreeLeaves;
	private GameObject targetPlant;
	
	public float speed = 50;
	
	private int pollen = 0;
	private int pollenCapacity = 20;
	
	// Use this for initialization
	void Start () {
		mainTreeLeaves = GameObject.Find("Main Tree Leaves"); //.GetComponent<MainTreeLeavesScript>();
		// get 'em moving randomly
		rigidbody.AddForce(RandomForce(speed));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// every plant and main tree attracts the insects
		GameObject[] plants = GameObject.FindGameObjectsWithTag("plant");
		foreach(GameObject plant in plants) {
			AddForceToObject(plant);
		}
		AddForceToObject(mainTreeLeaves);
	}
	
	void OnCollisionEnter(Collision collision) {
		// ignore collisions with other insects and plants
		if(collision.gameObject.CompareTag("insect") || collision.gameObject.CompareTag("plant")) {
			Physics.IgnoreCollision(this.collider, collision.collider, true);
		}
	}
	
	void AddForceToObject(GameObject target) {
		float magnitude = 1 / Vector3.Distance (transform.position, target.transform.position);
		rigidbody.AddForce(magnitude * (target.transform.position - transform.position));
	}
	
	float RandomMovement() {
		return Random.Range(-5, 5);
	}
		
	Vector3 RandomForce(float magnitude = 1) {
		Vector3 vec = new Vector3(RandomMovement(), RandomMovement(), RandomMovement());
		vec.Normalize();
		return vec * magnitude;
	}
}
