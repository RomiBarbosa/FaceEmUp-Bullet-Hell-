using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    public GameManager gm;

    public GameObject GameOverUI;

    public Player[] players;

    public float time;
    public Text timeUI;

	void Start () {
        GameOverUI.SetActive(false);
        time = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (players[0].health <= 0)
        {
            GameOver();
        }

        time += Time.deltaTime;
        var minutes = ((int)time / 60).ToString();
        var seconds = (time % 60).ToString("f0");

        timeUI.text = minutes + ":" + seconds;


	}

    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }
}
