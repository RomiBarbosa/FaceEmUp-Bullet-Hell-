using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce;
    public float coolDown;
    float time;
	void Update () {

        //if (Input.GetButtonDown("Fire1"))
        //{

        time += Time.deltaTime;
        if (time >=coolDown)
        {
            ShootBullet();
            time = 0;
        }
            
        //}

	}

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
