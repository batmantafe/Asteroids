using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes
{

    public class EnemySpawner : MonoBehaviour
    {

        public GameObject enemyPrefab; // Object to spawn in
        public float spawnRate = 1f; // spawnRate so it doesn't spawn every single frame
        public float spawnRadius = 1f; // spawn radius
        public float force = 20f; // force to move spawned Object
        
        void OnDrawGizmos() // create Gizmo, similar to GUI but can be interacted with for debugging purposes
        {
            Gizmos.color = Color.red; // set Gizmo color to Red
            Gizmos.DrawWireSphere(transform.position,spawnRadius); // draws a wiferame sphere with center and radius
        }

        // Use this for initialization
        void Start()
        {
            // InvokeRepeating(functionName, time, repeatRate)
            // functionName = name of the function you want to call in the Class
            // time = delay for when the function gets called the first time
            // repeatRate = how often the function gets called
            InvokeRepeating("Spawn",0,spawnRate);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void Spawn()
        {
            // Instantiate a new GameObject
            GameObject enemy = Instantiate(enemyPrefab);

            // Position it to a random place within the screen (inside the spawnRadius)
            enemy.transform.position = Random.insideUnitCircle * spawnRadius;

            // Apply force to RigidBody
            Rigidbody2D rigid2D = enemy.GetComponent<Rigidbody2D>();
            rigid2D.AddForce(Random.insideUnitCircle * force);
        }
    }
}
