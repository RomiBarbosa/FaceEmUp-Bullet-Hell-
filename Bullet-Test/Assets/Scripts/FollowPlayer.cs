using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    Vector2 direccion;
    public float speed;
    public Rigidbody2D rb;
    public GameObject target;

    private void Start()
    {
        target = GameObject.Find("Player");
        direccion = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(direccion.x, direccion.y);
    }
    private void Update()
    {
        if (transform.position.y <= -11)
        {
            Destroy(this.gameObject);
        }
    }
}
