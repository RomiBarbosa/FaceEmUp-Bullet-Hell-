using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour {

    public GameObject[] Wave;
    public float Rate;
    float next;
    public bool spawn;
    int index;

    public void Update()
    {
        if (index < Wave.Length)
        {

            if (spawn == true)
            {

                if (Time.time > next)
                {
                    Wave[index].SetActive(true);
                    index++;
                    for (int i = 0; i < Wave.Length; i++)
                    {
                        if (Wave[index] != null)
                        {
                            Wave[index].SetActive(false);

                        }
                       
                    }
                    next = Time.time + Rate;
                }
            }
        }
     

    }
}
