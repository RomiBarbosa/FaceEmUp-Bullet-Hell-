using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public bool InPause;
	
	void Update () {

        if (Input.GetButtonDown("Pause") && InPause == false)
        {
            PauseGame();

        }
        else if (Input.GetButtonDown("Pause") && InPause == true)
        {
            BackGame();

        }
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
    }
}
