using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public TMP_Text textTimer;
    public string loseScene = "LoseScene";

    private float totalTime = 60f;
    private float timeRemaining;
    private bool timerEnds = false;

    void Start()
    {
        timeRemaining = totalTime;
    }
    void Update()
    {
        if (timerEnds) 
        {
            return;
        }

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            timerEnds = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene(loseScene);
        }

        UpdateTime();

    }

    void UpdateTime() 
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timeRemaining <= 30f)
        {
            textTimer.color = Color.red;
        }

    }
}
