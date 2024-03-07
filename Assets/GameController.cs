using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        this.ui.DisplayEndScreen();
    }
}
