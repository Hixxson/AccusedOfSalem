using System.Collections;
using TMPro;
using UnityEngine;



public class NPCDialogueTrigger : MonoBehaviour
{
    public GameObject uiToActivate;
    public string[] defaultDialogueLines; 

    private Dialogue dialogueScriptReference;

    private void Start()
    {
        
        dialogueScriptReference = GetComponentInChildren<Dialogue>();

       
        SetDialogueLines(defaultDialogueLines);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiToActivate.SetActive(true);
            StartDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiToActivate.SetActive(false);
        }
    }

    private void StartDialogue()
    {
     
        DialogueManager.instance.StartDialogue(dialogueScriptReference.textComponent, dialogueScriptReference.lines, dialogueScriptReference.textSpeed);
    }

    public void SetDialogueLines(string[] newLines)
    {
      
        dialogueScriptReference.SetLines(newLines);
    }
}



