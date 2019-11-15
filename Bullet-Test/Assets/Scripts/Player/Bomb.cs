using System.Collections;
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
    public Text BombBar;
    public Text BombBar2;
    private void Start()
    {
        cont = 1;

    }
    private void Update()
    {
       // ManagerPuntps.ins.ShowBombas(bombs);
            TirarBomba();

        if (bomb == true)
        {
            cont -= Time.deltaTime;
            anim.SetBool("Bomb", true);
            //BombBar.color = Color.grey;
            //BombBar2.color = Color.grey;
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

        if (bombs <= 0 || bombAvailable == false)
        {
            BombBar.color = Color.grey;
            BombBar2.color = Color.grey;
        } else 
        {
            BombBar.color = Color.white;
            BombBar2.color = Color.white;
        }
       
    }

    public void TirarBomba()
    {
       
        if (Input.GetButton("Button_Bomb") && bombs > 0 && bombAvailable && Time.timeScale != 0)
        {
            //BombBar.color = Color.grey;
            //BombBar2.color = Color.grey;
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

        if (!bombAvailable)
        {
            cd -= Time.deltaTime;
            if (cd <= 0)
            {
                bombAvailable = true;
                cd = 2f;
                //BombBar.color = Color.white;
                //BombBar2.color = Color.white;
            }
        }
      
    }
}
