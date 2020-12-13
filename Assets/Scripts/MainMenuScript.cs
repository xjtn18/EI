using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Handles behavior of both Play and Quit buttons for the main menu scene.
public class MainMenuScript : MonoBehaviour
{
    public SceneFader fader;
    public string sceneToLoad;
	public AudioSource menuAudio;
	public AudioSource buttonSound;
    // Start is called before the first frame update
    void Start()
    {
        sceneToLoad = "BattleScene";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
		buttonSound.Play();
        fader.FadeTo(sceneToLoad);
		StartCoroutine(FadeAudioSource.StartFade(menuAudio, 1, 0));
    }

    public void QuitButton()
    {
        Debug.Log("QUIT PRESSED");
		buttonSound.Play();
        Application.Quit();
    }

    public void CreditButton()
    {
		buttonSound.Play();
        fader.FadeTo("CreditScene");
		StartCoroutine(FadeAudioSource.StartFade(menuAudio, 2, 0));
    }
}
