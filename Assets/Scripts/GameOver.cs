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
	private GameObject[] monsterArray;

    // Start is called before the first frame update
    void Start()
    {
		AudioManager.closeMusicFilter();
        
		//stop all monster movement and sounds
        monsterArray = GameObject.FindGameObjectsWithTag("Monster");
		foreach (GameObject m in monsterArray){
			m.GetComponent<MonsterMovement>().setMoving(false);
			m.GetComponent<AudioSource>().enabled = false;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called when Retry button is clicked in the Game Over menu.
    public void Retry()
    {
		AudioManager.PlaySound("button", 0.7f);
		SceneManager.LoadScene("BattleScene");
		AudioManager.openMusicFilter();
        
    }

    //Called when Menu button is clicked in the Game Over menu.
    public void Menu()
    {
		AudioManager.PlaySound("button", 0.7f);
		Destroy(GameObject.Find("MainAudio"));
		Destroy(GameObject.Find("BattleMusic"));
        SceneManager.LoadScene("MainMenuScene");
    }
}
