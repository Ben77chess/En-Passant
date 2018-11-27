using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

    public Canvas start;
    public Canvas control;
    public Canvas credit;
    public Canvas message;

    public void ClickMessage()
    {
        SceneManager.LoadScene(sceneName: "UI");
    }

    public void ClickStart()
    {
        start.enabled = false;
        message.enabled = true;
    }

    public void ClickControls()
    {
        start.enabled = false;
        control.enabled = true;
    }

    public void ClickCredits()
    {
        start.enabled = false;
        credit.enabled = true;
    }

    public void ExitControls()
    {
        start.enabled = true;
        control.enabled = false;

    }

    public void ExitCredits()
    {
        start.enabled = true;
        credit.enabled = false;

    }

	// Use this for initialization
	void Start () {

        control.enabled = false;
        credit.enabled = false;
        message.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
