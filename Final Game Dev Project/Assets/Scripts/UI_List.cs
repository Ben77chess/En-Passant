using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UI_List : MonoBehaviour {

    public static bool paused;
    public Canvas list;
    public Text listText;
    public Toggle toggle;

    private List<string> names;
    private bool wasPlaying;


	// Use this for initialization
	void Start () {

        listText.text = "";
        wasPlaying = false;
        list.enabled = false;
        paused = false;
        names = new List<string>
        {
            "George Milton",
            "Shelly Milton",
            "Julien Nizan",
            "Bob Porter",
            "Shelly Porter",
            "Prosper Quincy",
            "Robert Quincy",
            "Sophie Warwick",
            "Photographer ",
            "Security ",
            "Waiter "
        };

        for (int i = 0; i < names.Count; i++)
        {
            listText.text += names[i] + "\n";
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (paused)
        {
            list.enabled = true;
        }
        else
        {
            list.enabled = false;
        }

	}

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

    public void exitListButton()
    {
        paused = false;
        
        if (wasPlaying)
        {
            toggle.isOn = true;
        }
        
    }
}
