using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // How to clean up code:
    // Step 1: CTRL+A (Highlight all code)
    // Step 2: CTRL+K+D (In that order)

    // Highlight multiple lines
    // SHIFT+ALT+(UP or DOWN Arrows)

    // Write Statements (e.g. "rigid =" inside Functions e.g. "Start()"!

    // <access-specifier> <data-type> <variable-name>
    public int lives = 3;
    public float rotationSpeed = 2;
    public float movementSpeed = 2;
    public float acceleration = 50f;
    public float deceleration = .1f;

    // Objects default to 'null'
    private Rigidbody2D rigid;

    // Use this for initialization
    void Start()
    {
        // Debug.Log("Before Setting Rigid: " + rigid);
        rigid = GetComponent<Rigidbody2D>();
        // Debug.Log("After Setting Rigid: " + rigid);
    }

    // Update is called once per frame
    void Update()
    {
        // (x,y,z)
        // (1,0,0) = Right
        // (-1,0,0) = Left
        // (0,1,0) = Up
        // (0,-1,0) = Down
        // (0,0,1) = Forward
        // (0,0,-1) = Backward

        // If User presses W or Up Arrow
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Move Forward
            rigid.AddForce(transform.right * acceleration);
        }

        // If User presses S or Down Arrow
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // Move Backward
            rigid.AddForce(-transform.right * acceleration);
        }

        // If User presses A or Left Arrow
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotate Left
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed, Vector3.forward);
            //Example from Unity Docs: transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
        }

        // If User presses D or Right Arrow
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Rotate Right
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed, -Vector3.forward);
        }

        // Deceleration
        rigid.velocity = rigid.velocity + (-rigid.velocity * deceleration);
        // or rigid.velocity += -rigid.velocity * deceleration;
    }
}
