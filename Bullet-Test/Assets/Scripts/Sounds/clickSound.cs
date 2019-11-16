using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickSound : MonoBehaviour {

    public AudioSource sound;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("PressStart"))
        {
            sound.Play();
        }
   

    }
}
