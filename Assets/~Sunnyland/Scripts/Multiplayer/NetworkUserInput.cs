using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace SunnyLand
{
    [RequireComponent(typeof(PlayerController))]
    public class NetworkUserInput : NetworkBehaviour
    {
        PlayerController controller;

    }
}

