using UnityEngine;
using System.Collections;

public class MainTreeLeavesScript : MonoBehaviour {
	
	public int attractionPower;
	
	public float pollen;

	void Start () {
		attractionPower = 10;
	}
	
	void Update () {
		
	}
	
	void OnGUI() {
		GUI.Label (new Rect(10, 10, 100, 20), "Pollen: " + Mathf.RoundToInt(pollen));
		GUI.Label (new Rect(10, 30, 100, 20), "Plants: " + GameObject.FindGameObjectsWithTag("plant").Length);
		GUI.Label (new Rect(10, 50, 100, 20), "Insects: " + GameObject.FindGameObjectsWithTag("insect").Length);
	}
}
