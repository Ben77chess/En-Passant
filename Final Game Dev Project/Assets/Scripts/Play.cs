using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Play : MonoBehaviour {

    public Toggle play;
    public Toggle pause;
    public Slider scrub;


    // Use this for initialization
    void Start () {

        play.isOn = false;
        pause.isOn = false;
        scrub.value = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
        if (pause.isOn) {
            play.isOn = false;
        }

        else if (play.isOn)
        {
            pause.isOn = false;
            scrub.value = scrub.value * Time.deltaTime;
        }

        else
        {
            play.isOn = false;
            pause.isOn = false;
        }

	}
}
