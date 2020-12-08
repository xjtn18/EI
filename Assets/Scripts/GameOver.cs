using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Script handles the Game Over menu and it's behavior.
// *** Still need to implement proper code for Retry() and Menu().
public class GameOver : MonoBehaviour
{
    //Intializing public variables.
    public GameObject gameOverUI;
    public string menuScene = "MainMenuScene";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called when Retry button is clicked in the Game Over menu.
    public void Retry()
    {
		SceneManager.LoadScene("BattleScene");
        Debug.Log("Retry Clicked");
    }

    //Called when Menu button is clicked in the Game Over menu.
    public void Menu()
    {
        SceneManager.LoadScene("MainMenuScene");
        Debug.Log("Menu Clicked");
    }
}
