using UnityEngine;
using System.Collections;

public class CameraPivotControl : MonoBehaviour {
	
	public float rotateSpeed; 
	public float zoomSpeed;
	public float minZoom;
	public float maxZoom;
	
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
		transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotateSpeed, Space.World);
		
		float zoomMagnitude = cameraTransform.position.magnitude;
		float zoomAxis = Input.GetAxis("Vertical");
		if((zoomMagnitude >= minZoom || zoomAxis < 0) &&
			(zoomMagnitude <= maxZoom || zoomAxis > 0))
			cameraTransform.Translate(0, 0, zoomAxis * zoomSpeed);
		
		if(Input.GetButtonDown("Jump")) {
			transform.rotation = defaultCameraRotation;
			cameraTransform.position = defaultCameraPosition;
		}
	}
}
