using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public bool InPause;
    public bool SlowDown;
    public float countdown;
    public bool starttimer;



	void Update () {

        if (Input.GetButtonDown("Pause") && InPause == false )
        {
            PauseGame();

        }
        else if (Input.GetButtonDown("Pause") && InPause == true)
        {
            BackGame();

        }
       
        if (Input.GetButtonDown("ralentizar") && SlowDown == false && InPause == false)
        {
            SlowDownTime();
            starttimer = true;
            
        }
        else if (Input.GetButtonUp("ralentizar") && SlowDown == true)
        {
                BackGame();
                countdown = 0;
            starttimer = false;



        }

        if (starttimer)
        {
            countdown += Time.deltaTime;
            if (countdown >= 3)
            {
                BackGame();

                countdown = 0;

                starttimer = false;

            }
        }  

            
    }

    public void SlowDownTime()
    {
        Time.timeScale = 0.5f;
        SlowDown = true;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        InPause = true;
    }

    public void BackGame()
    {
        Time.timeScale = 1;
        InPause = false;
        SlowDown = false;
    }
}
