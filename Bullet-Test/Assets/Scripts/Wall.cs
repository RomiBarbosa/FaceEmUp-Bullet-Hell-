using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

   public GameObject[] walls;
   public float time;
    public float t;
    public int index;
    public int decindex;

    public bool w1;
    public bool w2;
    public bool w3;

    private void Start()
    {
       
        decindex = walls.Length - 1;
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].SetActive(false);
        }
    }
    void Update () {

        t += Time.deltaTime;
        if (t >= time && index < walls.Length && decindex > 0)
        {
            //ShowWall();
            if (w1 == true)
            {
                ShowWall();
            }
            if (w2 == true)
            {
                DiferenteWay();
            }
            if (w3 == true)
            {
                DiferenteWay();
            }
            t = 0;
        }


    }

    void ShowWall()
    {      
            walls[index].SetActive(true);
            Debug.Log("wall" + index);
            index++;
    }

    void ShowWallDec()
    {
        walls[index].SetActive(true);
        Debug.Log("wall" + index);
        decindex--;
    }

    //espere un segundo
    //

    void DiferenteWay()
    {

        walls[index].SetActive(true);
        walls[decindex].SetActive(true);

        index++;
        decindex--;

    }
}
