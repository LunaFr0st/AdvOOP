/*=============================================
-----------------------------------
Copyright (c) 2018 Cody Amies
-----------------------------------
@file: Spawner.cs
@date: 19/02/2018
@author: Cody Amies
@brief: Script for spawning objects via delegates
===============================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Delegates
{
    public class Spawner : MonoBehaviour
    {
        public Transform target;
        public GameObject trollPrefab, orcPrefab;
        public float spawnAmount = 1; // Amount to spawn
        public float spawnRate = 2f; // Rate of spawning in Time
        private float spawnTimer = 0f; // Timer to count up to spawnRate

        public delegate void SpawnDelegate();
        public SpawnDelegate spawnCallback;

        void Start()
        {
            spawnCallback += SpawnOrc;
            spawnCallback += SpawnTroll;
        }

        void Update()
        {
            spawnTimer += Time.deltaTime; // Increases spawnTimer in real time
            if (spawnTimer >= spawnRate)
            {
                for (int i = 0; i < spawnAmount; i++)
                {
                    spawnCallback.Invoke();
                }
                spawnTimer = 0f;
            }
        }

        void SpawnOrc()
        {
            GameObject clone = Instantiate(orcPrefab, transform.position, Quaternion.identity);

            NavMeshAgent agent = clone.GetComponent<NavMeshAgent>();
            agent.SetDestination(target.position);
        }
        void SpawnTroll()
        {
            GameObject clone = Instantiate(trollPrefab, transform.position, Quaternion.identity);

            NavMeshAgent agent = clone.GetComponent<NavMeshAgent>();
            agent.SetDestination(target.position);
        }
    }
}

