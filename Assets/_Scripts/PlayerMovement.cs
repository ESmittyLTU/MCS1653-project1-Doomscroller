using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 8.0f;
    public float speedMult = 1;

    public float jumpForce = 20.0f;
    public float jumpMult = 1;

    public int health = 3;

    public BoxCollider2D groundCollider;
    private Rigidbody2D rb;
    private const float gravity = 4.0f;

    // Improvements to consider:
    // - Double jump
    // - Easing into movement (accelerating more slowly)


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        // Takes A/D or L/R arrow and stores it in horiz, if horiz isnt 0 (aka a horizontal movement key
        // is being pressed), transform position by that amount * modifiers
        float horiz = Input.GetAxis("Horizontal");
        if (horiz != 0)
        {
            transform.position += new Vector3(1, 0, 0) * horiz * speed * speedMult * Time.deltaTime;
        }

        //If on the ground, allow player to jump on keypress
        if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(Vector3.up * jumpForce * jumpMult, ForceMode2D.Impulse);
            }
        }


    }
    private bool IsGrounded()
    {
        //Also checks if player does not have vertical velocity (ie, falling or mid-jump)
        if (rb.velocity.y < 0.01f)
        {
            return groundCollider.IsTouchingLayers(LayerMask.GetMask("Platform"));
        } else
        {
            return false;
        }
    }

}
