using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    Vector3 accelerationDir;
    private void Update()
    {
        accelerationDir = Input.acceleration;
        if (accelerationDir.sqrMagnitude>= 5f)
        {

        }
    }

}
