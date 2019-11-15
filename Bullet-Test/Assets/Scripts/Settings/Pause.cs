﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public bool InPause;
    public bool SlowDown;
    public float countdown;
    public float countdown2;
    public bool starttimer;
    public float cooldown = 9;
    public bool canSlowTime;

    public Image cooldownui;
    public float maxCool;
    public float Cool;
    public float porcentaje;
    bool aux;

    public Text focus;
    private void Start()
    {
        maxCool = 900;
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
            aux = true;


        }
        else if (Input.GetButtonUp("ralentizar") && SlowDown == true)
        {
            canSlowTime = false;
            BackGame();
                countdown = 0;
            starttimer = false;
            aux = false;


        }

        if (starttimer)
        {
            countdown += Time.deltaTime;
            Cool = 0;
            if (countdown >= 3)
            {
                BackGame();

                countdown = 0;

                canSlowTime = false;
                starttimer = false;
                Cool = 0;
            }
        }

        //esperar maso menos 3 segundos
        if (canSlowTime == false)
        {
            countdown2 += Time.deltaTime;
            Cool = countdown2;
            focus.color = Color.grey;
            if (countdown2 >= cooldown)
            {
                canSlowTime = true;
                countdown2 = 0;
                Cool = 1;
                focus.color = Color.white;
            }
        }
        if (canSlowTime == true && aux != true)
        {
            Cool = 1;
            porcentaje = 1;
            cooldownui.fillAmount = porcentaje;
        }
        else
        {
            porcentaje = Porcentaje();
            cooldownui.fillAmount = porcentaje;
        }
        
       

    }

    float Porcentaje()
    {
        float result = this.Cool * 100 / maxCool;
        return result;
    }

    public void SlowDownTime()
    {
        Time.timeScale = 0.5f;
        SlowDown = true;
        Cool = 0;
        porcentaje = 0;
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
