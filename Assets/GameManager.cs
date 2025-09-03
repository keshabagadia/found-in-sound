using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    public int currentScore=0;
    public TMP_Text scoreText;
    public TMP_Text leastTimeTakenText;
    private float leastTimeTaken = 0;   
    public TMP_Text timerText; 
    private float currentTimer=0;
    public AudioSource winSFX;
    
    void Start()
    {
        scoreText.text = "Found phonemes: " + currentScore+"/39";
        leastTimeTaken = GetLeastTime();
        leastTimeTakenText.text = "Least time taken: " + leastTimeTaken;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Found phonemes: " + currentScore +"/39";
        if (currentScore >= 39)
        {
            GameOver();
        }
        else
        {
            currentTimer += Time.deltaTime;
            Debug.Log("kya chal raha hai" + currentTimer);
            timerText.text = "Time taken: " + currentTimer.ToString("F0") + "s";
        }
    }

    
    public void SaveHighScore()
    {
        if (leastTimeTaken > currentTimer)
        {
            leastTimeTaken = currentTimer;
            leastTimeTakenText.text = "Least time taken: " + leastTimeTaken;
            PlayerPrefs.SetFloat("LeastTimeTaken", leastTimeTaken);
            PlayerPrefs.Save();
        }
    }
    public int GetLeastTime()
    {
        return PlayerPrefs.GetInt("LeastTimeTaken", 0);
    }

    public void GameOver()
    {
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
        SaveHighScore();
        if(winSFX!=null) winSFX.Play();
    }
}
