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

        if (play.isOn)
        {
            scrub.value += (Time.deltaTime * 0.1f);
        }

        else if (!play.isOn)
        {
            scrub.value = scrub.value;
        }



	}
}
