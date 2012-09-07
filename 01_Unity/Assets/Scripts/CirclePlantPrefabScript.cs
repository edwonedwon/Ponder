using UnityEngine;
using System.Collections;

public class CirclePlantPrefabScript : MonoBehaviour {
	
	public float attractionPower;
	//public float health;
	//public float healthTotal;
	public float pollenSpeed;
	public float pollenTotal;
	public float pollenCapacity = 5;
	
	private bool targeted = false;
	
	public bool IsTargeted {
		get { return targeted; }
		set { targeted = value; }
	}
	
	void Start () {
		attractionPower = 10;
	}
	
	void FixedUpdate () {
		// plant produces pollen over time, up to capacity, and grows larger
		if(pollenTotal <= pollenCapacity)
			pollenTotal += pollenSpeed;
		transform.localScale = Vector3.one / 2 + new Vector3 (pollenTotal, pollenTotal, pollenTotal) / 50;
		
		// change material color when targeted
		renderer.material.color = targeted ? Color.green : Color.gray;
	}
}
