using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameManager gm;

    public GameObject GameOverUI;

    public Player[] players;

	void Start () {
        GameOverUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (players[0].health <= 0)
        {
            GameOver();
        }

	}

    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }
}
