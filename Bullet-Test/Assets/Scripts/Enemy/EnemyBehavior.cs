using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float health;
    public Animator anim;
    public float points;
    void Start () {
        Destroy(this.gameObject, 10);
    }

    void Update()
    {
        
        
     
        if (health <= 0)
        {
            
            if (GetComponent<SpawnBulletsWhenDie>() != null)
            {
                GetComponent<SpawnBulletsWhenDie>().SpawnBullets();
                Destroy(this.gameObject);
                
            } else
            {
                Destroy(this.gameObject); 
            }
            ManagerPuntps.instance.AddScore(points);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag =="PlayerBullet")
        {
           health -= collider.gameObject.GetComponent<BulletPlayer>().damage;
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
