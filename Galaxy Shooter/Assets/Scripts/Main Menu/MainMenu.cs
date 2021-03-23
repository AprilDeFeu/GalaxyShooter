using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool _exitBool;
  
    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Update()
    {
        if (_exitBool) if (Input.GetKeyDown(KeyCode.Escape))
        {
                Debug.Log("Escape pressed.");
                Application.Quit();
        }
    }

    public void exitGame()
    {
        this.gameObject.GetComponentInChildren<Animations>().exitGame();
        Debug.Log("Passed animation");
        _exitBool = true;
    }

}
