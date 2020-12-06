﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Monster : MonoBehaviour
{
    public int health = 1;
    public float attackDelay;
    private float timer = 99;

    [Header("UI Elements")]
    public Image keyBackground;
    public Text keyText;
    public GameObject[] targetArray;
    List<string> keyTextList = new List<string> { "J", "K", "L" };


    // Start is called before the first frame update
    //Chooses a random string to assign to each monster. This string will be what the player needs to press
    //to deal damage to them.
    void Start()
    {
        keyBackground.enabled = false;
        keyText.enabled = false;
        int index = Random.Range(0, keyTextList.Count);
        keyText.text = keyTextList[index];      
        targetArray = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        else{
            foreach (GameObject player in targetArray)
            {
                //Calculated initially when enemy is first spawned to assign them the Player as a target.
                //Determines when overhead keys are shown
                float comp_dist =player.transform.position.x - transform.position.x;
                if (Mathf.Abs(comp_dist) <= 5)
                {
                    keyBackground.enabled = true;
                    keyText.enabled = true;
                    //If enemy is close enough to the player, and has never attacked, we start the coroutine
                    //and reset the timer to 0. The enemy doesn't attack again until timer is > attackDelay.
                    //We can set these variables on the monster prefab.
                    if (Mathf.Abs(comp_dist) <= 1.5)
                    {
                        if (timer > attackDelay)
                        {
                            StartCoroutine(DoAttack());
                            timer = 0;
                        }
                        else
                        {
                            timer += Time.deltaTime;
                        }
                    }
                }
            }
        }
    }
    
    //Subtracts monster's health by 1
    public void TakeDamage()
    {
        health -= 1;
    }

    //Returns a string of the monster's Key in lowercase string form
    public string GetKey()
    {
        return keyText.text.ToLower();
    }

    //Part of the coroutine. Waits for the number of seconds in the WaitForSeconds method. Then, if
    //the unit still exists, subtraccts player health by 1.
    private IEnumerator DoAttack()
    {
        yield return new WaitForSeconds(2);
        PlayerInfo.health--;
        Debug.Log(PlayerInfo.health.ToString());
        
    }

}

