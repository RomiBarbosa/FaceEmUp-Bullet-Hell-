﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {

    public float time;
    

	void Start ()
    {
        Destroy(gameObject, time);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    
}
