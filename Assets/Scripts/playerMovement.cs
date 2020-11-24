using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script handles movement and actions of the player.
public class PlayerMovement : MonoBehaviour
{
    //Initializing and defining variables

    public float walkSpeed; //Default: 4f? Subject to change
    public Monster testMonster;
    private SpriteRenderer playerSpriteRenderer;
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
        // "A" and "D" movement keys to move left and right (may remove later)
        // "J" for attack
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

        if (Input.GetKeyDown(testMonster.keyText.text.ToLower()))
        {
            playerAnimator.SetTrigger("Attack");
       
            Debug.Log("DOING ANIMATION");
    
        }

        
    }
}
