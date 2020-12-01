using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public AnimationCurve fadeCurve;
    // Start is called before the first frame update
    //We utilize a Coroutine here because we want to the screen to "Fade" in/out over multiple frames.
    //Better and easier to do then in the update method, where everything in there is called once per frame.
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeTo(string newSceneName)
    {
        StartCoroutine(FadeOut(newSceneName));
    }

    //Coroutine that fades the active scene into the game.
    IEnumerator FadeIn()
    {
        float timeVal = 1f;
        while (timeVal > 0)
        {
            timeVal -= Time.deltaTime;
            float alphaVal = fadeCurve.Evaluate(timeVal);
            fadeImage.color = new Color(0f, 0f, 0f, alphaVal);
            yield return null;
        }


    }

    //Coroutine that fades the active scene out towards a black overlay.
    IEnumerator FadeOut(string newSceneName)
    {
        float timeVal = 0f;
        while (timeVal < 1f)
        {
            timeVal += Time.deltaTime;
            float alphaVal = fadeCurve.Evaluate(timeVal);
            fadeImage.color = new Color(0f, 0f, 0f, alphaVal);
            yield return null;
        }

        SceneManager.LoadScene(newSceneName);


    }

}
