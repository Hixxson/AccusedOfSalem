using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public int totalDays = 10;
    public float secondsPerDay = 30f;

    private int currentDay;
    private float timer;

    void Start()
    {
        currentDay = totalDays;
        UpdateUI();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= secondsPerDay)
        {
            timer -= secondsPerDay;

            if (currentDay > 0)
            {
                currentDay--;

                if (currentDay <= 0)
                {
                    currentDay = 0;
                    LoadNextScene();
                }

                UpdateUI();
            }
        }
    }

    void UpdateUI()
    {
        countdownText.text = "Days left: " + currentDay.ToString();
    }

    void LoadNextScene()
    {   
        SceneManager.LoadScene("FailScreen");
    }
}
