using System.Collections;
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
    public float c;
    public bool WINGAME;
    public bool gameOver;

    bool flag;
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
	

	void Update () {

        if (players[0].health <= 0 && flag == false)
        {
            GameOver();
            PlayerPrefs.SetInt("LastScore", (int)ManagerPuntps.instance.score);
            flag = true;
        }

        time += Time.deltaTime;
        var minutes = Mathf.Floor((time % 3600) / 60).ToString("00"); 
        var seconds = (time % 60).ToString("00");

        timeUI.text = minutes + ":" + seconds;

        //if (/*Input.touchCount> 0 && */ingame == false)
        //{
        //    scene.ChangScene(SceneName);
        //}

        if (Input.GetButtonDown("PressStart") && ingame == false)
        {
            scene.ChangScene("Highscore");
        }

        levelUI.text = Level.ToString() ;

    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
        pause.PauseGame();
        pause.HidePauseOptions();
        ingame = false;
        gameOver = true;
    }

    public void WinGame()
    {
        ingame = false;
        Instantiate(WinGameUI, transform.position, transform.rotation);
        WINGAME=true;
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

    public void TryAgain()
    {
        scene.ChangScene(SceneName);
    }
}
