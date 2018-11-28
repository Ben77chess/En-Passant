using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFaceCamera : MonoBehaviour {

    Transform cameraTransform;
	// Use this for initialization
	void Start () {
        cameraTransform = Camera.main.transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 temp = transform.position - cameraTransform.position;
        temp.y = 0;
        transform.rotation = Quaternion.LookRotation(temp, Vector3.up);
	}
}
