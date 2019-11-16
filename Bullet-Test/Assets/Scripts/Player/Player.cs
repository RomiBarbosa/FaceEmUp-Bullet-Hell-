using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health;
    public bool invulnerable = false;

    public int bombs;

    float countdown;

    public int score0;
    public int score1;
    // Use this for initialization
   public Animator anim;
    public GameObject ObjectCollider;


    void Start () {
        ObjectCollider.SetActive(true);
        countdown = 2;
   // ManagerPuntps.ins.ShowVida(health);
    }
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKey(KeyCode.R))
        //{
        //    invulnerable = true;

        //}
        if (invulnerable == true)
        {
            countdown -= Time.deltaTime;
            
            anim.SetBool("invulnerable",true);
            //animacion y a la vez desactivas tu corazon
            if (countdown <= 0)
            {
                ObjectCollider.SetActive(true);
                invulnerable = false;
                anim.SetBool("invulnerable", false);
                countdown = 2;
            }
        }

        bombs = gameObject.GetComponent<Bomb>().bombs;
        
    }

    public void TakeDamage()
    {
        //  ManagerPuntps.ins.ShowVida(health);
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
       score1 += 10;
       // ManagerPuntps.ins.CloseScore();
    }
}
