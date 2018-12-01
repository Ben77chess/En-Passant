using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuessScene : MonoBehaviour {

    // Render Final Canvas based on guess is correct or not
    public Canvas guessRight;
    public Canvas guessWrong;

    public Canvas choosing;

    // Materials to change on mouseover, and save original material when not mouseover
    public Material mouse;
    private Material startMaterial;

	// Use this for initialization
	void Start () {

        choosing.enabled = true;
        // Hides end game content until choice is made
        guessRight.enabled = false;
        guessWrong.enabled = false;

	}

    // On mouse click, check if clicked object was the murderer or not
    // Loads overlay for guess choice and disables choosing canvas
    private void OnMouseDown()
    {
        if(this.transform.name != "PawnDark")
        {
            guessWrong.enabled = true;
            choosing.enabled = false;
        }
        else
        {
            guessRight.enabled = true;
            choosing.enabled = false;
        }
    }

    // Restarts game regardless of choice outcome
    public void OnClick()
    {
        choosing.enabled = false;
        guessRight.enabled = false;
        guessWrong.enabled = false;
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
