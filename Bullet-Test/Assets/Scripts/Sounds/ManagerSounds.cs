using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSounds : MonoBehaviour {

    public static ManagerSounds ins;
    public AudioSource[] sounds;
    public AudioSource[] music;

    private void Start()
    {
        PlayMusic();
    }
    void Awake() {
        ins = this;
    }

    public void Shoot()
    {
      sounds[0].Play();
    }

    public void PlayMusic()
    {
        music[0].Play();
    }
}
