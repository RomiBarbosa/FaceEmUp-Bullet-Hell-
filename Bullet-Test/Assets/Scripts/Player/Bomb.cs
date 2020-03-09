﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour {

    public int bombs;
    public bool bombAvailable;
    public float cd;
    public Camera maincamera;
    public Animator anim;
    bool bomb;
    float cont;
    public GameObject BombEffect;
    Vector3 accelerationDir;

    private void Start()
    {
        cont = 1;
    }
   
    private void Update()
    {
        accelerationDir = Input.acceleration;
        if (Input.GetButton("Button_Bomb") || accelerationDir.sqrMagnitude >= 3f)
        {
            DropBomb();
        }

        if (!bombAvailable)
        {
            cd -= Time.deltaTime;
            if (cd <= 0)
            {
                bombAvailable = true;
                cd = 2f;

            }
        }

        if (bomb == true)
        {
            cont -= Time.deltaTime;
            anim.SetBool("Bomb", true);
            if (cont <= 0)
            {
                bomb = false;
                cont = 1;
            }
        }
        else
        {
            anim.SetBool("Bomb", false);
        }
    }

    public void DropBomb()
    {
       
        if (bombs > 0 && bombAvailable && Time.timeScale != 0)
        {
            Instantiate(BombEffect,transform.position,transform.rotation);
            ManagerSounds.ins.Bomb();
            bombAvailable = false;
            var enemies = GameObject.FindGameObjectsWithTag("EnemyBullet");
            
            for (int i = 0; i < enemies.Length; i++)
            {
               
                var enemy = enemies[i].GetComponent<EnemyBehavior>();
                if (enemy != null)
                {
                    enemies[i].GetComponent<EnemyBehavior>().Die();
                } else { Destroy(enemies[i]); }
                bomb = true;
            }
            
          

            bombs--;
            var boss = GameObject.FindGameObjectWithTag("Boss");
                {
                if (boss != null)
                {
                    boss.GetComponent<BossBehaviour>().TakeDamageFromBomb(10);
                }
                    
                    bomb = true;
                }
        }
      
    }

    public bool AddBomb()
    {
        if (bombs < 4)
        {
            bombs++;
            return true;
        } else
        {
            return false;
        }
        
    }
}
