using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInteraction : MonoBehaviour
{
    private bool blockSelected = false;

    private float outLength;

    private void Start()
    {
        StartCoroutine(blockSlide());

        outLength = Random.Range(-3.5f, 1.5f);
    }

    private void OnMouseDown()
    {
        if (blockSelected == false)
        {
            blockSelected = true;
        }
        else
        {
            blockSelected = false;
        }
    }

    private void Update()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mouse);

        if (blockSelected == true)
        {
            this.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
        }
        else
        {
            return;
        }
    }

    IEnumerator blockSlide()
    {
        float i;
        for (i = this.transform.position.y; i < outLength; i = (i + 0.03f))
        {
            this.transform.position = new Vector3(this.transform.position.x, i, this.transform.position.z);
            yield return new WaitForSeconds(0);
        }

        this.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }

    /*
    public static void paperParent()
    {
        
    }
    */
}
