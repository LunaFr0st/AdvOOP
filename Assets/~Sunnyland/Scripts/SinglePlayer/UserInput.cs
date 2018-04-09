using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    public class UserInput : MonoBehaviour
    {
        public float horizontal;
        public float vertical;
        public bool isJumping;
        public bool isCrouching;

        PlayerController controller;

        void Start()
        {
            controller = GetComponent<PlayerController>();
        }

        void Update()
        {
            //Testing Purposes
            if (Input.GetKeyDown(KeyCode.U))
                controller.Hurt(10);
            //End Testing Purposes

            GetInput();
            controller.Move(horizontal);
            controller.Climb(vertical);
            if (isJumping)
                controller.Jump();
            if (isCrouching)
                controller.Crouch();
            else if (!isCrouching)
                controller.UnCrouch();

        }
        void GetInput()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            isJumping = Input.GetKeyDown(KeyCode.Space);
            isCrouching = Input.GetKeyDown(KeyCode.LeftControl);
        }
    }
}

