using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Game manager script is the overseer of the game. Checks to see whether or not the game is over.
public class GameManager : MonoBehaviour
{
    //Initializing variables
    //Right now just for GameOver
    public static bool gameOverStatus;
    public GameObject gameOverUI;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverStatus = false;
		new AudioManager(); // start the audio manager
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverStatus == true)
        {
            return;
        }
            
        //Simulates being hit. Calls GameOver() if health is 0.
        if (Input.GetKeyDown("g"))
        {
            PlayerInfo.health--;
            //Debug statement
            Debug.Log(PlayerInfo.health.ToString());
        }

        if (PlayerInfo.health == 0)
        {
            GameOver();
        }
    }



    //GameOver functions triggers the UI to become active.
    void GameOver()
    {
        gameOverStatus = true;
        gameOverUI.SetActive(true);
        //Debug statement
        Debug.Log("Game Ended");

    }
}


    
