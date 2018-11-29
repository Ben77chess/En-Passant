using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour {

    // List of cameras to switch between
    public Camera[] cameras;
    // Canvas that holds the camera switching UI
    public Canvas ui;
    // Camera indicator
    public Text text;

    // Index of camera
    private int camIndex;

	// Use this for initialization
	void Start () {

        // Start at the first camera
        ui.worldCamera = cameras[0];
        
        // Disables other cameras for optimum performance
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
        // Sets camera indicator text
        camIndex = 0;
        text.text = string.Format("{0} {1}", "CAMERA", (camIndex + 1).ToString());
        text.fontStyle = FontStyle.Bold;
        text.fontSize = 18;
    }

    // Moves to previous camera in list if left UI button clicked
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

    // Moves to next camera in list if right UI button clicked
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
		
        // Changes camera based on arrow/top-row-number key presses
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
