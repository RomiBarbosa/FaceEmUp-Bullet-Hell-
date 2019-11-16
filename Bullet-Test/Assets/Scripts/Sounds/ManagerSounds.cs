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

    public void Bomb()
    {
        sounds[1].Play();
    }
    public void StartGame()
    {
        sounds[2].Play();
    }

    public void Pause()
    {
        sounds[3].Play();
    }
    public void PowerUp()
    {
        sounds[4].Play();
    }
    public void Hit()
    {
        sounds[5].Play();
    }

    public void MusicManager(string musicstring)
    {
        switch(musicstring)
        {
            case "boss":
                music[1].Play();
                music[0].Stop();
                break;

            case "level":
                music[0].Play();
                music[1].Stop();
                break;

        }
    }
}
