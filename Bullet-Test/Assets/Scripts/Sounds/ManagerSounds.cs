using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSounds : MonoBehaviour {

    public static ManagerSounds ins;
    public AudioSource[] sounds;

    void Awake() {
        ins = this;
    }

    public void Shoot()
    {
      sounds[0].Play();
    }

}
