using UnityEngine;
using System.Collections;

public class LichenPrefabScript : MonoBehaviour {
	
	GameObject island;
	public GameObject lichenPrefab;

	void Start () {
		island = GameObject.Find("Island");
	}
	
	void Update () {
		
		Reproduce();
		
	}
	
	void Reproduce () {
		
		RaycastHit hit;
		
		Vector3 directionToIsland = island.transform.position - transform.position;
		
		// set ray start position and randomize a little
		Vector3 lichenRayPosition = (transform.position - Vector3.Normalize(directionToIsland) * 2) + new Vector3 (Random.Range(3,6),Random.Range(3,6), 0); 
		
		Ray lichenRay = new Ray(lichenRayPosition, directionToIsland);
		
		Physics.Raycast(lichenRay, out hit);
		Debug.DrawRay(lichenRay.origin, lichenRay.direction);

			
		Vector3 spawnPos;
		
		if (hit.collider.tag == "island") {
			Instantiate(lichenPrefab, hit.point, Quaternion.LookRotation(hit.normal));	
		}

		if (hit.collider.tag == "lichen" && hit.collider != this.collider) {
			print ("I hit lichen");	
		}
		
//		if (hit.collider.tag == "island") {
//				print ("I hit the island!");
//		}
	}
}
