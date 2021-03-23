using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    bool isPaused;
    public AudioMixer mix;
    public Slider slide;

    public GameObject pauseMenuUI; 

    void Start() 
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            mix.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));
            slide.value = PlayerPrefs.GetFloat("Volume");
        }
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }

        mix.SetFloat("Volume", slide.value);
        PlayerPrefs.SetFloat("Volume", slide.value);
        PlayerPrefs.Save();
    }

    public void Resume ()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause ()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    } 

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
