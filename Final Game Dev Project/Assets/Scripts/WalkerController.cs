
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerController : MonoBehaviour {

    

    public static WalkerController walkerController;

    public bool paused = true;
    public float progress = 0;

    private void Awake() {
        walkerController = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Scrub.bar.value = progress;
	}

    
}
