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
				Random.Range(treeLeavesPos.x - randPosRange, treeLeavesPos.x + randPosRange), 
				Random.Range(treeLeavesPos.y - randPosRange, treeLeavesPos.y + randPosRange),
				Random.Range(treeLeavesPos.z - randPosRange, treeLeavesPos.z + randPosRange)
			);
			Instantiate(insect, spawnPoint, Quaternion.identity); 
		}
	}
	
	void Update () {
		
	}
}
