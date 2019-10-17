using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce;
    public float cooldown;
    public bool canRotate;
    public bool canShoot;
    public float speedRotate;
    float time;

    void Update()
    {
        time += Time.deltaTime;
        
            if (time > cooldown && canShoot)
            {
                ShootBullet();
                time = 0;
            }
            
        

        if (canRotate == true)
        {
            transform.Rotate(new Vector3(0, 0, speedRotate));
        }
    }

    public void ChangeBullet(GameObject bullet)
    {
        bulletPrefab = bullet;
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
