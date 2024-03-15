using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreTracker : MonoBehaviour
{

    private const string prefKey = "high_score";

    private void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(prefKey, score);
    }

    private int GetHighScore()
    {
        if (PlayerPrefs.HasKey(prefKey))
            return PlayerPrefs.GetInt(prefKey);
        else
            return 0;
    }

    //returns new high score
    public int UpdateHighScore(int newScore)
    {
        int previousHighScore = this.GetHighScore();
        if (previousHighScore < newScore)
        {
            this.SetHighScore(newScore);
            PlayerPrefs.Save();
            return newScore;
        }
        else
            return previousHighScore;
    }
}
