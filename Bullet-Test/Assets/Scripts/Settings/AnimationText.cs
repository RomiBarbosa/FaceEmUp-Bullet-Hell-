using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationText : MonoBehaviour {

    public GameObject PressStart;
    public float c;

    private void Start()
    {
        PressStart.SetActive(false);
    }
    private void Update()
    {
        c += Time.deltaTime;

        if (c >= 0.3f)
        {
            PressStart.SetActive(false);
            if (c >= 0.8f)
            {
                PressStart.SetActive(true);
                c = 0;
            }

        }
        else { PressStart.SetActive(true); }
    }
}
