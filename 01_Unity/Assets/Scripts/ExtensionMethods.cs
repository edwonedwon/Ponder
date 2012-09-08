using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ExtensionMethods {

	public static GameObject FindClosest(this IEnumerable<GameObject> array, Vector3 targetPosition) {
		float optimal = 10000;
		GameObject bestTarget = null;
		foreach(GameObject obj in array) {
			var dist = Vector3.Distance(targetPosition, obj.transform.position);
			if (dist < optimal) {
				optimal = dist;
				bestTarget = obj;
			}
		}
		
		return bestTarget;
	}
}
