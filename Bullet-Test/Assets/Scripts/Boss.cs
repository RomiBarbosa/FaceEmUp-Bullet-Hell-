﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    //manager gun boss
    public float health = 100;
    public BossGun bossGun;
    public BossGun bossGun2;
    public GameObject[] bullets;

    public float timer;

    public bool p1, p2, p3, p4, p5, p6, p7,p8;



    private void Start()
    {
        //Pattern_SpitFlowers();
    }

    void Update () {

        //timer += Time.deltaTime;

        //if (timer < 1)
        //{
        //    Pattern_SpitFlowers();

        //} else if(timer > 1 && timer < 2)
        //{
        //    DefaultGun();
        //}
        //else if (timer >= 3 && timer < 4)
        //{
        //    Pattern_DeathFlower();
        //}
        //else if (timer >= 5 && timer < 6)
        //{
        //    DefaultGun();

        //}
        //else if (timer >= 6)
        //{

        //    timer = 0;
        //}
        if (p1){ DefaultGun(); } 
        if (p2){ Pattern_DeathFlower(); }
        if (p3){ Pattern_SpitFlowers(); } 
        if (p4){ Pattern_DoYouLikeFlowers(); } 
        if (p5){ Pattern_TheEnd(); }
        if (p6){ Pattern_PrettyFlower(); } 
        if (p7){ Pattern_THEFlower(); }
        if (p8){ Pattern_THEOtherFlower(); }
        
    }

    void DefaultGun()
    {
        bossGun2.canShoot = false;
        bossGun.canShoot = false;
        bossGun.canRotate = false;
    }


    void Pattern_DeathFlower()
    {
        bossGun2.canShoot = false;
        bossGun.canShoot = true;
        bossGun.canRotate = true;
        bossGun.cooldown = 0;
        bossGun.speedRotate = 50;
        bossGun.ChangeBullet(bullets[0]);
    }

    void Pattern_SpitFlowers()
    {
        bossGun2.canShoot = false;
        bossGun.canShoot = true;
        bossGun.canRotate = true;
        bossGun.cooldown = 0;
        bossGun.speedRotate = 50;
        bossGun.ChangeBullet(bullets[1]);

    }

    void Pattern_DoYouLikeFlowers()
    {
        bossGun2.canShoot = false;
        bossGun.canShoot = true;
        bossGun.canRotate = true;
        bossGun.cooldown = 0;
        bossGun.speedRotate = 100;
        bossGun.ChangeBullet(bullets[1]);
        bossGun.bulletForce = 4;

    }
    void Pattern_TheEnd()
    {
        bossGun2.canShoot = false;
        bossGun.canShoot = true;
        bossGun.canRotate = true;
        bossGun.cooldown = 0;
        bossGun.speedRotate = 100;
        bossGun.ChangeBullet(bullets[3]);
        bossGun.bulletForce = 4;

    }

    void Pattern_PrettyFlower()
    {
        bossGun2.canShoot = false;
        bossGun.canShoot = true;
        bossGun.canRotate = true;
        bossGun.cooldown = 0;
        bossGun.speedRotate = 70;
        bossGun.ChangeBullet(bullets[2]);
        bossGun.bulletForce = 4;
    }

    void Pattern_THEFlower()
    {
        bossGun.canShoot = true;
        bossGun2.canShoot = true;
        bossGun.canRotate = true;
        bossGun2.canRotate = true;
        bossGun.cooldown = 0;
        bossGun2.cooldown = 0;
        bossGun.speedRotate = 70;
        bossGun.speedRotate = -70;
        bossGun.ChangeBullet(bullets[0]);
        bossGun2.ChangeBullet(bullets[0]);
        bossGun.bulletForce = 4;
        bossGun2.bulletForce = 4;
    }

    void Pattern_THEOtherFlower()
    {
        bossGun.canShoot = true;
        bossGun2.canShoot = true;
        bossGun.canRotate = true;
        bossGun2.canRotate = true;
        bossGun.cooldown = 0;
        bossGun2.cooldown = 0;
        bossGun.speedRotate = 50;
        bossGun.speedRotate = -50;
        bossGun.ChangeBullet(bullets[0]);
        bossGun2.ChangeBullet(bullets[0]);
        bossGun.bulletForce = 4;
        bossGun2.bulletForce = 7;
    }
}
