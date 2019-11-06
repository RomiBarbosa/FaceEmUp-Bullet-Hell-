using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove0 : MonoBehaviour {

    Vector2 direction;
    public float speed;
    Rigidbody2D rb;
    GameObject target;
	

	void Start () {

        rb = gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
        {
            direction = (target.transform.position - transform.position).normalized * speed;

        }
        
        rb.velocity = new Vector2(direction.x, direction.y);
        Destroy(gameObject,10);
    }
	
	// Update is called once per frame

}
