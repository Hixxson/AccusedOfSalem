using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image npcImage;
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
     
        DialogueManager.instance.StartDialogue(this);
    }

    public void SetLines(string[] newLines)
    {
        lines = newLines;
    }

    public void SetNPCImage(Sprite newImage)
    {
        if (npcImage != null)
        {
            npcImage.sprite = newImage;

            npcImage.enabled = (newImage != null);
        }
    }
}




