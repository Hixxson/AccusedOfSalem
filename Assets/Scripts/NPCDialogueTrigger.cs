using UnityEngine;
using UnityEngine.UI;

// Triggers NPC dialogue and manages quest-related interactions
public class NPCDialogueTrigger : MonoBehaviour
{
    // UI elements and dialogue lines
    public GameObject uiToActivate;
    public string[] currentDialogueText;
    public string[] introText;
    public string[] response1Line;
    public string[] response2Line;
    public string[] questCompletedLines;
    public string questName;
    public bool isQuestCompletionTrigger = false;
    public Sprite npcImage;

    // Dialogue script reference and other components
    [SerializeField] private Dialogue dialogueScriptReference;
    private NpcController npcController;
    private QuestManager questManager;
    private TopDownMovement Topdownmovement;
    private bool hasInteracted;

    // Button text strings
    public string button1Text = "Button 1";
    public string button2Text = "Button 2";

    // References to Button components
    private Button button1;
    private Button button2;

    // Initialization
    private void Start()
    {
        //dialogueScriptReference = GetComponentInChildren<Dialogue>();
        npcController = GetComponent<NpcController>();
        questManager = FindObjectOfType<QuestManager>();
        hasInteracted = false;

        button1 = uiToActivate.transform.Find("Button1").GetComponent<Button>();
        button2 = uiToActivate.transform.Find("Button2").GetComponent<Button>();

    }

    // Method called when Button 1 is clicked
    private void Button1Clicked()
    {
        Debug.Log("Button 1 clicked!");
        // Additional logic on Button 1 click
      
        dialogueScriptReference.SetLines(response1Line);
        currentDialogueText = response1Line;
        StartDialogue();
        uiToActivate.transform.Find("Button1").gameObject.SetActive(false);
        uiToActivate.transform.Find("Button2").gameObject.SetActive(false);
    }

    // Method called when Button 2 is clicked
    private void Button2Clicked()
    {
        Debug.Log("Button 2 clicked!");
        // Additional logic on Button 2 click
       
        dialogueScriptReference.SetLines(response2Line);
        currentDialogueText = response2Line;
        StartDialogue();
        uiToActivate.transform.Find("Button1").gameObject.SetActive(false);
        uiToActivate.transform.Find("Button2").gameObject.SetActive(false);
    }

    // Triggered when the player enters the NPC's collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
        {
            
            uiToActivate.transform.Find("Button1").gameObject.SetActive(true);
            uiToActivate.transform.Find("Button2").gameObject.SetActive(true);
            if (button1 != null)
            {
                button1.onClick.RemoveAllListeners();
                button1.onClick.AddListener(Button1Clicked);
            }

            if (button2 != null)
            {
                button2.onClick.RemoveAllListeners();
                button2.onClick.AddListener(Button2Clicked);
            }

            currentDialogueText = introText;

            // Activate UI, stop NPC movement, and handle quest-related logic
            uiToActivate.SetActive(true);
            hasInteracted = true;

            if (npcController != null)
            {
                npcController.StopMoving();
            }

            if (questManager != null && !string.IsNullOrEmpty(questName))
            {
                // Handle quest completion or continuation
                if (isQuestCompletionTrigger)
                {
                    questManager.CompleteQuest(questName);

                    // Debugging information
                    Debug.Log("Quest '" + questName + "' marked as completed.");

                    if (questCompletedLines == null || questCompletedLines.Length == 0)
                    {
                        Debug.LogWarning("questCompletedLines is empty for NPC: " + gameObject.name);
                    }
                    else
                    {
                        Debug.Log("questCompletedLines: " + string.Join(", ", questCompletedLines));
                    }
                }
                else
                {
                    if (questManager.IsQuestCompleted(questName))
                    {
                        Debug.Log("Quest '" + questName + "' is completed.");

                        dialogueScriptReference.SetLines(questCompletedLines);
                        currentDialogueText = questCompletedLines;
                        uiToActivate.transform.Find("Button1").gameObject.SetActive(false);
                        uiToActivate.transform.Find("Button2").gameObject.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("Quest '" + questName + "' is not completed.");

                        dialogueScriptReference.SetLines(currentDialogueText);
                    }
                }
            }
            else
            {
                Debug.LogWarning("QuestManager or questName not set for NPC: " + gameObject.name);
            }

            // Set Button 1 and Button 2 text
            SetButton1Text(button1Text);
            SetButton2Text(button2Text);

            // Set NPC dialogue lines and image
            SetDialogueAttributes();

            // Start dialogue
            StartDialogue();
        }
    }

    // Triggered when the player exits the NPC's collider
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueScriptReference.SetLines(currentDialogueText);
            // Deactivate UI and resume NPC movement
            uiToActivate.SetActive(false);
            hasInteracted = false;

            if (npcController != null)
            {
                npcController.ResumeMoving();
            }
        }
    }

    // Set Button 1 text using the Dialogue script
    private void SetButton1Text(string buttonText)
    {
        if (dialogueScriptReference != null)
        {
            dialogueScriptReference.SetButton1Text(buttonText);
        }
    }

    // Set Button 2 text using the Dialogue script
    private void SetButton2Text(string buttonText)
    {
        if (dialogueScriptReference != null)
        {
            dialogueScriptReference.SetButton2Text(buttonText);
        }
    }

    // Set NPC image and dialogue lines using the Dialogue script
    private void SetDialogueAttributes()
    {
        if (npcImage != null)
        {
            dialogueScriptReference.SetNPCImage(npcImage);
        }

        if (currentDialogueText == null || currentDialogueText.Length == 0)
        {
            Debug.LogWarning("npcDialogueLines is empty for NPC: " + gameObject.name);
        }

        dialogueScriptReference.SetLines(currentDialogueText);
    }

    // Start the dialogue using the DialogueManager instance
    private void StartDialogue()
    {

        if (dialogueScriptReference != null)
        {
            DialogueManager.instance.StartDialogue(dialogueScriptReference);
        }
    }
}

