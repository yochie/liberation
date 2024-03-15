using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject content;

    [SerializeField]
    private TextMeshProUGUI scoreLabel;
    
    [SerializeField]
    private TextMeshProUGUI highScoreLabel;

    public void Display(int score, int highScore, bool newHigh)
    {
        this.content.SetActive(true);
        this.scoreLabel.text = String.Format("Final score : {0}", score);
        this.highScoreLabel.text = newHigh ? String.Format("<color=green>High score : {0} (new)", highScore) : String.Format("High score : {0}", highScore);
    }
}
