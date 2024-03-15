using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorialWindow;

    public void Play()
    {
        SceneManager.LoadSceneAsync("Main");
    }

    //used by buttons
    public void ToggleTutorialWindow(bool display)
    {
        this.tutorialWindow.SetActive(display);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
