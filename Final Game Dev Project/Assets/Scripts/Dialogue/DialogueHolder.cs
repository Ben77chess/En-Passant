

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {
    public DialogueTrigger[] dialogue;
    DialogueManager dialogueManager;

    // Use this for initialization
    void Start () {
        if (dialogueManager == null) {
            var go = GameObject.Find("DialogueManager");
            dialogueManager = go.GetComponent<DialogueManager>();
        }

        wait();
        playDialogue(0);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playDialogue(int index) {
        dialogue[index].SendMessage("TriggerDialogue");
    }

    public IEnumerator wait() {
        yield return new WaitForSeconds(5);
    }
}
