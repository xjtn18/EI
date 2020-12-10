using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script handles the behavior of the player's score being "totaled" at a game over state by 
//executing the coroutine AnimateText.
public class FinalScoreScript : MonoBehaviour
{
    public Text scoreText;
    public int finalScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        finalScore = PlayerInfo.score;
    }

    void OnEnable()
    {
        StartCoroutine(AnimateText());
        //waveCounterText.text = wavesSurvived.ToString();
    }

    //Animate text coroutine starts from 0 and counts up to the numer of waves that the player survived.
    IEnumerator AnimateText()
    {
        scoreText.text = "0";
        int startPoint = 0;
        yield return new WaitForSeconds(.3f);
        while (startPoint < finalScore)
        {
            startPoint+= 100;
            scoreText.text = startPoint.ToString();
            yield return new WaitForSeconds(.02f);
        }
    }
}
