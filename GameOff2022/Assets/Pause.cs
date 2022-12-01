using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject pausePanel;

    public bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { PauseGame(); }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        isPaused = true;
        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) { Resume(); }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        isPaused = false;
    }
}
