using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeployPowerUp : MonoBehaviour {


    private System.Random rnd = new System.Random();
    private System.Random rndIndex = new System.Random();

    private int powerUpChance = 5;
    public GameObject[] powerups;

    

    public void InstantiatePowerUp()
    {
        Vector2 position = transform.position;
        if (powerups.Length == 1)
        {
            Instantiate(powerups[0], position, Quaternion.identity);
        }
        else
        {
            var chance = rnd.Next(0, 101);
            if (chance < powerUpChance)
            {
                var i = rnd.Next(1, 5);
                Debug.Log("Power up: " + i);
                Instantiate(powerups[i - 1], position, Quaternion.identity);
            }
        }
    }

    //private void OnDestroy()
    //{
    //    InstantiatePowerUp();
    //}

}
