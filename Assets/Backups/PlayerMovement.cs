using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    float mx;
    public Rigidbody2D rigidbody2D;

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        Vector2 moveDir = new Vector2(mx * playerSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = moveDir;
    }
    
}