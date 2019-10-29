using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerPuntps : MonoBehaviour {

  //  public static ManagerPuntps ins;

    public int score;
    public int importantscore;
    public Text ui_score;
    public Text ui_importantscore;
    public Text ui_vida;
    public Text ui_bombas;
    public GameObject[] Heart;
  
    int index;

    public Player player;

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Heart[i].SetActive(false);
            index = 3;
        }

    }

    private void Update()
    {
        ShowVida();
        ShowBombas();
        Score();
        CloseScore();
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

        ui_bombas.text = player.bombs.ToString();
    }
    public void Score()
    {
        this.score += score;
        ui_score.text = player.score0.ToString();
    }
    public void CloseScore()
    {
        this.importantscore += 10;
        ui_importantscore.text = player.score1.ToString();
        //importantscore += (importantscore * 180);
        //ui_importantscore.text = this.importantscore.ToString();
    }
    private void Awake()
    {
        //ins = this;
    }

}
