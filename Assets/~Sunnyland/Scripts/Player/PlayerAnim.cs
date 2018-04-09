using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    public class PlayerAnim : MonoBehaviour
    {
        private PlayerController player;
        private Animator anim;
        private Rigidbody2D rigi;
        void Start()
        {
            anim = GetComponent<Animator>();
            player = GetComponent<PlayerController>();
            rigi = GetComponent<Rigidbody2D>();
            player.onGroundedChanged += OnGroundedChanged;
            player.onJump += OnJump;
            player.onHurt += OnHurt;
            player.onMove += OnMove;
            player.onClimb += OnClimb;
        }

        void Update()
        {
            anim.SetBool("isGrounded", player.isGrounded);
            anim.SetBool("isCrouching", player.isCrouching);
            anim.SetBool("isClimbing", player.isClimbing);
            anim.SetFloat("JumpY", rigi.velocity.normalized.y);
        }

        void OnGroundedChanged(bool isGrounded)
        {
            if (isGrounded)
                Debug.Log("grounded");
            else
                Debug.Log("notGrounded");
        }

        void OnJump()
        {
            
        }
        void OnHurt()
        {
            anim.SetTrigger("Hurt");
        }
        void OnMove(float input)
        {
            anim.SetBool("isRunning",input != 0);
        }
        void OnClimb(float input)
        {
            anim.SetFloat("ClimbY", Mathf.Abs(input));
        }
    }
}

