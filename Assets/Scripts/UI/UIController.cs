using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private BarDisplay healthDisplay;
    
    [SerializeField]
    private Hitable playerHitable;

    [SerializeField]
    private BarDisplay ammoDisplay;

    [SerializeField]
    private Ammo playerAmmo;

    [SerializeField]
    private EndScreen endScreen;

    [SerializeField]
    private ScoreDisplay scoreDisplay;

    [SerializeField]
    private Scorer scorer;

    private void Update()
    {
        this.healthDisplay.Set(this.playerHitable.GetCurrentHP(), this.playerHitable.GetMaxHP());
        this.ammoDisplay.Set(this.playerAmmo.GetCurrentAmmo(), this.playerAmmo.GetMaxAmmo());
        this.scoreDisplay.Set(this.scorer.GetScore());
    }

    internal void DisplayEndScreen(int score)
    {
        this.endScreen.Display(score);
    }
}
