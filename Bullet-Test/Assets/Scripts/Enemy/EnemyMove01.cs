using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove01 : MonoBehaviour {

    public float speed, Ymin;
    public bool Down;


    private void Update()
    {
      
        if (Down != true)
        {
            transform.Translate(-Vector3.up * Time.deltaTime * speed);
        }
        else { transform.Translate(Vector3.up * Time.deltaTime * speed * 2); }
        if (transform.position.y <= Ymin)
        {
           
            Down = true;
        }
        

    }


}
