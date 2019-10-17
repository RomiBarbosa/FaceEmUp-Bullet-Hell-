using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaCirculo : MonoBehaviour {

    // Use this for initialization
    public float speed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0,0, speed * Time.deltaTime);

    }
}
