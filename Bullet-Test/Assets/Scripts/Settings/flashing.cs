using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashing : MonoBehaviour {

    public Image theImage;

	// Update is called once per frame
	void Update () {

        if (theImage !=null)
        {
            Color newcolor = new Color(Random.value,Random.value,Random.value);
            theImage.color = newcolor;

        }
	}
}
