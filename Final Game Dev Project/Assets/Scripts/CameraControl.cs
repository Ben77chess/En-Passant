using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour {


    public Camera[] cameras;
    public Canvas ui;
    public Text text;

    private int camIndex;

	// Use this for initialization
	void Start () {


        ui.worldCamera = cameras[0];
        

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
        text.text = string.Format("{0} {1}", "CAMERA", (camIndex + 1).ToString());
        text.fontStyle = FontStyle.Bold;
        text.fontSize = 18;
    }

    public void LeftButton()
    {
        cameras[camIndex].enabled = false;
        camIndex--;
        if (camIndex < 0)
        {
            camIndex = cameras.Length - 1;
        }
        cameras[camIndex].enabled = true;
        ui.worldCamera = cameras[camIndex];
        text.text = string.Format("{0} {1}", "CAMERA", (camIndex + 1).ToString());
    }

    public void RightButton()
    {
        cameras[camIndex].enabled = false;
        camIndex++;
        if (camIndex >= cameras.Length)
        {
            camIndex = 0;
        }
        cameras[camIndex].enabled = true;
        ui.worldCamera = cameras[camIndex];
        text.text = string.Format("{0} {1}", "CAMERA", (camIndex + 1).ToString());
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
            ui.worldCamera = cameras[camIndex];
            text.text = string.Format("{0} {1}", "CAMERA", (camIndex + 1).ToString());
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
            ui.worldCamera = cameras[camIndex];
            text.text = string.Format("{0} {1}", "CAMERA", (camIndex + 1).ToString());
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (camIndex != 0)
            {
                cameras[camIndex].enabled = false;
                cameras[0].enabled = true;
                camIndex = 0;
                ui.worldCamera = cameras[camIndex];
                text.text = string.Format("{0} {1}", "CAMERA", (camIndex + 1).ToString());
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (camIndex != 1)
            {
                cameras[camIndex].enabled = false;
                cameras[1].enabled = true;
                camIndex = 1;
                ui.worldCamera = cameras[camIndex];
                text.text = string.Format("{0} {1}", "CAMERA", (camIndex + 1).ToString());
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (camIndex != 2)
            {
                cameras[camIndex].enabled = false;
                cameras[2].enabled = true;
                camIndex = 2;
                ui.worldCamera = cameras[camIndex];
                text.text = string.Format("{0} {1}", "CAMERA", (camIndex + 1).ToString());
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (camIndex != 3)
            {
                cameras[camIndex].enabled = false;
                cameras[3].enabled = true;
                camIndex = 3;
                ui.worldCamera = cameras[camIndex];
                text.text = string.Format("{0} {1}", "CAMERA", (camIndex + 1).ToString());
            }
        }


    }
}
