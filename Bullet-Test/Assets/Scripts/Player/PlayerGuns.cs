using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : MonoBehaviour {

    public GameObject[] Guns;
   // public GameObject currentGun;
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
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    ChangeGun();
        //}
        if (Input.GetButton("ralentizar"/*KeyCode.Z*/))
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
        Guns[newIndex()].SetActive(true);
    }


    int newIndex()
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


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "DecreaseCooldown")
        {

            ManagerSounds.ins.PowerUp();
            if (gunManager.GetComponent<GunPlayer>().cooldown > 0.3f)
            {
                gunManager.GetComponent<GunPlayer>().cooldown -= 0.1f;
            }
            
            //Guns[ind].GetComponent<GunPlayer>().Change();
            Destroy(col.gameObject);
        }

        if (col.tag == "IncreaseDamage")
        {
            if (gunManager.GetComponent<GunPlayer>().damage <= 2f)
            {
                gunManager.GetComponent<GunPlayer>().Change();
                gunManager.GetComponent<GunPlayer>().damage += 0.2f;
                Destroy(col.gameObject);
                ManagerSounds.ins.PowerUp();
            }
           
        }
        if (col.tag == "Life+")
        {
            if (gameObject.GetComponent<Player>().health <4)
            {
                gameObject.GetComponent<Player>().health++;
                Destroy(col.gameObject);
                ManagerSounds.ins.PowerUp();
            }
            

        }
        if (col.tag == "Bomb+")
        {
            if (gameObject.GetComponent<Bomb>().bombs < 4)
            {
                gameObject.GetComponent<Bomb>().bombs++;
                Destroy(col.gameObject);
                ManagerSounds.ins.PowerUp();
            }
          
        }

       
    }
}
