using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : MonoBehaviour {

    public GameObject[] Guns;
    public int ind;
    public bool focus;
    public GameObject bullet;
    public GameObject gunManager;
    public GameObject CurrentGun;
    public bool shoot;

    private void Start()
    {
        for (int i = 0; i < Guns.Length; i++)
        {
            Guns[i].SetActive(false);
        }
        Guns[0].SetActive(true);
        CurrentGun = Guns[0];
        ind = 0;

    }
    private void Update()
    {
      
        if (Input.GetButton("ralentizar"))
        {
            Guns[1].SetActive(false);
            Guns[0].SetActive(true);

            CurrentGun = Guns[0];
        }
        else {
            Guns[1].SetActive(true);
            Guns[0].SetActive(false);
            
            CurrentGun = Guns[1];
        }

        if (Input.GetButtonDown("Fire1"))
        {
            KeepShoot();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            StopShoot();
        }

        if (shoot ==true)
        {
            Shoot();
        }

    }

    public void KeepShoot()
    {
        shoot = true;
    }
    public void StopShoot()
    {
        shoot = false;
    }

    public void Shoot()
    {
        CurrentGun.GetComponent<GunPlayer>().ShootCanyon();
    }

   void ChangeGun()
    {
        Guns[ind].SetActive(false);
        Guns[NewIndex()].SetActive(true);
    }


    int NewIndex()
    {
        if (ind < 1)
        {
            ind++;
        } else 
        {
            ind = 0;
        }

        return ind;
    }



}
