using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerPuntps : MonoBehaviour {

    public static ManagerPuntps ins;
    public int score;
    public int importantscore;
    public Text ui_score;
    public Text ui_importantscore;
    public Text ui_vida;
    public Text ui_bombas;
    public GameObject[] Heart;
  
    int index;
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Heart[i].SetActive(true);
            index = 3;
        }

    }

    public void ShowVida(int vidas)
    {
        Heart[index].SetActive(false);
        index--;
        ui_vida.text = vidas.ToString();
    }
    public void ShowBombas(int bombas)
    {

        ui_bombas.text = bombas.ToString();
    }
    public void Score(int score)
    {
        this.score += score;
        ui_score.text = this.score.ToString();
    }
    public void CloseScore()
    {
        this.importantscore += 10;
        ui_importantscore.text = importantscore.ToString();
        //importantscore += (importantscore * 180);
        //ui_importantscore.text = this.importantscore.ToString();
    }
    private void Awake()
    {
        ins = this;
    }

}
