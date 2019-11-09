using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRnadomPosition : MonoBehaviour {

    Vector2 direction;
    public float speed;
    Rigidbody2D rb;
    GameObject target;
    public static System.Random r = new System.Random();
    Vector3 pos;
    void Start()
    {
       //var xp = r.Next(-15, 13);
       // var yp = r.Next(0, 7);
        rb = gameObject.GetComponent<Rigidbody2D>();
       pos = new Vector3(r.Next(-8, 8), r.Next(-6, 2));


            direction = (/*new Vector3(/*r.Next(-15, 13)10,10 r.Next(0, 7),0)*/ pos - transform.position/*target.transform.position - transform.position*/).normalized * speed;

        Debug.Log(pos.y);
        if (transform.position.y >= pos.y)
        {
            rb.velocity = new Vector2(direction.x, direction.y);
            Debug.Log("aaa");
        }
        else
        {
            transform.position = pos;
        }

        
    }

    private void Update()
    {
        if (transform.position.y >= pos.y)
        {
            rb.velocity = new Vector2(direction.x, direction.y);
            Debug.Log("aaa");
        }
        else
        {
            transform.position = pos;
            GetComponent<Shoot>().canShoot = true;
        }
    }
}
