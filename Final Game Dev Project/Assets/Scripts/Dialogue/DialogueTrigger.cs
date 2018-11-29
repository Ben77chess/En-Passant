using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public DialogueManager dm;

    public void TriggerDialogue (float time)
    {
        dm.QueueDialogue(dialogue, time);
    }
}
