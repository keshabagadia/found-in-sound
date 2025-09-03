using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RemainingTime : MonoBehaviour
{
    
    public int startTimeInSeconds = 60;
    public TMP_Text timerText;
    private float remainingTime;
    public AudioSource timerOverSFX;
    void Start()
    {
        remainingTime = startTimeInSeconds;
        timerText.text = "Remaining time: "+remainingTime.ToString("F0");
        timerOverSFX = GetComponent<AudioSource>();
        // timerOverSFX.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            timerText.text = "Remaining time: " + remainingTime.ToString("F0");
            if (remainingTime <= 1 && timerOverSFX != null)
            {
                timerOverSFX.Play();
                timerOverSFX = null;
            }
        }
        else
        {
            remainingTime = 0;
            GameOver();
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetGame();
            }
        }
    }

    public void GameOver()
    {
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
        GameManager.Instance.SaveHighScore();
    }

    // Method to get the remaining time
    public float GetRemainingTime()
    {
        return remainingTime;
    }
    void PauseGame()
    {
        Time.timeScale = 0; // Pause the game
        Debug.Log("Game Paused! Timer is over.");
    }

    public void ResetGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Game Reset!");
    }
}
