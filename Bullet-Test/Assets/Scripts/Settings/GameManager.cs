﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager ins; 
    public GameManager gm;

    public GameObject GameOverUI;
    public GameObject WinUI;

    public Player[] players;

    public float time;
    public Text timeUI;

    public Pause pause;

    public bool ingame;

    public ChangeScene scene;
    public string SceneName;

    public int Level;
    public Text levelUI;

    public ManagerWaves mw;

    public GameObject WinGameUI;
    private void Awake()
    {
        ins = this;
    }

    void Start () {
        GameOverUI.SetActive(false);
        time = 0;
        pause.BackGame();
        ingame = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (players[0].health <= 0)
        {
            GameOver();
        }

        time += Time.deltaTime;
        var minutes = Mathf.Floor((time % 3600) / 60).ToString("00"); /*((int)time / 60).ToString();*/
        var seconds = (time % 60).ToString("00");

        timeUI.text = minutes + ":" + seconds;

        if (Input.GetButtonDown("PressStart") && ingame == false)
        {
            scene.ChangScene(SceneName);
        }

        levelUI.text = Level.ToString() ;

    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
        pause.PauseGame();
        ingame = false;
    }

    public void WinGame()
    {
        //WinUI.SetActive(true);
        //ingame = false;
        
        Instantiate(WinGameUI, transform.position, transform.rotation);
    }

    public void LevelUp()
    {
        //WinUI.SetActive(true);
        if ((mw.index+1) != mw.waves.Length)
        {
            Instantiate(WinUI, transform.position, transform.rotation);
            mw.index++;
            mw.NextWave();
            Level += 1;
            ingame = true;
        } else { WinGame(); }
      

    }

    
}
