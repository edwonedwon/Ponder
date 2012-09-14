using UnityEngine;
using System.Collections;

public class MainTreeLeavesScript : MonoBehaviour {
	
	public int attractionPower;
	
	public float pollen;
	public float health;
	
	private float maximumHealth = 100f;
	
	private int bugsOnTree;

	void Start () {
		attractionPower = 10;
		pollen = 100;
		
		health = maximumHealth;
	}
	
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.CompareTag("insect")) {
			bugsOnTree++;
		}
	}
	
	void OnCollisionExit(Collision collision) {
		if(collision.gameObject.CompareTag("insect")) {
			bugsOnTree--;
		}
	}
	
	void OnGUI() {
		string message = string.Format("Pollen: {0}\nPlants: {1}\nInsects: {2}", 
			Mathf.RoundToInt(pollen),
			GameObject.FindGameObjectsWithTag("plant").Length,
			GameObject.FindGameObjectsWithTag("insect").Length);
		GUI.Label (new Rect(10, 10, 100, 60), message);
			
		var screenPos = Camera.main.WorldToScreenPoint(transform.position);
		GUI.Label(new Rect(screenPos.x, Camera.main.pixelHeight - screenPos.y, 200, 20),
			string.Format("Health: {0}/{1} ({2} bugs)", health, maximumHealth, bugsOnTree));	
		
	}
}
