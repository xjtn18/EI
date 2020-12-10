using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Handles scene fading from LogoScene > IntroScene
public class LogoScene : MonoBehaviour
{ 
public SceneFader fader;
public float timer;
private float defaultTimer = 2.0f;
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
        fader.FadeTo("IntroScene");
    }
}
}