using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSin : MonoBehaviour {

    Vector3 pos;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void MoveSinL()
    {
        pos -= transform.right * Time.deltaTime * speed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * 5f) * 0.5f;

    }
}
