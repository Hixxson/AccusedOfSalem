using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    public GameObject uiToActivate;
    public string[] defaultDialogueLines;
    public Sprite npcImage;

    private Dialogue dialogueScriptReference;
    private NpcController npcController;
    private bool hasInteracted;

    private void Start()
    {
        dialogueScriptReference = GetComponentInChildren<Dialogue>();
        npcController = GetComponent<NpcController>();
        hasInteracted = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
        {
            uiToActivate.SetActive(true);
            StartDialogue();
            hasInteracted = true;

           
            if (npcController != null)
            {
                npcController.StopMoving();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiToActivate.SetActive(false);
            hasInteracted = false;

      
            if (npcController != null)
            {
                npcController.ResumeMoving();
            }
        }
    }

    private void StartDialogue()
    {
        if (npcImage != null)
        {
            dialogueScriptReference.SetNPCImage(npcImage);
        }

        dialogueScriptReference.SetLines(defaultDialogueLines);

        DialogueManager.instance.StartDialogue(dialogueScriptReference);
    }
}






