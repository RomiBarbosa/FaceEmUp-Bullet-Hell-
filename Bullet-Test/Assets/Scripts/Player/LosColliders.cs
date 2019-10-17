using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosColliders : MonoBehaviour {

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag== "PlayerHeart")
        {
            Debug.Log(" -----");
            Player p = other.GetComponentInParent<Player>();
            p.TakeDamage();
        }

        if (other.tag == "PlayerHeartClose")
        {
            Debug.Log("paso cerca");
            ManagerPuntps.ins.CloseScore();
        }
    }
}
