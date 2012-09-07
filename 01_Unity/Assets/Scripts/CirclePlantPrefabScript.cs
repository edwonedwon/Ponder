using UnityEngine;
using System.Collections;

public class CirclePlantPrefabScript : MonoBehaviour {
	
	public float attractionPower;
	//public float health;
	//public float healthTotal;
	public float pollenSpeed;
	public float pollen;
	public float pollenCapacity = 5;
	
	private bool targeted = false;
	private float fallowTime;
	
	public bool IsTargeted {
		get { return targeted; }
		set { targeted = value; }
	}
	
	void Start () {
		attractionPower = 10;
	}
	
	void FixedUpdate () {
		// plant produces pollen over time, up to capacity, and grows larger
		if(pollen <= pollenCapacity)
			pollen += pollenSpeed;
		transform.localScale = Vector3.one / 2 + new Vector3 (pollen, pollen, pollen) / pollenCapacity;
		
		// change material color when targeted
		renderer.material.color = targeted ? Color.green : Color.gray;
		
		// track how long this plant is untargeted AND fully grown.
		// if the time gets large enough the plant will begin to die.
		if(!IsTargeted && pollen >= pollenCapacity) {
			fallowTime += Time.deltaTime;
		} else {
			fallowTime = 0;
		}
	}
	
	void OnGUI() {
		// render a label showing how long this plant has been untargeted
		if(fallowTime > 0) {
			var screenPos = Camera.main.WorldToScreenPoint(transform.position);
			GUI.Label(new Rect(screenPos.x, Camera.main.pixelHeight - screenPos.y, 40, 20), "" + Mathf.RoundToInt(fallowTime));	
		}
	}
	

}
