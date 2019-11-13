using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerWaves : MonoBehaviour {

    public Waves[] waves;
    public int index;
    
    private void Start()
    {
        NextWave();
    }

    public void SumarINDEX()
    {
        index+=1;
    }

    public void NextWave () {

        for (int i = 0; i < waves.Length; i++)
        {
            if (i == index)
            {
                waves[i].spawn = true;
            } else { waves[i].spawn = false; }
        }
	}
}
