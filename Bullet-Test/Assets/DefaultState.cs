using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : BossPatternManager {


    public override ePatterns State()
    {
        return ePatterns.DEFAULT;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
