using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Guess : MonoBehaviour
{


    public Canvas guess;


    public Button[] listButton;
    public Image[] listImage;


    // button.GetComponent<Image>().sprite
    public Button[] guessButton;
    public Sprite[] guessSprite;



    private bool isGuessing;
    private int listIndex;
    private int guessIndex;


    public void ClickName()
    {
        
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

    public void ExitGuess()
    {

        isGuessing = false;

    }

    /////////////////////////////////////////////////////////

    public void ClickGuess()
    {
        if (listImage[listIndex].enabled == false)
        {
            isGuessing = false;
            listImage[listIndex].enabled = true;
            EventSystem.current.currentSelectedGameObject.SetActive(false);
            listImage[listIndex].sprite = guessSprite[guessIndex];
        }

    }


    // Use this for initialization
    void Start()
    {

        listIndex = 0;
        guessIndex = 0;

        isGuessing = false;
        guess.enabled = false;

        for (int i = 0; i < listImage.Length; i++)
        {
            listImage[i].enabled = false;
        }

        for (int i = 0; i < listButton.Length; i++)
        {
            listButton[i].onClick.AddListener(() => this.onListClick(i));
        }

        for (int i = 0; i < guessButton.Length; i++)
        {
            guessButton[i].onClick.AddListener(() => this.onGuessClick(i));
        }

    }


    public void onListClick(int i)
    {
        listIndex = i-1;

    }


    public void onGuessClick(int i)
    {
        guessIndex = i-1;
    }



    // Update is called once per frame
    void Update()
    {

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
