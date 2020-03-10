using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    // Move with stick (dejar maso menos 5 segundos) 
    // Shoot with the z o button tal 
    // Drop a bomb with b 
    // Focus with the button tal manten apretado focus
    // cambie el color de las letras unas vez que lo pudo hacer o un sonido tipo campanita no se 

    public GameObject[] explanatoryTexts;
    public string[] inputs;
    public int currentIndex;
    public int indexInput;
    public bool completo;
    public float time;
    public bool endTutorial;
    public bool flag;

    private void Start()
    {
        ShowTexts();
        completo = true;
        StartCoroutine(TutorialCicle());
    }
    void Update()
    {
        if (currentIndex >= explanatoryTexts.Length - 1)
        {
            endTutorial = true;
        }
        if (Input.GetButtonDown(inputs[currentIndex]) && endTutorial)
        {
            //explanatoryTexts[currentIndex].GetComponent<Text>().color = Color.green;
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetButtonDown(inputs[currentIndex]) )
        {
            explanatoryTexts[currentIndex].GetComponent<Text>().color = Color.green;
        } 

        if (completo)
        {
            if (Input.GetButton(inputs[currentIndex]))
            {
                explanatoryTexts[currentIndex].GetComponent<Text>().color = Color.green;
                flag = true;
            }
        }
        if (flag)
        {
            time += Time.deltaTime;
            if (time > 2)
            {
                if (currentIndex < explanatoryTexts.Length)
                {
                    Next();
                    StartCoroutine(TutorialCicle());
                    time = 0;
                    flag = false;
                }
               
            }
        }

       
    }

    IEnumerator TutorialCicle()
    {
        completo = false;

        yield return new WaitForSeconds(2f);

        completo = true;
       

    }

    public void Next()
    {
        currentIndex++;
        indexInput++;
        ShowTexts();
        completo = true;
        TutorialCicle();
    }

    public void ShowTexts()
    {
        for (int i = 0; i < explanatoryTexts.Length; i++)
        {
            if (i != currentIndex)
            {
                explanatoryTexts[i].SetActive(false);
            } else
            {
                explanatoryTexts[i].SetActive(true);
            }          
        }
        

    }
}
