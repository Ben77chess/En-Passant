using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public DialogueManager dm;

    public void TriggerDialogue (float time) //Important to send the start time so the dm knows the range of when the dialogue should be active, regardless of when it was triggered.
    {
        dm.QueueDialogue(dialogue, time);
    }
}
