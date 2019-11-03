using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public GameObject PressStart;
   public float c;

	// Update is called once per frame
	public void ChangScene (string scene) {
        Debug.Log("Change");
       // SceneManager.LoadScene(scene);
	}
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
