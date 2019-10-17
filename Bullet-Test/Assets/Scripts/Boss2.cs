using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour {

    //manager gun boss
    public float health = 100;
    public BossGun bossGun;
    public GameObject[] bullets;

    public float timer;

    public bool p1, p2, p3, p4, p5, p6, p7;



    private void Start()
    {
        //Pattern_SpitFlowers();
    }

    void Update()
    {
        
        if (p1) { DefaultGun(); }
        if (p2) { Pattern_DeathFlower(); }
        if (p3) { Pattern_SpitFlowers(); }
        if (p4) { Pattern_DoYouLikeFlowers(); }
        if (p5) { Pattern_TheEnd(); }
        if (p6) { Pattern_PrettyFlower(); }
        if (p7) { DefaultGun(); }

    }

    void DefaultGun()
    {
        bossGun.canShoot = false;
        bossGun.canRotate = false;
    }


    void Pattern_DeathFlower()
    {
        bossGun.canShoot = true;
        bossGun.canRotate = true;
        bossGun.cooldown = 0;
        bossGun.bulletForce = 4;
        bossGun.speedRotate = 70;
        bossGun.ChangeBullet(bullets[0]);
    }

    void Pattern_SpitFlowers()
    {
        bossGun.canShoot = true;
        bossGun.canRotate = true;
        bossGun.cooldown = 0;
        bossGun.speedRotate = 50;
        bossGun.ChangeBullet(bullets[1]);

    }

    void Pattern_DoYouLikeFlowers()
    {
        bossGun.canShoot = true;
        bossGun.canRotate = true;
        bossGun.cooldown = 0;
        bossGun.speedRotate = 100;
        bossGun.ChangeBullet(bullets[1]);
        bossGun.bulletForce = 4;

    }
    void Pattern_TheEnd()
    {
        bossGun.canShoot = true;
        bossGun.canRotate = true;
        bossGun.cooldown = 0;
        bossGun.speedRotate = 100;
        bossGun.ChangeBullet(bullets[3]);
        bossGun.bulletForce = 4;

    }

    void Pattern_PrettyFlower()
    {
        bossGun.canShoot = true;
        bossGun.canRotate = true;
        bossGun.cooldown = 0;
        bossGun.speedRotate = 70;
        bossGun.ChangeBullet(bullets[2]);
        bossGun.bulletForce = 4;
    }

}
