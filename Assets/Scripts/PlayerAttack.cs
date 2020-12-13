using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2.5f;    //the reach of player's attack
    public float delay = 0.25f; //how long before an attack registers.
    public float attackDuration = 0.4f;    //how long until can attack again.
    public float playerTimer = 0.0f;
    public bool attackStarted = false;
    public string keyPressed;
    private bool hasAlreadyAttacked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attackStarted)
        {
            if (playerTimer > delay && hasAlreadyAttacked == false)
            {
                //perform attack
                doAttack(GetComponent<PlayerMovement>().playerSpriteRenderer.flipX);
                hasAlreadyAttacked = true;
            }
            else if (playerTimer >= attackDuration)
            {
                //reset attack
                playerTimer = 0;
                attackStarted = false;
                hasAlreadyAttacked = false;
            }
            else
            {
                playerTimer += Time.deltaTime;
            }
        }
    }

    //Compares key pressed by player to enemy's chosen key. Then checks to see if character is
    //facing the enemy's direction. If they are, and enemy is in range, they take damage from
    //the attack.
    public void doAttack(bool facingLeft)
    {
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject m in tmp)
        {
            string correctKey = m.GetComponent<Monster>().GetKey();
            if (keyPressed == correctKey)
            {
                float comp_dist = m.transform.position.x - transform.position.x;
                if ((comp_dist < 0.0F && facingLeft) || (comp_dist > 0.0F && !facingLeft))
                {
                    if (Mathf.Abs(comp_dist) <= attackRange)
                        m.GetComponent<Monster>().TakeDamage();
                }
            }
        }
		AudioManager.PlaySound("sword_hit");
		AudioManager.PlayRandom("swoosh", 4);
    }

    public bool canStartAttack()
    {
        return !attackStarted;
    }

    public void startAttack()
    {
        attackStarted = true;
    }
}
