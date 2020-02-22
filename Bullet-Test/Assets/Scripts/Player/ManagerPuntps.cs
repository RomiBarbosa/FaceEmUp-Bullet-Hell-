using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerPuntps : MonoBehaviour {

  //  public static ManagerPuntps ins;

    public float score;
    public float highscore;
    public int importantscore;
    public Text ui_score;
    public Text ui_importantscore;
    public Text ui_highscore;
    public Text ui_vida;
  //  public Text ui_bombas;
    public GameObject[] Heart;
    public GameObject[] Bombs;
    public static ManagerPuntps instance;
    public ScorePersistence sc;
    int index;

    public Player player;

    private void Start()
    {
        instance = this;
        for (int i = 0; i < 4; i++)
        {
            Heart[i].SetActive(false);
            index = 3;
        }

        for (int i = 0; i < 4; i++)
        {
            Bombs[i].SetActive(false);
        }
    }

    private void Update()
    {
        ShowVida();
        ShowBombas();
        Score();
        CloseScore();
        highscore = sc.getHighScore();
        ui_highscore.text = highscore.ToString();
        if (score > highscore)
        {
            PlayerPrefs.SetFloat("Highscore",score);
            highscore = score;
            ui_highscore.text = score.ToString();
        }

        for (int i = 0; i < 4; i++)
        {
            if (i < player.bombs)
            {
                Bombs[i].SetActive(true);
            } else { Bombs[i].SetActive(false); }
            
        }

        if (player.bombs <= 0 || player.GetComponent<Bomb>().bombAvailable == false)
        {
            for (int i = 0; i < 4; i++)
            {
                Bombs[i].GetComponent<Image>().color = Color.grey;
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                Bombs[i].GetComponent<Image>().color = Color.cyan;
            }

        }
    }

    public void ShowVida()
    {
        ui_vida.text = player.health.ToString();
        GraficarVida();
    }

    public void GraficarVida()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i< player.health)
            {
                Heart[i].SetActive(true);
            } else
            {
                Heart[i].SetActive(false);

            }
        }
    }
    public void ShowBombas()
    {

    }
    public void Score()
    {
        Debug.Log(score);
        // ui_score.text = player.score0.ToString();
        ui_score.text = score.ToString();
    }

    public void AddScore(float amount)
    {
        if (GameManager.ins.ingame == true)
        {
            this.score = score + amount;
        }
        
    }

    public void CloseScore()
    {
        ui_importantscore.text = player.score1.ToString();
    }
    private void Awake()
    {
        //ins = this;
    }

}
