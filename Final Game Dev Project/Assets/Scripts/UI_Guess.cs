using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_Guess : MonoBehaviour
{
    // Canvases for guessing charater model/person and to confirm final guess
    public Canvas guess;
    public Canvas confirm;

    // List of name buttons and corresponding image
    public Button[] listButton;
    public Image[] listImage;
    
    // List of character buttons and corresponding sprite
    public Button[] guessButton;
    public Sprite[] guessSprite;

    // Boolean for checking if player is choosing a character to guess
    private bool isGuessing;
    // Index of selected list name button
    private int listIndex;


    // Handles choice change on character association with name
    public void ClickName(int tmpIndex)
    {
        listIndex = tmpIndex;

        if (listImage[listIndex].enabled == true)
        {
            for (int i = 0; i < guessSprite.Length; i++)
            {
                if (listImage[listIndex].sprite.name == guessSprite[i].name)
                {
                    guessButton[i].gameObject.SetActive(true);
                    listImage[listIndex].enabled = false;
                }
            }
        }

        isGuessing = true;

    }

    // Exits character model guessing
    public void ExitGuess()
    {

        isGuessing = false;

    }

    // Handles if first time guessing character model for name
    public void ClickGuess(int guessIndex)
    {

        if (listImage[listIndex].enabled == false)
        {
            isGuessing = false;
            listImage[listIndex].enabled = true;
            //This line hides the selected character
            EventSystem.current.currentSelectedGameObject.SetActive(false);
            listImage[listIndex].sprite = guessSprite[guessIndex];
        }

    }

    // Confirmation for moving to final guess
    public void ClickGuess()
    {
        confirm.enabled = true;
    }

    // Loads final guess scene
    public void ClickYes()
    {
        SceneManager.LoadScene(sceneName: "Guess");
    }

    // Exits confirmation, back to game
    public void ClickNo()
    {
        confirm.enabled = false;
    }

    // Use this for initialization
    void Start()
    {
        confirm.enabled = false;
        isGuessing = false;
        guess.enabled = false;

        // Hides character image next to name as intially player has no clue who's who
        for (int i = 0; i < listImage.Length; i++)
        {
            listImage[i].enabled = false;
        }

        // Adds listeners for name clicked
        for (int i = 0; i < listButton.Length; i++)
        {
            int tempIndex = i;
            listButton[i].onClick.AddListener(() => this.ClickName(tempIndex));

        }

        // Adds listeners for character model clicked
        for (int i = 0; i < guessButton.Length; i++)
        {
            int copyIndex = i;
            guessButton[i].onClick.AddListener(() => this.ClickGuess(copyIndex));

        }

    }


    // Update is called once per frame
    void Update()
    {
        // Check if player is guessing character model to match with name
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
