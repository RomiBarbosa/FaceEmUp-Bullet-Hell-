using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMenu : MonoBehaviour
{
    public ChangeScene scene;
    public string SceneName;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
           
         scene.ChangScene(SceneName);
           
        }
    }
}
