using UnityEngine;
using System.Collections;

public class CameraPivotControl : MonoBehaviour {
	
	public float rotateSpeed; 
	
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
		transform.Rotate(Vector3.up, Input.GetAxis("Horizontal")*rotateSpeed, Space.World);
		cameraTransform.Translate(Vector3.forward * Input.GetAxis("Vertical"));
		
		if(Input.GetButtonDown("Jump")) {
			transform.rotation = defaultCameraRotation;
			cameraTransform.position = defaultCameraPosition;
		}
	}
}
