using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_List : MonoBehaviour {

    public static bool paused;
    public Canvas list;
    public Text listText;
    public Toggle toggle;

    private List<string> names;

    private bool wasPlaying;
	// Use this for initialization
	void Start () {

        wasPlaying = false;
        list.enabled = false;
        paused = false;
        names = new List<string>
        {
            "ONE",
            "TWO",
            "THREE"
        };

        for (int i = 0; i < names.Count; i++)
        {
            Debug.Log(names[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (paused)
        {
            list.enabled = true;
            listText.enabled = true;
        }
        else
        {
            list.enabled = false;
            listText.enabled = false;
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
