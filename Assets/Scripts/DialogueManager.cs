using System.Collections;
using UnityEngine;
using TMPro;

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

  
    public void StartDialogue(TextMeshProUGUI textComponent, string[] lines, float textSpeed)
    {
        StartCoroutine(TypeLines(textComponent, lines, textSpeed));
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

