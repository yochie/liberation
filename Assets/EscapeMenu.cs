using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private GameObject content;

    private bool opened;

    private void Start()
    {
        this.opened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.Toggle();
        }
    }

    public void Toggle()
    {        
        this.opened = !this.opened;
        this.content.SetActive(this.opened);
        PauseController.PauseGame(this.opened);
    }

    public void ReturnToMainMenu()
    {
        this.gameController.ReturnToMainMenu();
    }

    public void ExitGame()
    {
        this.gameController.ExitGame();
    }
}
