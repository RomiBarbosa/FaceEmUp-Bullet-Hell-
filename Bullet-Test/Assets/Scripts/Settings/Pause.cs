using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public bool InPause;
    public bool SlowDown;
    public float countdown;
    public float countdown2;
    public bool starttimer;
    public float cooldown = 3;
    public bool canSlowTime;
    private void Start()
    {
        canSlowTime = true;
    }
    void Update () {

        if (Input.GetButtonDown("Pause") && InPause == false )
        {
            PauseGame();

        }
        else if (Input.GetButtonDown("Pause") && InPause == true)
        {
            BackGame();

        }

        if (Input.GetButtonDown("ralentizar") && SlowDown == false && InPause == false && canSlowTime == true)
        {
            SlowDownTime();
            starttimer = true;
           // canSlowTime = false;


        }
        else if (Input.GetButtonUp("ralentizar") && SlowDown == true)
        {
            canSlowTime = false;
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

                canSlowTime = false;
                starttimer = false;

            }
        }

        //esperar maso menos 3 segundos
        if (canSlowTime == false)
        {
            countdown2 += Time.deltaTime;

            if (countdown2 >= cooldown)
            {
                canSlowTime = true;
                countdown2 = 0;
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
