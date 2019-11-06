using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove01 : MonoBehaviour {

    public float speed, Ymin, Ymax;
    float Y;
    public bool Down;


    private void Update()
    {
        //if (Down == true)
        //{
        //    transform.Translate(-Vector2.up * speed * Time.deltaTime);
        //}
        //else
        //{
        //    transform.Translate(Vector2.up * speed * Time.deltaTime);
        //    Destroy(gameObject, 10);
        //}
        //if (transform.position.y < Ymin)
        //{
        //    Down = false;
        //}
        //else if (transform.position.y > Ymin)
        //{
        //    Down = true;

        //}
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
