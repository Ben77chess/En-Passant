using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_Guess : MonoBehaviour
{

    public Canvas guess;
    public Canvas confirm;

    public Button[] listButton;
    public Image[] listImage;

    public Button[] guessButton;
    public Sprite[] guessSprite;

    private bool isGuessing;
    private int listIndex;


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

    public void ExitGuess()
    {

        isGuessing = false;

    }


    public void ClickGuess(int guessIndex)
    {

        if (listImage[listIndex].enabled == false)
        {
            isGuessing = false;
            listImage[listIndex].enabled = true;
            EventSystem.current.currentSelectedGameObject.SetActive(false);
            listImage[listIndex].sprite = guessSprite[guessIndex];
        }

    }


    public void ClickGuess()
    {
        confirm.enabled = true;
    }

    public void ClickYes()
    {
        SceneManager.LoadScene(sceneName: "Guess");
    }

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

        for (int i = 0; i < listImage.Length; i++)
        {
            listImage[i].enabled = false;
        }

        for (int i = 0; i < listButton.Length; i++)
        {
            int tempIndex = i;
            listButton[i].onClick.AddListener(() => this.ClickName(tempIndex));

        }

        for (int i = 0; i < guessButton.Length; i++)
        {
            int copyIndex = i;
            guessButton[i].onClick.AddListener(() => this.ClickGuess(copyIndex));

        }

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
