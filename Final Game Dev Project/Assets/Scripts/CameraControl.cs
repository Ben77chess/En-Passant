using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {


    public Camera[] cameras;
    private int camIndex;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == 0)
            {
                cameras[i].enabled = true;
            }
            else
            {
                cameras[i].enabled = false;
            }
        }

        camIndex = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            cameras[camIndex].enabled = false;
            camIndex++;
            if (camIndex >= cameras.Length)
            {
                camIndex = 0;
            }
            cameras[camIndex].enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cameras[camIndex].enabled = false;
            camIndex--;
            if (camIndex < 0)
            {
                camIndex = cameras.Length-1;
            }
            cameras[camIndex].enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (camIndex != 0)
            {
                cameras[camIndex].enabled = false;
                cameras[0].enabled = true;
                camIndex = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (camIndex != 1)
            {
                cameras[camIndex].enabled = false;
                cameras[1].enabled = true;
                camIndex = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (camIndex != 2)
            {
                cameras[camIndex].enabled = false;
                cameras[2].enabled = true;
                camIndex = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (camIndex != 3)
            {
                cameras[camIndex].enabled = false;
                cameras[3].enabled = true;
                camIndex = 3;
            }
        }


    }
}
