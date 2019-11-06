using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {

    public GameObject[] Wave;
    public float Rate;
    float next;
    public bool spawn;
    int index;
    public float posxmax, posxmin, posy;

    private void Start()
    {
        index = 0;
    }


    public void Update()
    {
        var s = Wave.Length - 1;
        if (index < s)
        {

            if (spawn == true)
            {

                if (Time.time > next)
                {
                    Spawnear(Wave[index]);
                    next = Time.time + Rate;

                }
            }
        }
        if (index >= s && index < (Wave.Length + 1))
        {
            //Spawnear(Wave[index]);
            GameObject a = Instantiate(Wave[index], Wave[index].transform.position, Wave[index].transform.rotation);
            index+=50;
            
        }
       
    }

    public void Spawnear(GameObject go)
    {
        GameObject a = Instantiate(go, PosicionRandom(), go.transform.rotation);
        index++;
    }

    Vector2 PosicionRandom()
    {
        Vector2 Posicion = new Vector2();

        Posicion = new Vector2(Random.Range(posxmin, posxmax), posy);
        return Posicion;
    }
}
