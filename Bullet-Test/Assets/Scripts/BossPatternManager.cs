using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternManager : MonoBehaviour {

    public Boss boss;
    public bool flowerPattern = true; 
    public bool defaultPattern = false; 

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

    public virtual ePatterns State()
    {
        return ePatterns.DO_YOU_LIKE_FLOWERS;
    }

    void Update () {
        if (defaultPattern == true)
        {
            SetPattern(State());
            CountDown();
        }
	}

    

    protected void SetPattern(ePatterns pattern)
    {
        patterns = pattern;
    }

    public float timer = 1f;
    public void WaitToFire()
    {
        defaultPattern = true;
    }

    private void CountDown()
    {
        timer -= Time.deltaTime;
        if (timer < -0.2)
        {
            defaultPattern = false;
            timer = 1;
        }
    }
}
