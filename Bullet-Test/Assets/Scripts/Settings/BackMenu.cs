using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) || Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene("MenuOptions");
        }
    }
}
