using System;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private bool dialogueIsOpen;
    public bool dialogueActive;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public float startProgress = 1;

    public Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();
    public void Start() {
        dialogueActive = false;
    }
    public void QueueDialogue(Dialogue dialogue)
    {
        // Say that we are showing more dialogues, and show them.
        dialogueActive = true;
        dialogueQueue.Enqueue(dialogue);
    }

    void Update()
    {
        //if (animator == null) {
        //    var go = GameObject.Find("DialogueBox");
        //    animator = go.GetComponent<Animator>();
        //}
        // If there's no dialogue open
        if (!dialogueIsOpen)
        {
            // If we have more dialogues to show
            if(dialogueQueue.Count != 0)
            {
                // Say that we are showing more dialogues, and show them.
                StartDialogue(dialogueQueue.Dequeue());
            }
            else {
                // If we are not showing a dialogue and have no dialogues to show.
                dialogueActive = false;

            }
        }
        // If there is a dialogue open
        else {
            dialogueActive = true;
        }

        if(WalkerController.walkerController.progress > startProgress + .07 || WalkerController.walkerController.progress < startProgress) {
            EndDialogue();
            startProgress = 1;
        }
    }

    private Queue<string> sentences = new Queue<string>();

    public void StartDialogue(Dialogue dialogue)
    {
        
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        dialogueIsOpen = true;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        startProgress = WalkerController.walkerController.progress;
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }

    }

    void EndDialogue()
    {
        if (animator == null) { //This really shouldn't be necessary but for some reason it is? Why?
            var go = GameObject.Find("DialogueBox");
            animator = go.GetComponent<Animator>();
        }
            animator.SetBool("IsOpen", false);
            dialogueIsOpen = false;
            
    }

}
