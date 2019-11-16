using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour {

    public float damage; 
    //public Boss boss; F, no me funciona

    private void Start()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        Debug.Log("Bala " + damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boss")
        {
            Destroy(gameObject);
            collision.GetComponent<BossBehaviour>().TakeDamage(damage);
            //boss.TakeDamage(damage); no funciona desde aca ni idea
        }
    }
    public void IncreaseDamage(float amount)
    {
        if (damage < 2)
        {
            damage += amount;
        }
        if (damage > 2)
        {
            damage = 2;
        }
    }
}
