using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBulletsWhenDie : MonoBehaviour {

    float health;
    public GameObject Bullets;
	void Start () {

        health= GetComponent<EnemyBehavior>().health;
	}
    public void SpawnBullets()
    {
        Instantiate(Bullets,transform.position,transform.rotation);
    }

}
