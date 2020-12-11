using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Contains information relevant to the player, such as stats, equipment, etc.
public class PlayerInfo : MonoBehaviour
{
    //Initializing variables
    public static int health;
    public int startingHealth;
    public static int score;
    public int startingScore;
    public Image[] heartsArray;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
        score = startingScore;
    }

    // Update is called once per frame
    void Update()
    {
        //Handles the healthUI display. Chooses whether to display fullHeart sprite or emptyHeart
        //depending on player health.

        for (int i = 0; i < heartsArray.Length; i++)
        {
            if (i < health)
            {
                heartsArray[i].sprite = fullHeart;
            }
            else
            {
                heartsArray[i].sprite = emptyHeart;
            }

            if (i < startingHealth)
            {
                heartsArray[i].enabled = true;
            }
            else
            {
                heartsArray[i].enabled = false;
            }
        }
    }

}

