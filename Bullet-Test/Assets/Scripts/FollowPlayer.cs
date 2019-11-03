using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    Rigidbody2D rb;
    GameObject target;
   public  float movespeed;
    Vector2 directiontoTarget;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        directiontoTarget = (target.transform.position - transform.position).normalized * movespeed;
        rb.velocity = new Vector2(directiontoTarget.x, directiontoTarget.y);
    }
}
