﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRanking : MonoBehaviour
{
    public List<PlayerData> HighscorePlayers;
    public ScorePersistence datahighscore;
    public bool isnewHighscore;
    public int score;
    public LetterSelector letterselector;
    public Text[] scores;
    public Text[] names;
    public Text[] rank;

    public GameObject Selector;
    public GameObject Highscores;

    bool flag = true;
    public bool ok;
    public ChangeScene scene;

    void Start()
    {
        score = PlayerPrefs.GetInt("LastScore");
        HighscorePlayers = datahighscore.LoadHighscore();
        isnewHighscore = datahighscore.IsNewHighscore(score);
        if (isnewHighscore)
        {
            Selector.SetActive(true);
            Highscores.SetActive(false);
        }
        else
        {
            Selector.SetActive(false);
            Highscores.SetActive(true);
            ShowHighscores();
        }
        

    }

    private void Update()
    {
        if (Input.GetButton("PressStart") && letterselector.ready && flag)
        {
            SetNewHighscore();
            Selector.SetActive(false);
            ShowHighscores();
            flag = false;
            StartCoroutine(nueva());
        }
        if (!flag&&ok && Input.GetButton("PressStart"))
        {
            scene.ChangScene("GAME With lvls 1 2 3");
        }

    }

    IEnumerator nueva()
    {
        ok = false;
        yield return new WaitForSeconds(.5f);
        ok = true;
    }



    public void SetNewHighscore()
    {
        datahighscore.SaveHighscore(letterselector.GetNewHighscoreData(), score);
    }



    public void ShowHighscores()
    {

        HighscorePlayers = datahighscore.LoadHighscore();
        Highscores.SetActive(true);
        for (int i = 0; i < 5; i++)
        {
            scores[i].text = HighscorePlayers[i].score.ToString();
        }

        for (int i = 0; i < 5; i++)
        {
            names[i].text = HighscorePlayers[i].name;
        }
        if (isnewHighscore)
        {
            var index = HighscorePlayers.FindIndex((p) => p.name == letterselector.GetNewHighscoreData());

            rank[index].color = Color.yellow;
            scores[index].color = Color.yellow;
            names[index].color = Color.yellow;
        }

        //ok = true;
    }
}