using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

   public GameObject rend;

	void Start () {
        rend.SetActive(false);
    }

  
    

	
	void Update () {
        if (Input.GetButton("PressStart"))
        {
            rend.SetActive(true);
        }
	}

  
}
