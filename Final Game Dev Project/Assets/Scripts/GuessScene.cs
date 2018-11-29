using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuessScene : MonoBehaviour {

    // Render Final Canvas based on guess is correct or not
    public Canvas guessRight;
    public Canvas guessWrong;

    // Materials to change on mouseover, and save original material when not mouseover
    public Material mouse;
    private Material startMaterial;

	// Use this for initialization
	void Start () {

        // Hides end game content until choice is made
        guessRight.enabled = false;
        guessWrong.enabled = false;

	}

    // On mouse click, check if clicked object was the murderer or not
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

    // Restarts game regardless of choice outcome
    public void OnClick()
    {
        SceneManager.LoadScene(sceneName: "Start");
    }

    // On mouseover, changes to mouseover material
    private void OnMouseEnter()
    {
        startMaterial = GetComponent<Renderer>().material;
        this.GetComponent<Renderer>().material = mouse;
    }
    
    // On leaving mouseover, returns to original material
    private void OnMouseExit()
    {
        this.GetComponent<Renderer>().material = startMaterial;
    }

}
