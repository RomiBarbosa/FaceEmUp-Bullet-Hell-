using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    public float contador;
    Image imagen;

    void Start()
    {
        imagen = GetComponent<Image>();
        var tempColor = imagen.color;
        tempColor.a = 1f;
        imagen.color = tempColor;
    }

    // Update is called once per frame
    void Update()
    {
        contador -= Time.deltaTime;
        if (contador >= 0f)
        {
            var tempColor = imagen.color;
            tempColor.a = contador;
            imagen.color = tempColor;
        }


    }
}
