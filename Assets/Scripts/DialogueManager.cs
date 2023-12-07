using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        StartCoroutine(TypeLines(dialogue.textComponent, dialogue.lines, dialogue.textSpeed));
    }

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


