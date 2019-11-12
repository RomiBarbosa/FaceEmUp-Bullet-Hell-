using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    Vector2 movement;
    public float xMin, xMax, yMin, yMax;
    public float focusSpeed;

    void Update () {
        if (gameObject.name =="Player2")
        {
            movement.x = Input.GetAxisRaw("Horizontal2");
            movement.y = Input.GetAxisRaw("Vertical2");

        }
        else if(gameObject.name == "Player") {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        


        if (Input.GetButton("ralentizar"/*KeyCode.Z*/))
        {
            moveSpeed = focusSpeed;
            
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
