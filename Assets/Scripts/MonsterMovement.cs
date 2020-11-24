using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handles movement of enemy objects
public class MonsterMovement : MonoBehaviour
{
    //Initializing Variables
    public float monsterSpeed;
    public Rigidbody2D rigidbody2D;
    public float followRange = 1.5f;
    private TargetController tmp;

    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
    //Want enemy to move towards player every frame
    void Update()
    {
        move();
    }

    //Helper function that handles whether to move the monster/enemy left or right towards the player
    //Most likely will be updated in later versions
    void move()
    {
        tmp = GetComponent<TargetController>();
        bool has_target = tmp.target_locked;
        
        float directionVal = 0f;
        
        //If target is found, we compute distance and then check what it is.
        //Sets directionVal to either -1 or 1, we use this to determine going left or right.
        //If no target, ddon't move.
        
        if (has_target)
        {
            float comp_dist = tmp.enemy_pos.x - transform.position.x;
            
            if (comp_dist > 1f)
                directionVal = 1.0f;
            else if (comp_dist < 1f)
                    directionVal = -1.0f;

            Vector2 moveDir = new Vector2(directionVal * monsterSpeed, rigidbody2D.velocity.y);
            rigidbody2D.velocity = moveDir;
        }

        else
        {
            rigidbody2D.velocity = new Vector2(0.0F, rigidbody2D.velocity.y);
        }
    }   

    //Old code use in move() function. May be useful later?

    /*float comp_dist = Mathf.Abs(tmp.enemy_pos.x - transform.position.x);

    if (comp_dist >= 1.5F && (tmp.enemy_pos.x - transform.position.x) > 0)
        directionVal = 1.0f;
    else if ((tmp.enemy_pos.x - transform.position.x) < 0)
        directionVal = -1.0f;

    Vector2 moveDir = new Vector2(directionVal * monsterSpeed, rigidbody2D.velocity.y);

    rigidbody2D.velocity = moveDir;*/

}
