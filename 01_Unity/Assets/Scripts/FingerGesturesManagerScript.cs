using UnityEngine;
using System.Collections;

public class FingerGesturesManagerScript : MonoBehaviour {
	
	public GameObject circlePlant;
	public GameObject insect;
	
	void OnEnable () {
		FingerGestures.OnFingerDown += OnFingerDown;
	}
	
	void OnDisable () {
		FingerGestures.OnFingerDown -= OnFingerDown;
	}
	
	void OnFingerDown (int finger, Vector2 pos) {
		
		RaycastHit hit;
		Physics.Raycast(Camera.main.ScreenPointToRay(pos), out hit);
		
		if (hit.collider.tag == "island") {
			Instantiate(circlePlant, hit.point, Quaternion.identity);
			Instantiate(insect, hit.point, Quaternion.identity);
		}

	}
			
}
