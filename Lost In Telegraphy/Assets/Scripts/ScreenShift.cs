using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShift : MonoBehaviour
{
    public GameObject cam;
    public string direction;
    public float speed;

    private void OnMouseDown()
    {
        StartCoroutine(slider());
    }

    IEnumerator slider()
    {
        if (direction == "right")
        {
            int i;
            for (i = 0; i < 16; i++)
            {
                cam.transform.Translate(1, 0, 0);
                yield return new WaitForSeconds(speed);
            }
        }
        else if (direction == "left")
        {
            int j;
            for (j = 0; j < 16; j++)
            {
                cam.transform.Translate(-1, 0, 0);
                yield return new WaitForSeconds(speed);
            }
        }
    }
}
