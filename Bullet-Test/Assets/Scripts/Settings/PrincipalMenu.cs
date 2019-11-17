using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalMenu : MonoBehaviour {
    public ChangeScene scene;
    public string SceneName;
    public bool w;
    public float c;
	void Update () {
        if (Input.GetButtonDown("PressStart"))
        {
            w = true;
           
        }

        if (w == true)
        {
            c += Time.deltaTime;
            if (c >= 1)
            {
                scene.ChangScene(SceneName);
            }
           
        }
	}
}
