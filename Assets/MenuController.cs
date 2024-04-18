using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorialWindow;
    
    [SerializeField]
    private Texture2D cursorTexture;

    private void Awake()
    {
        Vector2 cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }

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
