using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {
    
    //Canvases for different buttons and start screen
    public Canvas start;
    public Canvas control;
    public Canvas credit;
    public Canvas message;
    // Audio source for smoother scene switching with music change
    AudioSource audio;

    // Starts the game
    public void ClickMessage()
    {
        audio.mute = true;
        StartCoroutine("Wait");
    }

    // Loads pre-game message to explain the situation to the player
    public void ClickStart()
    {
        start.enabled = false;
        message.enabled = true;
    }

    // Text of controls of the game
    public void ClickControls()
    {
        start.enabled = false;
        control.enabled = true;
    }

    // Credits
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
        audio = Camera.main.transform.GetComponent<AudioSource>();

    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene(sceneName: "Whitebox");
    }
	
}
