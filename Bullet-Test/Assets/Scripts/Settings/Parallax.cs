using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
  // Rigidbody2D rb;
    public float speed;
    public float bound, start;
    void Start()
    {
    //    rb = GetComponent<Rigidbody2D>();
     //   rb.velocity = new Vector2(0,speed);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.ins.ingame&& GameManager.ins.pause.InPause ==false )
        {
            if (transform.position.y > bound)
            {
                transform.Translate(-Vector3.up * speed);
            }
            else
            {
                transform.position = new Vector3(-0.17f, start, 0);
            }
        }
       

    }
}
