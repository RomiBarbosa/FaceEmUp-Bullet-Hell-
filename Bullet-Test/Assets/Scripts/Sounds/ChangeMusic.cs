using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour {

    public string musica;
	void Start () {

        ManagerSounds.ins.MusicManager(musica);
	}
	
	
}
