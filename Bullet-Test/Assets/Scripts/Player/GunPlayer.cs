using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayer : MonoBehaviour {

    public float cooldown;
    public float damage;
    public PlayerShoot[] canyon;
    
    private void Start()
    {
        
        
    }

    public void Change()
    {
        for (int i = 0; i < canyon.Length; i++)
        {
            canyon[i].cooldown = this.cooldown;
            canyon[i].damage = this.damage;
        }
    }
}
