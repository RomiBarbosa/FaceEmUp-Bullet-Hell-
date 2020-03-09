using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health;
    public bool invulnerable = false;
    public int bombs;
    float countdown;

    public int score;
    public int graze;
    public Animator anim;
    public GameObject ObjectCollider;
    PlayerGuns guns;
    Bomb bombHandler;

    void Start () {

        ObjectCollider.SetActive(true);
        countdown = 2;
        guns = gameObject.GetComponent<PlayerGuns>();
        bombHandler = gameObject.GetComponent<Bomb>();
    }

	void Update () {

        if (invulnerable == true)
        {
            countdown -= Time.deltaTime;
            
            anim.SetBool("invulnerable",true);

            if (countdown <= 0)
            {
                ObjectCollider.SetActive(true);
                invulnerable = false;
                anim.SetBool("invulnerable", false);
                countdown = 2;
            }
        }

        bombs = bombHandler.bombs;


    }

    public void TakeDamage()
    {

        if (GameManager.ins.ingame == true)
        {
            ObjectCollider.SetActive(false);
            invulnerable = true;
            health--;
            ManagerSounds.ins.Hit();
        }
      
    }

    public void CloseScore()
    {
       graze += 10;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "DecreaseCooldown")
        {
            if (guns.CurrentGun.GetComponent<GunPlayer>().DecreaseCooldown())
            {
                Destroy(col.gameObject);
                ManagerSounds.ins.PowerUp();
                Debug.Log("cooldown ok");
            } 
           
        }

        if (col.tag == "IncreaseDamage")
        {
            if (guns.CurrentGun.GetComponent<GunPlayer>().IncreaseDamage())
            {
                Destroy(col.gameObject);
                ManagerSounds.ins.PowerUp();
                Debug.Log("damage ok");
            }

        }

        if (col.tag == "Life+")
        {
            if (health < 4)
            {
               health++;
               Destroy(col.gameObject);
               ManagerSounds.ins.PowerUp();
                Debug.Log("life ok");
            }


        }

        if (col.tag == "Bomb+")
        {
            if (bombHandler.AddBomb())
            {
                Destroy(col.gameObject);
                ManagerSounds.ins.PowerUp();
                Debug.Log("bomb ok");
            }
        }


    }
}
