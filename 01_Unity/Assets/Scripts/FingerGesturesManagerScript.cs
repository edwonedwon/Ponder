using UnityEngine;
using System.Collections;

public class FingerGesturesManagerScript : MonoBehaviour {
	
	public GameObject circlePlant;
	
	void OnEnable () {
		FingerGestures.OnFingerDown += OnFingerDown;
	}
	
	void OnDisable () {
		FingerGestures.OnFingerDown -= OnFingerDown;
	}
	
	void OnFingerDown (int finger, Vector2 pos) {
		
		RaycastHit hit;
		Physics.Raycast(Camera.main.ScreenPointToRay(pos), out hit);
		print(hit.point);
		if (hit.collider.tag == "island") {
			Instantiate(circlePlant, hit.point, Quaternion.identity);
		}

	}
			
}
