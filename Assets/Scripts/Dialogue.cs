using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Handles dialogue for an NPC
public class Dialogue : MonoBehaviour
{
    // References to UI elements
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI button1Text;
    public TextMeshProUGUI button2Text;
    public Image npcImage;

    // Dialogue lines and buttons' text
    public string[] lines;
    internal string button1ButtonText;
    internal string button2ButtonText;

    // Property to get access to the lines array
    public string[] Lines { get { return lines; } }

    // Speed at which text is displayed
    public float textSpeed;

    // Initialization
    private void Start()
    {
        textComponent.text = string.Empty;
        if (button1Text != null) button1Text.text = string.Empty;
        if (button2Text != null) button2Text.text = string.Empty;
        StartDialogue();
    }

    // Initiates the dialogue by calling the DialogueManager
    private void StartDialogue()
    {
        DialogueManager.instance.StartDialogue(this);
    }

    // Sets the dialogue lines
    public void SetLines(string[] newLines)
    {
        lines = newLines;
    }

    // Sets text for Button 1
    public void SetButton1Text(string buttonText)
    {
        button1ButtonText = buttonText;
        if (button1Text != null) button1Text.text = buttonText;
    }

    // Sets text for Button 2
    public void SetButton2Text(string buttonText)
    {
        button2ButtonText = buttonText;
        if (button2Text != null) button2Text.text = buttonText;
    }

    // Sets the NPC image
    public void SetNPCImage(Sprite newImage)
    {
        if (npcImage != null)
        {
            npcImage.sprite = newImage;
            npcImage.enabled = (newImage != null);
        }
    }
}

