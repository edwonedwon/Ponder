using UnityEngine;
using System.Collections;

public class GameLogicScript : MonoBehaviour {
	
	public GameObject insect;
	public int startInsects;
	public int randPosRange;
	private GameObject mainTreeLeaves;

	void Start () {
		
		mainTreeLeaves = GameObject.Find("Main Tree Leaves");
		Vector3 treeLeavesPos = mainTreeLeaves.transform.position;
	
		for (int i = 0; i < startInsects; i++) {
			Vector3 spawnPoint = new Vector3 (
				treeLeavesPos.x + Random.Range(-randPosRange, randPosRange), 
				treeLeavesPos.y + Random.Range(-randPosRange, randPosRange),
				treeLeavesPos.z + Random.Range(-randPosRange, randPosRange));
			Instantiate(insect, spawnPoint, Quaternion.identity); 
		}
	}
	
	void Update () {
		
	}
}
