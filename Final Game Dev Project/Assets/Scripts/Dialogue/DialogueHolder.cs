

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {
    public DialogueTrigger[] dialogue;
    private ArrayList dialogueBools = new ArrayList();
    public float[] dialogueTimes;
    // Use this for initialization
    void Start () {

        for (int i = 0; i < dialogue.Length; i++) {
            dialogueBools.Add(false);
        }
     

    }
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i < dialogue.Length; i++) {
            if (WalkerController.walkerController.progress > dialogueTimes[i] && WalkerController.walkerController.progress < dialogueTimes[i]+.07 && !(bool)dialogueBools[i]) {
                dialogueBools[i] = true;
                playDialogue(i);
                StartCoroutine(waitToRetrigger(dialogueTimes[i], i));
            }
        }
		/*if(WalkerController.walkerController.progress > .1 && WalkerController.walkerController.progress < .17 && !dialogueBools[0]) {
            dialogueBools[0] = true;
            playDialogue(0, dialogueManagers[0]);
            StartCoroutine(waitToRetrigger(.1f, 0));
        } else if (WalkerController.walkerController.progress > .22 && WalkerController.walkerController.progress < .29 && !dialogueBools[1]) {
            dialogueBools[1] = true;
            playDialogue(1, dialogueManagers[0]);
            Debug.Log("Here!");
            StartCoroutine(waitToRetrigger(.22f, 1));
        }*/
    }

    public void playDialogue(int index) {
        dialogue[index].SendMessage("TriggerDialogue", dialogueTimes[index]);
    }

    public IEnumerator waitToRetrigger(float start, int dialogue) {
        while (WalkerController.walkerController.progress >= start && WalkerController.walkerController.progress <= start + .07) {
            yield return null;
        }
        dialogueBools[dialogue] = false;
        yield break;
    }
}
