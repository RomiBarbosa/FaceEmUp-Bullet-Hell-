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
    private void Start()
    {
        for (int i = 0; i < Guns.Length; i++)
        {
            Guns[i].SetActive(false);
        }
        Guns[0].SetActive(true);
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
            Guns[0].SetActive(false);
            Guns[1].SetActive(true);
        }
        else {
            Guns[1].SetActive(true);
            Guns[0].SetActive(false);
        }
       

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
