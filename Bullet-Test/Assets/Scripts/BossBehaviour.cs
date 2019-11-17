using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehaviour : MonoBehaviour {

    //Boss script behavior
    //manager gun boss
    public float health = 500f;
    public BossGun bossGun;
    public BossGun bossGun2;
    public GameObject[] bullets;
    public NewBossPatternManager bpm;
    private float maxHealth;
    public float healthPercentage;
    public float timer;

    public Material[] materiales;
    Renderer rend;
    public bool hit;
    //public bool p1, p2, p3, p4, p5, p6, p7,p8;

    //all this variables are for the movent behaviour. 
    public GameObject[] waypoints;
    int current = 0;
    float rotSpeed;
    public float speed;
    float WPRadius = 1;
    public float setMovementTime;
    
    public float setWanderInterval = 0;
    public bool move = false;
    private float movementTime;

    float countdown;
    float countdown2;

    public Image healthbar;

    public Animator anim;

    public float points;

    public GameObject explotion;
    public GameObject floatingText;
    private Vector2 position;

    public GameObject bar;
    public DeployPowerUp dp;
    private void Start()
    {
        dp = GetComponent<DeployPowerUp>();
        healthPercentage = 100f;
       // health = 500f;
        movementTime = setMovementTime;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materiales[0];
        countdown = 0.3f;
        maxHealth = health;
        position = transform.position;
    }

    void Update () {
        
        if (hit == true)
        {
            countdown -= Time.deltaTime;
            rend.sharedMaterial = materiales[1];
            if (countdown <= 0)
            {
                hit = false;
                countdown = 0.3f;
            }
        }
        else
        {
            rend.sharedMaterial = materiales[0];
        }

        healthPercentage = HealthPercentage();

        healthbar.fillAmount = healthPercentage / 100;

        switch (bpm.currentPattern)
        {
            case NewBossPatternManager.ePatterns.DEFAULT:
                DefaultGun();
                break;
            case NewBossPatternManager.ePatterns.DEATH_FLOWER:
                Pattern_DeathFlower();
                break;
            case NewBossPatternManager.ePatterns.SPIT_FLOWERS:
                Pattern_SpitFlowers();
                break;
            case NewBossPatternManager.ePatterns.DO_YOU_LIKE_FLOWERS:
                Pattern_DoYouLikeFlowers();
                break;
            case NewBossPatternManager.ePatterns.THE_END:
                Pattern_TheEnd();
                break;
            case NewBossPatternManager.ePatterns.PRETTY_FLOWERS:
                Pattern_PrettyFlower();
                break;
            case NewBossPatternManager.ePatterns.THE_FLOWER:
                Pattern_THEFlower();
                break;
            case NewBossPatternManager.ePatterns.THE_OTHER_FLOWER:
                Pattern_THEOtherFlower();
                break;
            case NewBossPatternManager.ePatterns.MOVE:
                Move();
                break;
            case NewBossPatternManager.ePatterns.MOVE_WITHOUT_SHOOTING:
                MoveWithoutShooting();
                break;
            case NewBossPatternManager.ePatterns.UWU_MORE_BULLETS:
                Pattern_UwuMoreBullets();
                break;
            case NewBossPatternManager.ePatterns.UWU_SLOW_FALL:
                Pattern_UwuSlowFall();
                break;
            case NewBossPatternManager.ePatterns.UWU_FAST_AND_FURIOUS:
                Pattern_Uwu_Fast_And_Furious();
                break;
            case NewBossPatternManager.ePatterns.UWU_DOUBLE_DEATHFLOWER:
                Pattern_DoubleDeathFlower();
                break;
            case NewBossPatternManager.ePatterns.UWU_MADNESS:
                Pattern_UwuMadness();
                break;
            case NewBossPatternManager.ePatterns.DO_NOTHING:
                IdleForOneSecond();
                break;
            case NewBossPatternManager.ePatterns.MOVE_1_SECOND:
                MoveOneSecond();
                break;
            


            default:
                //DefaultGun(); lo dejo comentado pero puede que sirva
                break;
        }
        //Move();

        if (healthPercentage <= 0)
        {
            anim.SetBool("cry",true);
            Destroy(gameObject, 1.5f);
            CleanSceneWhenDefeated();
            countdown2 += Time.deltaTime;
            if (countdown2 >= 1.3f)
            {
                
                    Instantiate(explotion, transform.position, transform.rotation);
                    ShowFloatingText();
                    Destroy(bar);

                    ManagerPuntps.instance.AddScore(points);
                    GameManager.ins.LevelUp();

                    //destroy all enemybullets when boss is defeated
                    CleanSceneWhenDefeated();
                Destroy(gameObject);
                if (GameManager.ins.WINGAME != true)
                {
                    dp.InstantiatePowerUp();
                }
                


                // GameManager.ins.WinGame();
            }
        }
    }

    void MoveOneSecond()
    {
        MoveWithoutShooting();
    }
    private void IdleForOneSecond()
    {
        DefaultGun();
    }
    private void ShowFloatingText()
    {
        if (floatingText)
        {
            floatingText.GetComponent<TextMesh>().text = points.ToString();
            Instantiate(floatingText, position, Quaternion.identity);
        }
    }

    internal void TakeDamageFromBomb(float amount)
    {
        hit = true;
        this.health -= amount;
        bpm.SetPattern(NewBossPatternManager.ePatterns.BOMB_WAIT);
    }

    public void TakeDamage(float amount)
    {
        hit = true;
        this.health -= amount;
    }

    private void Move()
    {
        if (movementTime > 0)
        {
            movementTime -= Time.deltaTime;
            WaypointsMovement(true);
        }
        if (movementTime <= 0)
        {
            move = false;
            movementTime = setMovementTime;
        }
    }
    private void OnBombActivation()
    {
        DefaultGun();
    }
    private void MoveWithoutShooting()
    {
        if (movementTime > 0)
        {
            movementTime -= Time.deltaTime;
            WaypointsMovement(false);
        }
        if (movementTime <= 0)
        {
            move = false;
            movementTime = setMovementTime;
        }
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
        bossGun.ChangeBullet(bullets[1]);
        bossGun.bulletForce = 6;
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

    void Pattern_UwuMadness()
    {
        bossGun.canShoot = true;
        bossGun2.canShoot = true;
        bossGun.canRotate = true;
        bossGun2.canRotate = true;
        bossGun.cooldown = 0;
        bossGun2.cooldown = 0;
        bossGun.speedRotate = 10;
        bossGun2.speedRotate = 10;
        bossGun.ChangeBullet(bullets[0]);
        bossGun2.ChangeBullet(bullets[0]);
        bossGun.bulletForce = 3;
        bossGun2.bulletForce = 3;
    }

    void Pattern_DoubleDeathFlower()
    {
        bossGun.canShoot = true;
        bossGun2.canShoot = true;
        bossGun.canRotate = true;
        bossGun2.canRotate = true;
        bossGun.cooldown = 0;
        bossGun2.cooldown = 0;
        bossGun.speedRotate = 70;
        bossGun2.speedRotate = 70;
        bossGun.ChangeBullet(bullets[4]);
        bossGun2.ChangeBullet(bullets[4]);
        bossGun.bulletForce = 8;
        bossGun2.bulletForce = 8;
    }

    void Pattern_UwuMoreBullets()
    {
        bossGun.canShoot = true;
        bossGun2.canShoot = false;
        bossGun.canRotate = true;
        
        bossGun.cooldown = 0.1f;
        
        bossGun.speedRotate = 10;
        bossGun.speedRotate = -10;
        bossGun.ChangeBullet(bullets[2]);
        
        bossGun.bulletForce = 3;
    }

    void Pattern_Uwu_Fast_And_Furious()
    {
        bossGun.canShoot = true;
        bossGun2.canShoot = true;
        bossGun.canRotate = true;
        bossGun2.canRotate = true;
        bossGun.cooldown = 0;
        bossGun2.cooldown = 0;
        bossGun.speedRotate = -70;
        bossGun2.speedRotate = 70;
        bossGun.ChangeBullet(bullets[1]);
        bossGun2.ChangeBullet(bullets[1]);
        bossGun.bulletForce = 8;
        bossGun2.bulletForce = 8;
    }

    void Pattern_UwuSlowFall()
    {
        bossGun.canShoot = true;
        bossGun2.canShoot = true;
        bossGun.canRotate = true;
        bossGun2.canRotate = true;
        bossGun.cooldown = 0.1f;
        bossGun2.cooldown = 0.1f;
        bossGun.speedRotate = -20;
        bossGun2.speedRotate = 20;
        bossGun.ChangeBullet(bullets[4]);
        bossGun2.ChangeBullet(bullets[4]);
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

    public float HealthPercentage()
    {
        float result = this.health * 100 / maxHealth;
        return result;
    }

    public void WaypointsMovement(bool shoot)
    {
        if (Vector2.Distance(waypoints[current].transform.position, transform.position) < WPRadius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            } 
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        if (!shoot)
        {
            DefaultGun();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerHeart")
        {
            Player p = other.GetComponentInParent<Player>();
            p.TakeDamage();
        }
    }

    private void OnDestroy()
    {
        //ManagerPuntps.instance.AddScore(points);
        //GameManager.ins.LevelUp();

        ////destroy all enemybullets when boss is defeated
        //CleanSceneWhenDefeated();
    }

    private void CleanSceneWhenDefeated()
    {
        var bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (var b in bullets)
        {
            Destroy(b);
        }
    }
}
