using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class RotateToVelocity : MonoBehaviour
    {

        private Rigidbody2D rigid2D; // making it a Rigidbody2D Variable as "rigid2D" so we can call it specifically later
        
        // Use this for initialization
        void Start()
        {
            // rigid2D = this.gameObject.GetComponent<>();
            rigid2D = GetComponent<Rigidbody2D>(); // specifying the Variable to Use this Component in the scene
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 vel = rigid2D.velocity;
            float angle = Mathf.Atan2(vel.y, vel.x); // <= huh??
            rigid2D.rotation = angle * Mathf.Rad2Deg;
        }
    }
}
