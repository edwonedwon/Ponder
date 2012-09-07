using UnityEngine;
using System.Collections;

public class FingerGesturesManagerScript : MonoBehaviour {
	
	public GameObject insect;
	
	public GameLogicScript gameLogic;
	
	void Start() {
		gameLogic = GameObject.Find("Game Logic").GetComponent<GameLogicScript>();
	}
	
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
			gameLogic.AddPlant(hit.point);
			//Instantiate(insect, hit.point, Quaternion.identity);
		}

	}
			
}
