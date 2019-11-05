using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalMenu : MonoBehaviour {
    public ChangeScene scene;
    public string SceneName;

	void Update () {
        if (Input.GetButtonDown("PressStart"))
        {
            scene.ChangScene(SceneName);
        }
	}
}
