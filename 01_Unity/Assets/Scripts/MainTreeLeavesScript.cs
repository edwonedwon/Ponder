using UnityEngine;
using System.Collections;

public class MainTreeLeavesScript : MonoBehaviour {
	
	public int attractionPower;
	
	public float pollen;

	void Start () {
		attractionPower = 10;
		pollen = 100;
	}
	
	void Update () {
		
	}
	
	void OnGUI() {
		string message = string.Format("Pollen: {0}\nPlants: {1}\nInsects: {2}", 
			Mathf.RoundToInt(pollen),
			GameObject.FindGameObjectsWithTag("plant").Length,
			GameObject.FindGameObjectsWithTag("insect").Length);
		GUI.Label (new Rect(10, 10, 100, 60), message);
	}
}
