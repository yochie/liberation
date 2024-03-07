using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private HealthDisplay healthDisplay;

    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private Hitable playerHitable;

    [SerializeField]
    private EndScreen endScreen;

    private void Update()
    {
        this.healthDisplay.Set(this.playerHitable.GetCurrentHP(), this.playerHitable.GetMaxHP());
    }

    internal void DisplayEndScreen()
    {
        this.endScreen.Display();
    }
}
