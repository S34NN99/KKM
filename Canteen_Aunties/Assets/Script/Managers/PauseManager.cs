using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;

    public bool IsPaused => isPaused;

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
