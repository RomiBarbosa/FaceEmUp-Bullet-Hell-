using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour {

    public float contador;
    Image imagen;

    void Start () {
        imagen = GetComponent<Image>();
        var tempColor = imagen.color;
        tempColor.a = 0f;
        imagen.color = tempColor;
    }
	
	// Update is called once per frame
	void Update () {
        contador += Time.deltaTime;
        if (contador <=1.1f)
        {
            var tempColor = imagen.color;
            tempColor.a = contador;
            imagen.color = tempColor;
        }
       

    }
}
