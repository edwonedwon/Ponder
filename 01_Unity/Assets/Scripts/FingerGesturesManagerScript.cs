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
		
		if (hit.collider.CompareTag("island")) {
			gameLogic.AddPlant(hit.point);
			//Instantiate(insect, hit.point, Quaternion.identity);
		}
		if(hit.collider.CompareTag("plant")) {
			if(hit.collider.gameObject.Equals(gameLogic.markedPlant))
				gameLogic.markedPlant = null;
			else
				gameLogic.markedPlant = hit.collider.gameObject;
		}
	}
			
}
