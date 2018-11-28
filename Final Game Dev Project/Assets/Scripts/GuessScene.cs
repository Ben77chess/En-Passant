using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuessScene : MonoBehaviour {

    public Canvas guessRight;
    public Canvas guessWrong;

    public Material mouse;
    private Material startMaterial;

	// Use this for initialization
	void Start () {

        guessRight.enabled = false;
        guessWrong.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnMouseDown()
    {
        if(this.transform.name != "PawnDark")
        {
            guessWrong.enabled = true;
        }
        else
        {
            guessRight.enabled = true;
        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene(sceneName: "Start");
    }

    private void OnMouseEnter()
    {
        startMaterial = GetComponent<Renderer>().material;
        this.GetComponent<Renderer>().material = mouse;
    }

    private void OnMouseExit()
    {
        this.GetComponent<Renderer>().material = startMaterial;
    }

}
