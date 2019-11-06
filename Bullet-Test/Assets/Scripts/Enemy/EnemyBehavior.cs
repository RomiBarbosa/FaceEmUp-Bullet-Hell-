using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float health;
    public float speed;
    public Animator anim;
    void Start () {
        Destroy(this.gameObject, 10);
    }

    void Update()
    {
        transform.Translate(-Vector3.up * Time.deltaTime * speed);
     
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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="PlayerBullet")
        {
           health -= collision.gameObject.GetComponent<BulletPlayer>().damage;
            Destroy(collision.gameObject);
        }
    }

}
