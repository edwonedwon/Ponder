using UnityEngine;
using System.Collections;

public class LichenPrefabScript : MonoBehaviour {
	
	GameObject island;
	GameObject tree;
	public GameObject lichenPrefab;
	public float growTime;
	
	float growCounter;
	
	bool reproducify = true;
	
	Vector3 spawnDirection;
	
	void Start () {
		island = GameObject.Find("Island");
		tree = GameObject.Find ("Main Tree");
		transform.localScale = Vector3.zero;
		
		var target = tree;
		var rock = FindClosestRock();
		if(rock != null && Vector3.Distance(rock.transform.position, transform.position) < Vector3.Distance (tree.transform.position, transform.position)) {
			target = rock;
		}
		
		spawnDirection = Vector3.Normalize(target.transform.position - transform.position + 
			new Vector3(Random.Range (-2f, 2f),Random.Range (-2f, 2f), 0));
	}
	
	void FixedUpdate () {
		if(reproducify) {
			growCounter += Time.deltaTime;
			transform.localScale = new Vector3 (growCounter, growCounter, growCounter / 2) / growTime;
			// reproduce once per time period
			if(growCounter > growTime) {
				Reproduce();
				growCounter = 0;
			}
		}
	}
	
	GameObject FindClosestRock() {
		var rocks = GameObject.FindGameObjectsWithTag("rock");
		return rocks.FindClosest(transform.position);
	}
	
	void Reproduce () {
		reproducify = false;
		RaycastHit hit;
		
		// set ray start position and randomize a little
		// at lichen position towards tree and a little above island
		Vector3 lichenRayPosition = transform.position + spawnDirection + Vector3.up * 2;
		
		// cast a ray down through the island to find the point to spawn next lichen
		Ray lichenRay = new Ray(lichenRayPosition, Vector3.down);
		Physics.Raycast(lichenRay, out hit);
		Debug.DrawRay(lichenRay.origin, lichenRay.direction);
		
		print ("lichen ray hits " + hit.collider.tag);
		
		// if we hit the island then spawn a lichen there, otherwise try again.
		if (hit.collider.CompareTag("island") || hit.collider.CompareTag("rock")) {
			Instantiate(lichenPrefab, hit.point, Quaternion.LookRotation(hit.normal));	
		} else {
			reproducify = true;
		}
	}
}
