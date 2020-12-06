﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script handles movement and actions of the player.
public class PlayerMovement : MonoBehaviour
{
    //Initializing and defining variables

    public float walkSpeed; //Default: 4f? Subject to change
    //public Monster testMonster;
    public SpriteRenderer playerSpriteRenderer;
    public GameObject[] monsterList;
    private Animator playerAnimator;



    // Start is called before the first frame update
    void Start()
    {
        //Assigned components to variables
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame  
    void Update()
    {


        //Move this part of the script somewehere else later
        monsterList = GameObject.FindGameObjectsWithTag("Monster");
        List<string> keyTextList = new List<string>();
        foreach (GameObject monster in monsterList)
        {
            float comp_dist = Mathf.Abs(monster.transform.position.x - transform.position.x);
            if (comp_dist <= 3f)
            {
                keyTextList.Add(monster.GetComponent<Monster>().GetKey());
            }

        }


        // "A" and "D" movement keys to move left and right (may remove later)
        // "J, K, L" for attack as of right now

        if (Input.GetKey("a"))
        {
            transform.Translate(Vector2.left * Time.deltaTime * walkSpeed, Space.World);
            playerSpriteRenderer.flipX = true;
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector2.right * Time.deltaTime * walkSpeed, Space.World);
            playerSpriteRenderer.flipX = false;
        }


        foreach (string validKey in keyTextList)
        {
            if (Input.GetKeyDown(validKey))
            {
                PlayerAttack playerAttack = GetComponent<PlayerAttack>();
                playerAttack.keyPressed = validKey;
                if (playerAttack.canStartAttack())
                {
                    playerAnimator.SetTrigger("Attack");
                    playerAttack.startAttack();
                    //Debug.Log(" DOING ANIMATION");
                }
            }


        }
    }

}

