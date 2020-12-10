﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handles movement of enemy objects
public class MonsterMovement : MonoBehaviour
{
    //Initializing Variables
    public Monster monster;
    public new Rigidbody2D rigidbody2D;
    
    public float monsterSpeed;
    public float followRange = 1.5f;
    public float minMonsterSpeed = 1.5f;
    public float maxMonsterSpeed = 4.5f;
    public float addedSpeed = 1.0f;
    private TargetController tmp;
    private Animator monsterAnimator;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        monsterAnimator = GetComponent<Animator>();
        tmp = GetComponent<TargetController>();
        monsterSpeed = Random.Range(minMonsterSpeed, maxMonsterSpeed);
		isMoving = true;
    }


    // Update is called once per frame
    //Want enemy to move towards player every frame
    void Update()
    {
		if (isMoving){
			move();
		}
    }

    //Helper function that handles whether to move the monster/enemy left or right towards the player
    //Most likely will be updated in later versions
    public void move()
    {
        bool has_target = tmp.target_locked;
        float directionVal = 0f;

        //If target is found, we compute distance and then check what it is.
        //Sets directionVal to either -1 or 1, we use this to determine going left or right.
        //If no target, ddon't move.

        if (has_target)
        {
            float comp_dist = tmp.enemy_pos.x - transform.position.x;

            if (Mathf.Abs(comp_dist) <= followRange)
            {
                monsterAnimator.SetTrigger("Idle");
                rigidbody2D.velocity = new Vector2(0.0F, rigidbody2D.velocity.y);
                return;
            }

            if (comp_dist > 1f)
                directionVal = 1.0f;
            else if (comp_dist < 1f)
                directionVal = -1.0f;

            if (monster.type == 0)
            {
                monsterAnimator.SetTrigger("Walk0");
            }
            else if (monster.type == 1)
            {
                monsterAnimator.SetTrigger("Walk1");
            }
            else if (monster.type == 2)
            {
                monsterAnimator.SetTrigger("Walk2");
            }
            Vector2 moveDir = new Vector2(directionVal * monsterSpeed, rigidbody2D.velocity.y);
            rigidbody2D.velocity = moveDir;
        }

        else
        {
            rigidbody2D.velocity = new Vector2(0.0F, rigidbody2D.velocity.y);
        }
    }

    public void updateSpeed()
    {
        minMonsterSpeed += addedSpeed;
        maxMonsterSpeed += addedSpeed;
    } 

	public void setMoving(bool newValue){
		isMoving = newValue;
	}

}

