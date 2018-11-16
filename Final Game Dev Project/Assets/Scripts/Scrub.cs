using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Scrub : MonoBehaviour {


    public static Slider bar;

    // Use this for initialization
    private void Awake() {
        bar = this.GetComponentInParent<Slider>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        WalkerController.walkerController.progress = bar.normalizedValue;
	}

    
}
