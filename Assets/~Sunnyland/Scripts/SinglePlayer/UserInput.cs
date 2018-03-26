using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    public class UserInput : MonoBehaviour
    {
        public float horizontal;
        public bool isJumping;
        public bool isCrouching;

        PlayerController controller;

        void Start()
        {
            controller = GetComponent<PlayerController>();
        }
        
        void Update()
        {
            GetInput();
            controller.Move(horizontal);
            if (isJumping)
                controller.Jump();

        }
        void GetInput()
        {
            horizontal = Input.GetAxis("Horizontal");
            isJumping = Input.GetKeyDown(KeyCode.Space);
            isCrouching = Input.GetKeyDown(KeyCode.LeftControl);
        }
    }
}

