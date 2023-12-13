using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    // Define a structure for a quest
    [System.Serializable]
    public class Quest
    {
        public string questName;
        public bool isCompleted;
    }

    // List of available quests
    public List<Quest> quests;

    private int completedQuestCount = 0;

    private void Start()
    {
        // Initialize quests as incomplete at the start
        InitializeQuests();
    }

    // Initialize quests as incomplete
    private void InitializeQuests()
    {
        foreach (Quest quest in quests)
        {
            quest.isCompleted = false;
        }
    }

    // Mark a specific quest as completed
    public void CompleteQuest(string questName)
    {
        Quest quest = quests.Find(q => q.questName == questName);
        if (quest != null && !quest.isCompleted)
        {
            quest.isCompleted = true;
            completedQuestCount++;
            Debug.Log("Quest '" + questName + "' completed!");

            // Check if the number of completed quests equals 3
            if (completedQuestCount == 4)
            {
                LoadNextScene();
            }
        }
        else
        {
            Debug.LogWarning("Quest '" + questName + "' not found or already completed!");
        }
    }

    // Check if a specific quest is completed
    public bool IsQuestCompleted(string questName)
    {
        Quest quest = quests.Find(q => q.questName == questName);
        return quest != null && quest.isCompleted;
    }

    // Load the next scene
    private void LoadNextScene()
    {
        // You can replace "YourNextSceneName" with the actual name of your next scene
        SceneManager.LoadScene("WinScene");
    }
}
