﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float speed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 1)
        {
            transform.Rotate(new Vector3(0, 0, speed));
        }
       
    }
}
