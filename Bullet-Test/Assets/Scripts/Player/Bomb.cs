using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public int bombs;
    public bool bombAvailable;
    public float cd;

    private void Update()
    {
        ManagerPuntps.ins.ShowBombas(bombs);
            TirarBomba();
        
    }

    public void TirarBomba()
    {

        if (Input.GetButton("Button_Bomb") && bombs > 0 && bombAvailable)
        {
            bombAvailable = false;
            var enemies = GameObject.FindGameObjectsWithTag("EnemyBullet");
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }
            bombs--;
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
      
    }
}
