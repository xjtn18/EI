using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that handles monster "lock-on" and tracking/targeting
public class TargetController : MonoBehaviour
{
    //Intializing variables
    bool no_more_enemy = false;
    float dist = 0.0f;
    public bool target_locked = false;
    public GameObject target = null;
    public Vector2 enemy_pos = new Vector2(0f, 0f);
    public float positionOffset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Calculating distance of the screen 
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float trueXWidth = Camera.main.orthographicSize * screenRatio * 2;
        dist = trueXWidth + 20;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("Player");
        if (tmp.Length == 0)
            no_more_enemy = true;
        if (no_more_enemy == false)
        {
            if (target_locked == false)
            {
                lock_on_target();
            }
            else if (target == null)
            {
                target_locked = false;
            }
            else
            {
                enemy_pos = DetermineStopPoint(target);

            }
        }
    }

    //Assigns player as a target for enemy objects
    void lock_on_target()
    {
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("Player");
        float min = dist;
        target = null;
        foreach (GameObject player in tmp)
        {
            //Calculated initially when enemy is first spawned to assign them the Player as a target.

            float comp_dist = player.transform.position.x - transform.position.x;

            if (comp_dist < min)
            {
                min = comp_dist;
                target_locked = true;
                target = player;
                enemy_pos = new Vector2(target.transform.position.x, target.transform.position.y);

            }
        }
        if (target == null)
        {
            no_more_enemy = true;
            target_locked = false;
        }
    }

    //Helper functions that returns a vector giving the enemy's position. If the enemy is to the left of the player
    //we can return the transform of the target. However, if the enemy is to the right, we need to add an offset value to keep
    //the enemy on the right side of the player sprite.
    Vector2 DetermineStopPoint(GameObject targetObj)
    {
        
        float comp_dist = targetObj.transform.position.x - transform.position.x;

        if (comp_dist >= 0)
        {
            enemy_pos = new Vector2(target.transform.position.x, target.transform.position.y);
            //Debug.Log("GREATER: " + enemy_pos.ToString());
        }

        else if (comp_dist < 0)
        {
            enemy_pos = new Vector2(target.transform.position.x , target.transform.position.y);
            //Debug.Log("GREATER: " + enemy_pos.ToString());
        }

        return enemy_pos;
    }


}

