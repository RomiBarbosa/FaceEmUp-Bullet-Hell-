using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBulletsWithBullets : MonoBehaviour {

    public GameObject bulletToSpawn;
    public float timeToSpawn;
    public void Start()
    {
        Invoke("Death", timeToSpawn);
    }

    public void Death()
    {
        Instantiate(bulletToSpawn,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
