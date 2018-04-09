using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    public class PlayerAudio : MonoBehaviour
    {

        public AudioSource onHurtSound;
        private PlayerController player;

        #region Unity Functions
        void Start()
        {

        }
        
        void Update()
        {

        }
        #endregion

        #region Custom Functions
        void OnHurt()
        {
            onHurtSound.Play();
        }
        #endregion
    }
}

