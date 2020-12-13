using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Game manager script is the overseer of the game. Checks to see whether or not the game is over.
public class GameManager : MonoBehaviour
{
    //Initializing variables
    //Right now just for GameOver
    public bool gameOverStatus = false;
    public GameObject gameOverUI;
    public GameObject scoreUI;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverStatus = false;
		AudioManager.start(); // start the audio manager
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverStatus == true)
        {
            return;
        }

        //Simulates being hit. Calls GameOver() if health is 0.
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            PlayerInfo.health--;
            //Debug statement
            Debug.Log(PlayerInfo.health.ToString());
        }

        if (PlayerInfo.health == 0)
        {
            StartCoroutine(GameOver());
        }
    }



    //GameOver functions triggers the UI to become active.
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.0f);
        gameOverStatus = true;
        gameOverUI.SetActive(true);
        scoreUI.SetActive(false);
        //Debug statement


    }
}


    
