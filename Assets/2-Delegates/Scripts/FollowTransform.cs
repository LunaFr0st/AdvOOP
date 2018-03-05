/*=============================================
-----------------------------------
Copyright (c) 2018 Cody Amies
-----------------------------------
@file: Spawner.cs
@date: 19/02/2018
@author: Cody Amies
@brief: Updates targets position for Agents to follow
===============================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTransform : MonoBehaviour
{

    public Transform target;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Target").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
