using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI label;

    internal void Set(int score)
    {
        this.label.text = String.Format("Score : {0}", score);
    }
}
