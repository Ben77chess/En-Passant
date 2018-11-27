using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GuessList : MonoBehaviour {


    public Canvas guess;

    private bool isGuessing;

    public void ClickName()
    {

        isGuessing = true;

    }

    public void ExitGuess()
    {

        isGuessing = false;

    }

    public void ClickImage()
    {

        isGuessing = false;
        GameObject.FindObjectOfType<Button>().image.enabled = false;

    }


	// Use this for initialization
	void Start () {

        isGuessing = false;
        guess.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (isGuessing)
        {
            guess.enabled = true;
        }
        else
        {
            guess.enabled = false;
        }

    }
}
