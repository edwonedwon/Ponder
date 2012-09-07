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
		GUI.Label(new Rect(10, 10, 100, 20), "Pollen: " + Mathf.RoundToInt(pollen));
	}
}
