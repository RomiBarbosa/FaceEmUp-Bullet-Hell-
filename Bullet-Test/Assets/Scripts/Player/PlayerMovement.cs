﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    Vector2 movement;
    public float xMin, xMax, yMin, yMax;

    void Update () {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButton("ralentizar"/*KeyCode.Z*/))
        {
            moveSpeed = 2;
            
        }
        else { moveSpeed = 7;

        }
	}

    private void FixedUpdate()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, xMin, xMax), Mathf.Clamp(transform.position.y, yMin, yMax));
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
