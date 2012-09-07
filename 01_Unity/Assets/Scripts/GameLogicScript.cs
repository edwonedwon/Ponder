using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogicScript : MonoBehaviour {
	
	public GameObject circlePlant;
	public GameObject insect;
	
	public int startInsects;
	public int randPosRange;
	private GameObject mainTreeLeaves;
	private MainTreeLeavesScript treeScript;
	
	private List<GameObject> plantList;
	
	public List<GameObject> Plants {
		get { return plantList; }
	}
	
	void Start () {
		plantList = new List<GameObject>();
		mainTreeLeaves = GameObject.Find("Main Tree Leaves");
		treeScript = mainTreeLeaves.GetComponent<MainTreeLeavesScript>();
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
		// left/right brackets delete/spawn insects
		if(Input.GetKeyDown(KeyCode.LeftBracket)) {
			Destroy (GameObject.FindGameObjectWithTag("insect"));
			foreach(GameObject plant in GameObject.FindGameObjectsWithTag("plant")) {
				plant.GetComponent<CirclePlantPrefabScript>().IsTargeted = false;
			}
		}
		else if(Input.GetKeyDown(KeyCode.RightBracket)) {
			AddInsect(mainTreeLeaves.transform.position);
		}
		
		if(Input.GetKeyDown(KeyCode.Alpha1)) 
			treeScript.pollen += 100;
	}
	
	public GameObject AddPlant(Vector3 position) {
		if(treeScript.pollen >= 50) {
			treeScript.pollen -= 50;
			var plant = Instantiate(circlePlant, position, Quaternion.identity) as GameObject;
			plantList.Add(plant);
			return plant;
		}
		return null;
	}
	
	public GameObject AddInsect(Vector3 position) {
		return Instantiate(insect, position, Quaternion.identity) as GameObject;
	}
}
