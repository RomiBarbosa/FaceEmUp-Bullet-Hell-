using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeployPowerUp : MonoBehaviour {


    private System.Random rnd = new System.Random();
    private System.Random rndIndex = new System.Random();

    private int powerUpChance = 10;
    public GameObject[] powerups;

    

    private void InstantiatePowerUp()
    {
        Vector2 position = transform.position;
        var chance = rnd.Next(0, 101);
        if (chance < powerUpChance)
        {
            var i = rndIndex.Next(1, 5);
            Instantiate(powerups[i - 1], position, Quaternion.identity);
        }
    }

    private void OnDestroy()
    {
        InstantiatePowerUp();
    }

}
