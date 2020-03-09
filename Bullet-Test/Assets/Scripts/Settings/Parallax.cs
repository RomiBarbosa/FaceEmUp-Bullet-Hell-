using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;
    public float bound, start;
 
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
                transform.position = new Vector3(0, start, transform.position.z);
            }
        }
       

    }
}
