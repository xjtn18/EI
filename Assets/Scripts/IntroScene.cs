using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Handles scene fading for the IntroScene > MainMenuScene
public class IntroScene : MonoBehaviour
{
    public SceneFader fader;
    public float timer;
    private float defaultTimer = 6.5f;
    // Start is called before the first frame update
    void Start()
    {
        timer = defaultTimer;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timer)
        {
            fader.FadeTo("MainMenuScene");
        }

    }
}
