

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {
    public DialogueTrigger[] dialogue;
    DialogueManager dialogueManager;
    private bool[] dialogueBools = {false, false };
    // Use this for initialization
    void Start () {
        if (dialogueManager == null) {
            var go = GameObject.Find("DialogueManager");
            dialogueManager = go.GetComponent<DialogueManager>();
        }

        dialogueBools[0] = false;

     

    }
	
	// Update is called once per frame
	void Update () {
		if(WalkerController.walkerController.progress > .1 && WalkerController.walkerController.progress < .17 && !dialogueBools[0]) {
            dialogueBools[0] = true;
            dialogue[0].TriggerDialogue();
            Debug.Log("Here!");
            StartCoroutine(waitToRetrigger(.1f, 0));
        } else if (WalkerController.walkerController.progress > .22 && WalkerController.walkerController.progress < .29 && !dialogueBools[1]) {
            dialogueBools[1] = true;
            dialogue[1].TriggerDialogue();
            Debug.Log("Here!");
            StartCoroutine(waitToRetrigger(.22f, 1));
        }
    }

    public void playDialogue(int index) {
        dialogue[index].SendMessage("TriggerDialogue");
    }

    public IEnumerator waitToRetrigger(float start, int dialogue) {
        Debug.Log("Before while.");
        while (WalkerController.walkerController.progress >= start && WalkerController.walkerController.progress <= start + .07) {
            //Debug.Log(WalkerController.walkerController.progress);
            yield return null;
        }
        dialogueBools[dialogue] = false;
        Debug.Log("After while.");
        yield break;
    }
}
