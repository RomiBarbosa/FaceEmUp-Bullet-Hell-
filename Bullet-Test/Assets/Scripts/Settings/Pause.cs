using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public bool InPause;
    public bool SlowDown;
    public float countdown;


	void Update () {

        if (Input.GetButtonDown("Pause") && InPause == false)
        {
            PauseGame();

        }
        else if (Input.GetButtonDown("Pause") && InPause == true)
        {
            BackGame();

        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && SlowDown == false && InPause == false)
        {
            SlowDownTime();
        }
        else if (/*Input.GetKeyDown(KeyCode.LeftShift) && */SlowDown == true)
        {
            countdown += Time.deltaTime;
            if (countdown >= 3)
            {
                BackGame();
               
                countdown = 0;

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
