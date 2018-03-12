/*=============================================
-----------------------------------
Copyright (c) 2018 Cody Amies
-----------------------------------
@file:      Movement.cs
@date:      05/03/2018
@author:    Cody Amies
@brief:     Allows Movement for the player
===============================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 2.0F;
    public float gravity = 10.0F;
    public int maxJump = 2;
    public float maxVelocity = 6f;

    private Vector3 moveDirection = Vector3.zero;
    private int currentJump = 0;
    public bool isClimbingLadder = false;

    SpriteRenderer rend;
    Animator anim;
    Rigidbody2D rigi;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveChar();
        
        moveDirection.y -= gravity * Time.deltaTime;

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Flooring")
        {
            print("oof");
            currentJump = 0;
        }
    }
    void MoveChar()
    {
        float hori = Input.GetAxis("Horizontal");
        if (hori < 0)
        {
            rend.flipX = true;
            anim.SetBool("isRunning", true);
        }
        else if (hori > 0)
        {
            rend.flipX = false;
            anim.SetBool("isRunning", true);
        }
        else
            anim.SetBool("isRunning", false);

        //  transform.position += (new Vector3(hori * speed * Time.deltaTime, 0, 0));
        
        rigi.AddForce(new Vector2(hori * speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        if(rigi.velocity.x >= maxVelocity)
        {
            rigi.velocity = new Vector2(maxVelocity, 0);
        }
        
        if (!isClimbingLadder)
        {
            if (Input.GetKeyDown(KeyCode.Space) && currentJump <= maxJump)
            {
                currentJump++;
                anim.Play("Jump");
                rigi.velocity = Vector2.zero;
                rigi.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            }
        }
        
        if (isClimbingLadder)
        {
            float vert = Input.GetAxis("Vertical");
            if (vert < 0)
            {
                anim.SetBool("isClimbing", true);
            }
            else if (vert > 0)
            {
                rend.flipX = false;
                anim.SetBool("isRunning", true);
            }
            else
                anim.SetBool("isRunning", false);
        }
    }
}
