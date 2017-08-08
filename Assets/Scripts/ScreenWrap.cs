using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script depends on the SpriteRenderer component attached to the same GameObject
[RequireComponent(typeof(SpriteRenderer))] // Requires it, so if GameObject doesn't have it it will be Added to the GameObject


public class ScreenWrap : MonoBehaviour
{
    // Sprite
    private SpriteRenderer spriteRenderer; // name of this specific Variable to be called on later (multiple SpriteRenderers should be named differently)

    // Camera
    private Bounds camBounds;
    private float camWidth;
    private float camHeight;

    void Awake() // starts before Start, on first 1/2 frame, e.g. to check if Low Data before running Start
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get Component of SpriteRenderer
    }

    // Start, starts on 1st frame.

    void UpdateCameraBounds ()
    {
        // Calculate Camera Bounds
        Camera cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        camBounds = new Bounds(cam.transform.position, new Vector2(camWidth, camHeight));
	}
	
	// LateUpdate is called before Update, e.g. to calculate Damage and Health Cap before Health Loss and GUI, a way to organise Updates
    // Use LateUpdate since we are using the camera to wrap objects back around
	void LateUpdate ()
    {
        UpdateCameraBounds();

        // store position and size in shorter variable names
        Vector3 pos = transform.position; // position of our enemy
        Vector3 size = spriteRenderer.bounds.size; // the size of our enemy

        // calculate the sprite's half width and height
        float halfWidth = size.x / 2f;
        float halfHeight = size.y / 2f;
        float halfCamWidth = camWidth / 2f;
        float halfCamHeight = camHeight / 2f;

        // Check Left
        if(pos.x + halfWidth < camBounds.min.x)
        {
            pos.x = camBounds.max.x + halfWidth;
        }

        // Check Right, calculating where we are then moving us to another location
        if(pos.x - halfWidth > camBounds.max.x)
        {
            pos.x = camBounds.min.x - halfWidth;
        }

        // Check Top
        if(pos.y - halfHeight > camBounds.max.y)
        {
            pos.y = camBounds.min.y - halfHeight;
        }

        // Check Bottom
        if(pos.y + halfHeight < camBounds.min.y)
        {
            pos.y = camBounds.max.y + halfHeight;
        }

        // set new Position
        transform.position = pos;
	}
}
