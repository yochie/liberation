using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool GameIsPaused { get; private set; }

    private void Start()
    {
        PauseController.PauseGame(false);
    }

    public static void PauseGame(bool paused)
    {
        if (paused)
        {            
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
        PauseController.GameIsPaused = paused;
    }


}
