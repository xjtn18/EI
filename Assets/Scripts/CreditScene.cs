using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreditScene : MonoBehaviour
{
    public SceneFader fader;
    public string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        sceneToLoad = "MainMenuScene";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackButton()
    {
        fader.FadeTo(sceneToLoad);
    }
}