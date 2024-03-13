using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    private int score;

    private void Start()
    {
        this.score = 0;
    }

    public void SetScore(int score)
    {
        this.score = score;
    }

    public void AddToScore(int toAdd)
    {
        this.score += toAdd;
    }

    public int GetScore()
    {
        return this.score;
    }
}
