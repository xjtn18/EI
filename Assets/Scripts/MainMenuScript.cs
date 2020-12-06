﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public SceneFader fader;
    public string sceneToLoad;
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
        fader.FadeTo(sceneToLoad);
    }

    public void QuitButton()
    {
        Debug.Log("QUIT PRESSED");
        Application.Quit();
    }
}
