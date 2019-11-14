using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public float speed;
	void Update () {
        if (transform.position.y > -15)
        {
            transform.Translate(-Vector3.up * (Time.deltaTime * speed));
        } else
        {
            transform.position = new Vector3(transform.position.x, 30, transform.position.z);
        }
        
	}
}
