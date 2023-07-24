using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArcadeMode : MonoBehaviour
{
    private GameManager gameManager;
    public Text gameOverText;

    public Text timeText;
    private float timeRemaining = 60f;
    private bool timerIsRunning = false;
    
    private void Start()
    {
        gameManager = GameManager._instance;
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Time.timeScale = 0f;
                gameOverText.enabled = true;
                gameOverText.text = $"Game Over\nYour score is {gameManager.score}";
                timeRemaining = 0;
                timerIsRunning = false;
                gameManager.blade.enabled = false;
                gameManager.spawner.enabled = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("ModeSelection");
    }
}
