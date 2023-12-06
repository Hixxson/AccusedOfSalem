using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    internal string[] lines; 

    
    public string[] Lines
    {
        get { return lines; }
    }

    public float textSpeed;

    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void StartDialogue()
    {
        DialogueManager.instance.StartDialogue(textComponent, lines, textSpeed);
    }

   
    public void SetLines(string[] newLines)
    {
        lines = newLines;
    }
}


