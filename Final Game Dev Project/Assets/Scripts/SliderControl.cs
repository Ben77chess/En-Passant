using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour {

    public Slider scrub;
    public GameObject on, off;

    public void OnChangeValue()
    {
        bool toggled = gameObject.GetComponent<Toggle>().isOn;

        if (toggled)
        {
            on.SetActive(true);
            off.SetActive(false);
        }

        if (!toggled)
        {
            on.SetActive(false);
            off.SetActive(true);
        }

    }





	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Toggle>().isOn = false;
        on.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        bool toggled = gameObject.GetComponent<Toggle>().isOn;
        WalkerController.walkerController.paused = !toggled;

        if (toggled)
        {
            //scrub.value += (Time.deltaTime * 0.1f);
        }

        else
        {
            scrub.value = scrub.value;
        }

        WalkerController.walkerController.progress = scrub.normalizedValue;

    }
}
