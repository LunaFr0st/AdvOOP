using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand.Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;
        public float maxVelocity = 2f;
        public float rayDist = 0.05f;
        public float jumpHeight = 2f;
        public int maxJumpCount = 2;
        public LayerMask groundLayer;

        private Vector3 moveDirection;
        private int currentJump = 0;

        private SpriteRenderer rend;
        private Animator anim;
        private Rigidbody2D rigi;

        
        void Start()
        {
            rend = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            rigi = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            moveDirection.y += Physics.gravity.y * Time.deltaTime;
        }
        
        void FixedUpdate()
        {
            DetectGround();
        }

        void OnDrawGizmos()
        {
            Ray groundRay = new Ray(transform.position, Vector3.down);
            Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDist);
        }
        // Custom Functions
        void DetectGround()
        {
            // Create a ray going down
            Ray groundRay = new Ray(transform.position, Vector3.down);
            Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDist);
            // Set Hit to 2D Raycast
            RaycastHit2D hit = Physics2D.Raycast(transform.position, groundRay.direction);
            // If hit collider is not null
            if(hit.collider != null)
            {
                currentJump = 0;
            }
        }

        void LimitVelocity()
        {
            // If Rigid's velocity (magnitude) is greater than maxVelocity
                // Set Rigid velocity to velocity normalized x maxVelocity
        }

        public void Climb()
        {
            // CHALLENGE
        }

        public void Jump()
        {
            // If currentJump is less than max jump
            // Increment currentJump
            // Add force to player (using Impulse)
        }

        public void Move(float horizontal)
        {
            // If horizontal > 0
            // Flip Character
            // If horizontal < 0
            // Flip Character

            // Add force to player in the right direction
            // Limit Velocity
        }
    }
}
