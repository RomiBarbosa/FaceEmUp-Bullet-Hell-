using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMove : MonoBehaviour {

    public float speed;
    private void Update()
    {
         transform.Translate(-Vector3.up * Time.deltaTime * speed);
    }
}
