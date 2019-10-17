using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health;
    public bool invulnerable = false;

    public int bombs;

    float countdown;
    // Use this for initialization

    public GameObject ObjectCollider;
    void Start () {
        ObjectCollider.SetActive(true);
        ManagerPuntps.ins.ShowVida(health);
    }
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKey(KeyCode.R))
        //{
        //    invulnerable = true;

        //}
        ManagerPuntps.ins.ShowVida(health);
        if (invulnerable == true)
        {
            countdown -= Time.deltaTime;
            ObjectCollider.SetActive(false);
            if (countdown <= 0)
            {
                ObjectCollider.SetActive(true);
                invulnerable = false;
                countdown = 2;
            }
        }
    }

    public void TakeDamage()
    {
        invulnerable = true;
        health--;

        
    }

}
