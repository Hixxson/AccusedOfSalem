using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Manages the dialogue system
public class DialogueManager : MonoBehaviour
{
    // Singleton instance of the DialogueManager
    public static DialogueManager instance;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Ensure there is only one instance of DialogueManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // Destroy the duplicate instance to maintain singleton pattern
            Destroy(gameObject);
        }
    }

   
    // Initiates the dialogue for a given Dialogue script
    public void StartDialogue(Dialogue dialogue)
    {
        StartCoroutine(TypeLines(dialogue.textComponent, dialogue.lines, dialogue.textSpeed));
      
    }

    // Coroutine to gradually type out each line of dialogue
    private IEnumerator TypeLines(TextMeshProUGUI textComponent, string[] lines, float textSpeed)
    {
        foreach (string line in lines)
        {
            textComponent.text = string.Empty;
            foreach (char c in line.ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
