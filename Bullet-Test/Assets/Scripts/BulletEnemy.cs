using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {

	
	void Start ()
    {
        Destroy(gameObject,3);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }
}
