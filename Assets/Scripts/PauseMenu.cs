using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    //Initializing variables
    public GameObject UI;
    public SceneFader sceneFader;
    public string menuScene = "MainMenuScene";



    // Update is called once per frame
    //If escape or P is pressed in game, toggles the pause menu UI by calling TogglePause().
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            TogglePause();
        }


    }

    //Checks to see if the UI is already active, if not, pauses time and brings up the menu. If it is, disables the pause menu and continues the flow of time.
    public void TogglePause()
    {
        UI.SetActive(!UI.activeSelf);
        if (UI.activeSelf)
        {
            Time.timeScale = 0;
        }

        else
        {
            Time.timeScale = 1;
        }
    }

    //If menu button is clicked in the pause menu, TogglePause() is called, to continue time, then fades to main menu scene.
    public void MenuButton()
    {
        TogglePause();
        sceneFader.FadeTo(menuScene);
    }

    //If retry button is called, sets time scale back to 1 to resume the game and then restarts the level.
    public void RetryButton()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
}