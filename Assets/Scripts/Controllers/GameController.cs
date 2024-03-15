using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Singleton { get; private set; }

    [SerializeField]
    private UIController ui;

    [SerializeField]
    private Scorer scorer;

    [SerializeField]
    private PlayerController playerController;

    private void Awake()
    {
        GameController.Singleton = this;
    }

    public void EndGame()
    {
        PauseController.PauseGame(true);
        this.ui.DisplayEndScreen(this.scorer.GetScore());
    }

    //Called by button
    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    internal void AddToScore(int toAdd)
    {
        this.scorer.AddToScore(toAdd);

    }
}