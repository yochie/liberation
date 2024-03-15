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

    [SerializeField]
    private HighScoreTracker highScoreTracker;

    private void Awake()
    {
        GameController.Singleton = this;
    }

    public void EndGame()
    {
        PauseController.PauseGame(true);
        int score = this.scorer.GetScore();
        int highScore = this.highScoreTracker.UpdateHighScore(score);
        bool newHeigh = highScore == score;

        this.ui.DisplayEndScreen(score, highScore, newHeigh);
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

    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    internal void AddToScore(int toAdd)
    {
        this.scorer.AddToScore(toAdd);

    }
}