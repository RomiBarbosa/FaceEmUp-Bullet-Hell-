using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotanteEnemy : MonoBehaviour {

    public GameObject Target;
    public float speed ;

	void Start () {
		
	}
	
	
	void Update () {
        Rotate();

    }

    void Rotate()
    {

        transform.RotateAround(Target.transform.position,Vector3.forward, speed * Time.deltaTime);
    }
}
