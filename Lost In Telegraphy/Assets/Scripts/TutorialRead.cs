using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRead : MonoBehaviour
{
    public string buttonType;
    public Transform textTransform;
    public Transform startTransform;

    private bool pressDown;
    private bool pressUp;

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
            textTransform.Translate(0, 0.1f, 0);
            startTransform.Translate(0, 0.1f, 0);
        }
        else if (pressUp == true && textTransform.position.y > 0)
        {
            textTransform.Translate(0, -0.1f, 0);
            startTransform.Translate(0, -0.1f, 0);
        }
    }
}
