using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternManager : MonoBehaviour {

    public Boss boss;
    public bool flowerPattern = true; 
    

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (boss.health < 100)
        {
            flowerPattern = false;
        }
        else
        {
            flowerPattern = true;
        }
	}
}
