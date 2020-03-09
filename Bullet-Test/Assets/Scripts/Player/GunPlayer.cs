using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayer : MonoBehaviour {

    public float cooldown;
    public float damage;
    public PlayerShoot[] canyon;
 
    private void Update()
    {
        Change();

    }
    public void Change()
    {
        for (int i = 0; i < canyon.Length; i++)
        {
            canyon[i].cooldown = this.cooldown;
            canyon[i].damage = this.damage;
        }
    }

    public void ShootCanyon()
    {
        for (int i = 0; i < canyon.Length; i++)
        {
            canyon[i].ShootGUN();
        }
    }

    public bool DecreaseCooldown()
    {
        if (cooldown > 0.3f)
        {
            cooldown -= 0.1f;
            return true;
        } else
        {
            return false;
        }
    }

    public bool IncreaseDamage()
    {
        if (damage <= 2f)
        {
            damage += 0.2f;
            return true;
        } else
        {
            return false;
        }
    }
}
