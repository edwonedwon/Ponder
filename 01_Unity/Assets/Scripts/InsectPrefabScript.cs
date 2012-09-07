using UnityEngine;
using System.Collections;
using System.Linq;

public class InsectPrefabScript : MonoBehaviour {
	
	private GameLogicScript gameLogic;
	
	private GameObject mainTreeLeaves;
	private GameObject targetPlant;
	
	public float speed = 50;
	
	private float pollen = 0;
	public float pollenCapacity = 1;
	public float collectionSpeed;
	
	// Use this for initialization
	void Start () {
		gameLogic = GameObject.Find("Game Logic").GetComponent<GameLogicScript>();
		
		targetPlant = mainTreeLeaves = GameObject.Find("Main Tree Leaves");
		// get 'em moving randomly
		rigidbody.AddForce(RandomForce(speed));
		
		rigidbody.maxAngularVelocity = 5f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// if insect has no target or at tree with no pollen then find new target!
		if (targetPlant == null || (targetPlant == mainTreeLeaves && pollen == 0))
			FindNewTarget();
		
		// if insect is full and not headed home, send it home!
		if(pollen >= pollenCapacity && targetPlant != mainTreeLeaves) {
			Comment ("I am heading for the tree!");
			ChangeTarget(mainTreeLeaves);
		}
		
		// move towards target
		AddForceTowardObject(targetPlant);
	}
	
	void OnCollisionEnter(Collision collision) {
		// ignore collisions with other insects
		if(collision.gameObject.CompareTag("insect")) {
			Physics.IgnoreCollision(this.collider, collision.collider, true);
		}
		
		// if the insect hits the tree then transfer pollen and find a new target
		if(collision.gameObject.CompareTag("tree")) {
			collision.gameObject.GetComponent<MainTreeLeavesScript>().pollen += this.pollen;
			this.pollen = 0;
			FindNewTarget();
		}
	}
	
	void OnCollisionStay(Collision collision) {
		// transfer some pollen when an insect collides with its plant target
		if(collision.gameObject.Equals(targetPlant) && collision.gameObject.CompareTag("plant")) {
			var script = collision.gameObject.GetComponent<CirclePlantPrefabScript>();
			// collect a small quantity of pollen each time until the plant is empty
			if(script.pollen > 0) {
				this.pollen += Mathf.Min (collectionSpeed, script.pollen);
				script.pollen -= collectionSpeed;
			} else {
				// when the plant is empty, find a new target
				FindNewTarget(); 
			}
			Comment ("BOOM hit my target! pollen {0}/{1}", pollen, pollenCapacity);
		}
	}
	
	void OnTriggerEnter(Collider collider) {
		// when an insect collides with its plant target...
		if(collider.gameObject.Equals(targetPlant) && collider.gameObject.CompareTag("plant")) {
			// transfer some pollen over, only as much as insect can carry
			var script = collider.gameObject.GetComponent<CirclePlantPrefabScript>();
			float available = pollenCapacity - pollen;
			float collected = Mathf.Min (script.pollen, available);
			this.pollen += collected;
			script.pollen -= collected;
			Comment ("BOOM hit my target! pollen {0}/{1}", pollen, pollenCapacity);
			// and find a new best target
			FindNewTarget();
		}
	}
	
	// finds the closest untargeted plant or the tree
	void FindNewTarget() {
		GameObject[] plants = GameObject.FindGameObjectsWithTag("plant");
		float optimal = 10000;
		GameObject bestTarget = null;
		foreach(GameObject plant in plants) {
			var script = plant.GetComponent<CirclePlantPrefabScript>();
			var dist = Vector3.Distance(transform.position, plant.transform.position);
			if (!script.IsTargeted && dist < optimal) {
				optimal = dist;
				bestTarget = plant;
			}
		}
		ChangeTarget(bestTarget ?? mainTreeLeaves);
	}
	
	// changes the target and sets insect color
	void ChangeTarget(GameObject target) {
		// clear old target and set new one
		if(targetPlant.CompareTag("plant")) {
			targetPlant.GetComponent<CirclePlantPrefabScript>().IsTargeted = false;
		}
		
		if(target != targetPlant)
			Comment ("New target: {0}", target);
		targetPlant = target;
		// then colorize insect based on target
		// white=null, green=plant, yellow=tree+full, orange=tree+unfull, red=tree+empty
		if(targetPlant == null) {
			renderer.material.color = Color.white;
		}
		else if(targetPlant.CompareTag("plant")) {
			renderer.material.color = Color.green;
			targetPlant.GetComponent<CirclePlantPrefabScript>().IsTargeted = true;
		}
		else if(targetPlant.CompareTag("tree")) {
			if(pollen > 0) {
				renderer.material.color = pollen < pollenCapacity ? Color.Lerp(Color.red, Color.yellow, 0.5f) : Color.yellow;
			}
			else renderer.material.color = Color.red;
		}
	}
		
	void AddForceTowardObject(GameObject target) {
		float magnitude = 1 / Vector3.Distance (transform.position, target.transform.position);
		rigidbody.AddForce(magnitude * (target.transform.position - transform.position));
	}
	
	float RandomMovement() {
		return Random.Range(-5, 5);
	}
		
	Vector3 RandomForce(float magnitude = 1) {
		Vector3 vec = new Vector3(RandomMovement(), RandomMovement(), RandomMovement());
		vec.Normalize();
		return vec * magnitude;
	}
	
	void Comment(string format, params object[] args) {
		print (this.name + ": " + string.Format(format, args));
	}
}
