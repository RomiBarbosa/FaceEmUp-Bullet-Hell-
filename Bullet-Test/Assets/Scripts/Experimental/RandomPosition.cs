using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour {

    Rigidbody2D rb;
    GameObject target;
    float movespeed;
    Vector2 directiontoTarget;
    System.Random rand = new System.Random();
    private void Start()
    {
        target = new GameObject();
        target.transform.position = new Vector2(rand.Next(-100, 100), rand.Next(-100, 100)); 
        rb = GetComponent<Rigidbody2D>();
        movespeed = 5f;
        directiontoTarget = (target.transform.position - transform.position).normalized * movespeed;
        rb.velocity = new Vector2(directiontoTarget.x, directiontoTarget.y);
    }

}
