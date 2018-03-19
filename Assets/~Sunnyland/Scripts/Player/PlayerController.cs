using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;
        public float maxVelocity = 2f;
        [Header("Grounding")]
        public float rayDist = 0.05f;
        public float maxSlopeAngle = 45f;
        public bool isGrounded = false;

        [Header("Crouch")]
        public bool isCrouching = false;

        [Header("Jump")]
        public float jumpHeight = 2f;
        public int maxJumpCount = 2;
        public bool isJumping = false;
        private int currentJump = 0;

        [Header("Climb")]
        public float climbSpeed = 5f;
        public bool isClimbing = false;
        public bool isOnSlope = false;

        [Header("Refrences")]
        private Vector3 moveDirection;
        private Vector3 groundNormal = Vector3.up;
        private SpriteRenderer rend;
        private Animator anim;
        private Rigidbody2D rigi;

        [Header("Delegates")]
        public EventCallback onJump;
        public EventCallback onHurt;
        public BoolCallback onCrouchChanged;
        public BoolCallback onGroundedChanged;
        public BoolCallback onClimbChanged;
        public BoolCallback onSlopeChanged;
        public FloatCallback onMove;
        public FloatCallback onClimb;

        private float _vertical, _horizontal;


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

        bool CheckSlope(RaycastHit2D hit)
        {
            float slopeAngle = Vector3.Angle(Vector3.up, hit.normal);
            if (slopeAngle > maxSlopeAngle)
            {
                rigi.AddForce(Physics.gravity);
            }
            if (slopeAngle > 0 && slopeAngle < maxSlopeAngle)
            {
                return true;
            }
            return false;
        }

        bool CheckGround(RaycastHit2D hit)
        {
            // it hit something AND  // It didn't hit me AND        //It Didn't hit a trigger
            if (hit.collider != null && hit.collider.name != name && !hit.collider.isTrigger)
            {
                currentJump = 0;
                isGrounded = true;
                groundNormal = -hit.normal;
                bool wasOnSlope = isOnSlope;
                isOnSlope = CheckSlope(hit);
                if (wasOnSlope != isOnSlope)
                {
                    if (onSlopeChanged != null)
                    {
                        onSlopeChanged.Invoke(isOnSlope);
                    }
                }
                return true;
            }
            else
            {
                isGrounded = false;
            }
            return false;
        }
        // Custom Functions
        void DetectGround()
        {
            bool wasGrounded = isGrounded;
            // Create a ray going down
            Ray groundRay = new Ray(transform.position, Vector3.down);
            // Set Hit to 2D Raycast
            RaycastHit2D[] hits = Physics2D.RaycastAll(groundRay.origin, groundRay.origin + groundRay.direction, rayDist);
            // If hit collider is not null
            foreach (var hit in hits)
            {
                if (CheckGround(hit))
                    break;
            }
            if (wasGrounded != isGrounded && onGroundedChanged != null)
            {
                onGroundedChanged.Invoke(isGrounded);
            }
        }

        void LimitVelocity()
        {
            // If Rigid's velocity (magnitude) is greater than maxVelocity
            if (rigi.velocity.magnitude >= maxVelocity)
            {
                // Set Rigid velocity to velocity normalized x maxVelocity
                rigi.velocity = rigi.velocity.normalized * maxVelocity;
            }

        }

        public void Climb()
        {
            // CHALLENGE
        }

        public void Jump()
        {
            // If currentJump is less than max jump
            if (currentJump < maxJumpCount + 1)
            {
                // Increment currentJump
                currentJump++;
                // Add force to player (using Impulse)
                rigi.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            }

        }

        public void Move(float horizontal)
        {
            // If horizontal > 0
            if (horizontal > 0)
            {
                // Flip Character
                rend.flipX = false;
            }
            // If horizontal < 0
            if (horizontal < 0)
            {
                // Flip Character
                rend.flipX = true;
            }

            // Add force to player in the right direction
            rigi.AddForce(Vector2.right * horizontal * speed);
            // Limit Velocity
            LimitVelocity();
        }
    }
}
