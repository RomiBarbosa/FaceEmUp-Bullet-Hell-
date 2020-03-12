using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button[] Buttons;
    public int index;
    public float vertical;

    private void Start()
    {
        ClickButton();
    }
    private void Update()
    {
        vertical = Input.GetAxisRaw("Horizontal");
        if (vertical == 1)
        {
            ClickButton();
        }
        if (index >= Buttons.Length - 1)
        {
            index = 0;
        }
    }

    public void ClickButton()
    {
        Buttons[index].Select();
        index++;
    }
}
