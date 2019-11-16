using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBossPatternManager : MonoBehaviour {

    public BossBehaviour boss;
    public bool flowerPattern = true;
    public bool defaultPattern = false;

    public enum ePatterns
    {
        DEFAULT,
        DEATH_FLOWER,
        SPIT_FLOWERS,
        DO_YOU_LIKE_FLOWERS,
        THE_END,
        PRETTY_FLOWERS,
        THE_FLOWER,
        THE_OTHER_FLOWER,
        UWU_MORE_BULLETS,
        UWU_SLOW_FALL,
        UWU_FAST_AND_FURIOUS,
        UWU_DOUBLE_DEATHFLOWER,
        UWU_MADNESS,
        DO_NOTHING,
        MOVE,
        MOVE_WITHOUT_SHOOTING
    }

    public ePatterns currentPattern;

    public ePatterns[] fullPattern = new ePatterns[]
    {

    };

    private void Update () {
        KillThemAll();
        Debug.Log("Elements in the array: " + fullPattern.Length);
        Debug.Log(currentPattern.ToString());
    }

    void KillThemAll()
    { 
        NextPattern(fullPattern);
    }

    protected void SetPattern(ePatterns pattern)
    {
        currentPattern = pattern;
    }

    private float timer = 3f;
    public float patternTime = 5f;

    public int arrayIndex = 0;
    private void NextPattern(ePatterns[] pat)
    {
        SetPattern(fullPattern[arrayIndex]);
        
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            try
            {
                arrayIndex++;
                SetPattern(fullPattern[arrayIndex]);
                
            }
            catch (System.IndexOutOfRangeException)
            {
                SetPattern(fullPattern[0]);
                arrayIndex = 0;
                Debug.Log("Exception catched");
            }
            if (currentPattern == ePatterns.DO_NOTHING)
            {
                timer = 1f;
            }
            if (currentPattern == ePatterns.UWU_MORE_BULLETS)
            {
                timer = 2f;
            }
            else
            {
                timer = patternTime;
            }
        }
    }

    private void CountDown()
    {
        timer -= Time.deltaTime;
        if (timer < -0.2)
        {
            defaultPattern = false;
            SetPattern(ePatterns.DEFAULT);
            timer = 1;
        }
    }
}
