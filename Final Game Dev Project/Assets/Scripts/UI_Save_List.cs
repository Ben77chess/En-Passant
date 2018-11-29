using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Save_List : MonoBehaviour {

    // Static varibles to save status of list to pass to final scene
    static private List<bool> imageEnabled = new List<bool>();
    static private List<Sprite> sprites = new List<Sprite>();

    // Reference list to build list from
    public Button[] people;

    // private list to get list objects
    private Button[] list;
    // script to reference to build
    private UI_Guess guess;
    // Check if loading in final scene
    private bool loaded = false;

    // Use this for initialization
    void Start () {

        
        // Only run on the game scene to intialize variables
        if (SceneManager.GetActiveScene().name == "Whitebox")
        {
            setUp();
        }

	}
	
	// Update is called once per frame
	void Update () {

        // Saves list to build in final scene
        if (SceneManager.GetActiveScene().name == "Whitebox")
        {
            if(guess.confirm.enabled)
            {
                saveList();
            }
        }
        
        // Loads list in final scene
        if (SceneManager.GetActiveScene().name == "Guess")
        {
            
            if (!loaded)
            {
                loadList();
                loaded = !loaded;
            }
        }

	}


    private void saveList()
    {
        // loads script variables and save to static variables
        guess = GetComponent<UI_Guess>();
        list = guess.listButton;

        for (int i = 0; i < list.Length; i++)
        {
            imageEnabled[i] = (list[i].GetComponentInChildren<Image>().enabled);
            sprites[i] = (list[i].GetComponentInChildren<Image>().sprite);
        }

    }

    private void loadList()
    {
        // Creates list from static variables
        for (int i = 0; i < people.Length; i++)
        {
            people[i].gameObject.GetComponentInChildren<Image>().enabled = imageEnabled[i];
            people[i].gameObject.GetComponentInChildren<Image>().sprite = sprites[i];
        }

    }

    // Inital set-up for building list for final scene
    private void setUp()
    {
        guess = GetComponent<UI_Guess>();

        list = guess.listButton;

        for (int i = 0; i < list.Length; i++)
        {
            imageEnabled.Add(list[i].GetComponentInChildren<Image>().enabled);
            sprites.Add(list[i].GetComponentInChildren<Image>().sprite);
        }
    }
}
