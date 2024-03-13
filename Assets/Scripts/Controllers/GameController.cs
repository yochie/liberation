using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Singleton { get; private set; }

    [SerializeField]
    private UIController ui;

    private void Awake()
    {
        GameController.Singleton = this;
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        this.ui.DisplayEndScreen();
    }

    //Called by button
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
