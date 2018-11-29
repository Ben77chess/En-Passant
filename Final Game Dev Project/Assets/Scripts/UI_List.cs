using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_List : MonoBehaviour {

    // Check if paused
    public static bool paused;
    // Canvas for list overlay
    public Canvas list;
    // Gets status of play/pause before opening list overlay
    public Toggle toggle;
    
    // Gets whether player had slider moving
    private bool wasPlaying;


	// Use this for initialization
	void Start () {

        wasPlaying = false;
        list.enabled = false;
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {

        // Pauses game on list overlay
        if (paused)
        {
            list.enabled = true;
        }
        else
        {
            list.enabled = false;
        }

	}

    // Opens list overlay, checks for playing status
    public void listButton()
    {
        paused = true;
        
        bool toggled = toggle.GetComponent<Toggle>().isOn;

        if (toggled)
        {
            wasPlaying = true;
        }
        else
        {
            wasPlaying = false;
        }
        toggle.isOn = false;

    }

    // Exits list overlay, resumes play if playing before opening list overlay
    public void exitListButton()
    {
        paused = false;
        
        if (wasPlaying)
        {
            toggle.isOn = true;
        }
        
    }
}
