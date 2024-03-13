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

    public void Display(int score)
    {
        this.content.SetActive(true);
        this.scoreLabel.text = String.Format("Final score : {0}", score);
    }
}
