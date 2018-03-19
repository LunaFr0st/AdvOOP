using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    public class PlayerAnim : MonoBehaviour
    {
        private PlayerController player;
        private Animator anim;
        void Start()
        {
            anim = GetComponent<Animator>();
            player = GetComponent<PlayerController>();
            player.onGroundedChanged += OnGroundedChanged;
        }
        void OnGroundedChanged(bool isGrounded)
        {
            if (isGrounded)
                Debug.Log("grounded");
            else
                Debug.Log("notGrounded");
        }
    }
}

