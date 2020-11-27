using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains information relevant to the player, such as stats, equipment, etc.
public class PlayerInfo : MonoBehaviour
{
    //Initializing variables
    public static int health;
    public int startingHealth;


    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
