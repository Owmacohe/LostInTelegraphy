﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRead : MonoBehaviour
{
    public string buttonType;
    public Transform textTransform;

    private bool pressDown = false;
    private bool pressUp = false;

    private void OnMouseDown()
    {
        if (buttonType == "down")
        {
            pressDown = true;
        }
        else if (buttonType == "up")
        {
            pressUp = true;
        }

    }

    private void OnMouseUp()
    {
        pressDown = false;
        pressUp = false;
    }

    private void Update()
    {
        if (pressDown == true && textTransform.position.y < 8.5)
        {
            textTransform.Translate(0, 0.05f, 0);
        }
        else if (pressUp == true && textTransform.position.y > 0)
        {
            textTransform.Translate(0, -0.05f, 0);
        }
    }
}
