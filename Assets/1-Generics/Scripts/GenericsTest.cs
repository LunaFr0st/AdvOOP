using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generics
{
    public class GenericsTest : MonoBehaviour
    {
        public GameObject prefab;
        public int spawnAmount = 20;
        public float spawnRadius = 50f;
        public CustomList<GameObject> gameObjects = new CustomList<GameObject>();
        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                GameObject clone = Instantiate(prefab);
                Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
                clone.transform.position = randomPos;
                gameObjects.Add(clone);
            }
        }
    }
}
