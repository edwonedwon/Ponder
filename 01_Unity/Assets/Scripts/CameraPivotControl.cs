using UnityEngine;
using System.Collections;

public class CameraPivotControl : MonoBehaviour {
	
	private	float rotateSpeed = -1; 
	private float zoomSpeed = 0.3f;
	private float minZoom = 10f;
	private float maxZoom = 35f;
	
	private Vector3 defaultCameraPosition;
	private Transform cameraTransform;
	private Quaternion defaultCameraRotation;
	
	// Use this for initialization
	void Start () {
		cameraTransform = transform.Find("Main Camera");
		defaultCameraRotation = transform.rotation;
		defaultCameraPosition = cameraTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// rotate around horizontal axis (left, right arrows)
		transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotateSpeed, Space.World);
		
		// zoom on vertical axis (up, down arrows)
		float zoomMagnitude = cameraTransform.position.magnitude;
		float zoomAxis = Input.GetAxis("Vertical");
		if((zoomMagnitude >= minZoom || zoomAxis < 0) &&
			(zoomMagnitude <= maxZoom || zoomAxis > 0)) {
			cameraTransform.Translate(0, 0, zoomAxis * zoomSpeed);
		}
		
		// jump to reset camera (space)
		if(Input.GetButtonDown("Jump")) {
			transform.rotation = defaultCameraRotation;
			cameraTransform.position = defaultCameraPosition;
		}
	}
}
