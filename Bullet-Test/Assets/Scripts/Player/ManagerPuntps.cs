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
    public Text ui_bombas;
    public GameObject[] Heart;
    public static ManagerPuntps instance;
  
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

     highscore = PlayerPrefs.GetFloat("Highscore");
    }

    private void Update()
    {
        ShowVida();
        ShowBombas();
        Score();
        CloseScore();

        ui_highscore.text = highscore.ToString();
        if (score > highscore)
        {
            PlayerPrefs.SetFloat("Highscore",score);
            ui_highscore.text = score.ToString();
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
        ui_bombas.text = "x"+ player.bombs.ToString();
    }
    public void Score()
    {
        Debug.Log(score);
        // ui_score.text = player.score0.ToString();
        ui_score.text = score.ToString();
    }

    public void AddScore(float amount)
    {
        this.score = score + amount;
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
