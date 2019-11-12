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
    public float timeToSelfDestruct;
    void Start () {
        Destroy(this.gameObject, timeToSelfDestruct);
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materiales[0];
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("death", false);
    }

    void Update()
    {
        if (hit == true)
        {
            countdown -= Time.deltaTime;
            rend.sharedMaterial = materiales[1];
            anim.SetBool("death", true);
            if (countdown <= 0)
            {
                hit = false;
                countdown = 0.3f;
                anim.SetBool("death", false);
            }

        }
        else
        {
            rend.sharedMaterial = materiales[0];
        }



        if (health <= 0)
        {
            anim.SetBool("death",true);
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
        FloatingText.GetComponent<TextMesh>().text = points.ToString();
        Instantiate(FloatingText, transform.position, Quaternion.identity);
        
    }

    public void Die()
    {
        Destroy(this.gameObject);
        Instantiate(explotion, transform.position, transform.rotation);
        ShowFloatingText();
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
