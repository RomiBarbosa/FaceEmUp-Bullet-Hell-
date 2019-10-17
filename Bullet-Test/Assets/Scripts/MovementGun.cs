using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGun : MonoBehaviour {

    public float speed;
    public float max, min,time;
    
	void Update () {

        time += Time.deltaTime;
        if (time >=4)
        {
            var s = speed * Time.deltaTime;
            transform.Rotate(0, 0, s);
            if (time >= 8)
            {
                time = 0;
            }
        }
        else if (time <= 4)
        {
            var s = -(speed* Time.deltaTime);
            transform.Rotate(0, 0, -speed);
            
        }
        

    }
}
