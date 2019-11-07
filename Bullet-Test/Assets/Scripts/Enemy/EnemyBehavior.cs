using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float health;
    public Animator anim;
    public float points;
    public Material[] materiales;
    Renderer rend;
    public bool hit;
    float countdown;
    public GameObject explotion;
    public GameObject FloatingText;

    void Start () {
        Destroy(this.gameObject, 10);
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materiales[0];
    }

    void Update()
    {
        if (hit == true)
        {
            countdown -= Time.deltaTime;
            rend.sharedMaterial = materiales[1];
            if (countdown <= 0)
            {
                hit = false;
                countdown = 0.3f;
            }

        }
        else
        {
            rend.sharedMaterial = materiales[0];
        }



        if (health <= 0)
        {
            
            if (GetComponent<SpawnBulletsWhenDie>() != null)
            {
               
                GetComponent<SpawnBulletsWhenDie>().SpawnBullets();
                Destroy(this.gameObject);
                Instantiate(explotion, transform.position, transform.rotation);
                if (FloatingText)
                {
                    ShowFloatingText();
                }

            } else
            {
                Destroy(this.gameObject);
                Instantiate(explotion, transform.position, transform.rotation);
                if (FloatingText)
                {
                    ShowFloatingText();
                }
            }
            ManagerPuntps.instance.AddScore(points);
        }
    }

    private void ShowFloatingText()
    {
        Instantiate(FloatingText, transform.position, Quaternion.identity);
    }

    public void Die()
    {
        Destroy(this.gameObject);
        Instantiate(explotion, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag =="PlayerBullet")
        {
           health -= collider.gameObject.GetComponent<BulletPlayer>().damage;
            hit = true;
           Destroy(collider.gameObject);
        }

        if (collider.tag == "PlayerHeart")
        {
            Player p = collider.GetComponentInParent<Player>();
            p.TakeDamage();
        }

        //if (this.health <= 0)
        //{
        //    ManagerPuntps.instance.score += 10;
        //}
    }

}
