using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternManager : MonoBehaviour {

    public Boss boss;
    public bool flowerPattern = true; 
    

	void Start () {
		
	}
	

    public enum ePatterns
    {
        DEFAULT,
        DEATH_FLOWER,
        SPIT_FLOWERS,
        DO_YOU_LIKE_FLOWERS, 
        THE_END, 
        PRETTY_FLOWERS, 
        THE_FLOWER,
        THE_OTHER_FLOWER
    }

    public ePatterns patterns;

	// Update is called once per frame
	void Update () {
        if (boss.healthPercentage > 75)
        {
            patterns = ePatterns.DEATH_FLOWER;
        }
        else if (boss.healthPercentage > 50 && boss.healthPercentage < 75)
        {
            patterns = ePatterns.PRETTY_FLOWERS;
        }
        else if(boss.healthPercentage < 50)
        {
            patterns = ePatterns.THE_END;
        }
	}
}
