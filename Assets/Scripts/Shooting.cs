using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CTRL+K+D

namespace Functions
{
    public class Shooting : MonoBehaviour
    {

        // Stores the object we want to Instantiate
        public GameObject projectilePrefab;

        // Speed at which the projectile will be flung
        public float projectileSpeed = 20f;

        // Rate of fire
        public float shootRate = 0.1f;

        // Timer to count up to shootRate
        private float shootTimer = 0f;

        // Container for the Rigidbody2D
        private Rigidbody2D rigid;

        // creating Recoil?
        public float recoil = 5f;

        // Use this for initialization
        void Start()
        {
            // Get the Rigidbody component
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            // Increase the Timer
            shootTimer += Time.deltaTime; // <= how to count up in seconds
            // AND: &&
            // OR: ||
            // Not Equal To: !=
            // Is Equal to: ==

            // If SPACEBAR is pressed AND shootTimer is >= shootRate, then CALL Shoot() and RESET shootTimer = 0
            // shootTimer and shootRate work together to create the RATE OF FIRE

            if (Input.GetKey(KeyCode.Space) && shootTimer >= shootRate)
            {
                Shoot();
                shootTimer = 0; // RESET? check original value at top
            }
        }

        void Shoot()
        {
            Debug.Log("Calling Shoot = ");

            // Instantiate a new copy of projectilePrefab
            // Instantiate(projectilePrefab);
            GameObject projectile = Instantiate(projectilePrefab);

            // Position of projectile = transform position
            projectile.transform.position = transform.position; // spawn Projectile at Player's position (press SPACE!)

            // Apply a force to the projectile
            Rigidbody2D projectileRigid = projectile.GetComponent<Rigidbody2D>();
            projectileRigid.AddForce(transform.right * projectileSpeed, ForceMode2D.Impulse);

            // Apply a recoil to the player
            rigid.AddForce(-transform.right * recoil, ForceMode2D.Impulse);
        }
    }
}