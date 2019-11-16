using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderISP : MonoBehaviour {

    
    CircleCollider2D coll2d;
    public float speed;
	void Start () {

       coll2d = gameObject.GetComponent<CircleCollider2D>();
	}
	
	void Update () {

        
        if (transform.localScale.x <= 30)
        {
            var x = transform.localScale.x;
            x += Time.deltaTime * speed;

            var y = transform.localScale.y;
            y += Time.deltaTime * speed;


            transform.localScale = new Vector2(x, y);
           // radio = coll2d.radius += Time.deltaTime;

        //se escala solo el radio thanks unity
        }
      
	}
}
