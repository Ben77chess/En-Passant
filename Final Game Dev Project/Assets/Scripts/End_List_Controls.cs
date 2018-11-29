using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_List_Controls : MonoBehaviour {

    // Shows/Hides final static list to player before choosing murderer
    public Canvas list;

	// Use this for initialization
	void Start () {
        list.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void openList()
    {
        list.enabled = true;
    }

    public void closeList()
    {
        list.enabled = false;
    }

}
