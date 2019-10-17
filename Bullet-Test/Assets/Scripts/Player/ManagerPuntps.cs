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

    public void ShowVida(int vidas)
    {

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
