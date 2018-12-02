

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
        for(int i = 0; i < dialogue.Length; i++) { //Checks to seee if we are in the time range for each dialogue and if it hasn't been played, plays it.
            if (WalkerController.walkerController.progress > dialogueTimes[i] && WalkerController.walkerController.progress < dialogueTimes[i]+.07 && !(bool)dialogueBools[i]) {
                dialogueBools[i] = true;
                playDialogue(i);
                StartCoroutine(waitToRetrigger(dialogueTimes[i], i));
            }
        }
    }

    public void playDialogue(int index) {
        dialogue[index].SendMessage("TriggerDialogue", dialogueTimes[index]);
    }

    public IEnumerator waitToRetrigger(float start, int dialogue) { //Ensures dialogues can only trigger once per time range.
        while (WalkerController.walkerController.progress >= start && WalkerController.walkerController.progress <= start + .07) {
            yield return null;
        }
        dialogueBools[dialogue] = false;
        yield break;
    }
}
