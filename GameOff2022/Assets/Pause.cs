using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject pausePanel, pauseButton;

    public bool isPaused;

    void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.P)) { PauseGame(); }
        }
        if (isPaused) 
        { 
            if (Input.GetKeyDown(KeyCode.P)) { ResumeGame(); } 
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        isPaused = true;
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        isPaused = false;
        pauseButton.SetActive(true);
    }
}
