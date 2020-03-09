using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperInteraction : MonoBehaviour
{
    private bool paperSelected = false;

    private void OnMouseDown()
    {
        this.GetComponent<SpriteRenderer>().sortingOrder = 3;

        //This loop is supposed to rotate the paper slowly when first clicked, but they don't. Yet.
        float i;
        for (i = this.transform.rotation.eulerAngles.z; i > 0; i--)
        {
            this.transform.transform.rotation = new Quaternion(0, 0, i, 0);
            StartCoroutine(wait(0.5f));
        }

        if (this.transform.rotation.eulerAngles.z == 180)
        {
            if (paperSelected == false)
            {
                paperSelected = true;
            }
            else
            {
                paperSelected = false;
            }
        }
    }

    IEnumerator wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    private void Update()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mouse);

        if (paperSelected == true)
        {
            this.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
        }
        else
        {
            return;
        }
    }
}
