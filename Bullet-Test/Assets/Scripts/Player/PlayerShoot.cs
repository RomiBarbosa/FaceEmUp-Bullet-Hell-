using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce;
    public float cooldown;
    public float damage;
    float time;
    void Update()
    {
        time += Time.deltaTime;
        //if (time >= cooldown)
        //{
        //    ShootBullet();
        //    time = 0;
        //}

        if (Input.GetButton/*Down*/("Fire1") && time >= cooldown)
        {
            ShootBullet();
            time = 0;
            ManagerSounds.ins.Shoot();
        }

    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
       // bullet.GetComponent<BulletPlayer>().damage = this.damage;

    }
}
