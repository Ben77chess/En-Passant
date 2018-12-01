using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFaceCamera : MonoBehaviour {

    private CameraControl camCtrl;
    private Camera[] camList;
    private Camera currCam;

    Transform cameraTransform;
	// Use this for initialization
	void Start () {
        /*
        foreach (Camera cam in camList)
        {
            if(cam.enabled == true)
            {
                currCam = cam;
            }
        }

        cameraTransform = currCam.transform;
        */
        cameraTransform = Camera.main.transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        /*
        foreach (Camera cam in camList)
        {
            if(cam.enabled == true)
            {
                currCam = cam;
            }
        }

        cameraTransform = currCam.transform;
        */


        Vector3 temp = transform.position - cameraTransform.position;
        temp.y = 0;
        transform.rotation = Quaternion.LookRotation(temp, Vector3.up);
	}
}
