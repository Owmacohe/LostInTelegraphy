using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperInteraction : MonoBehaviour
{
    public static bool acknowledged = false;

    private bool paperSelected = false;

    private void OnMouseDown()
    {
        this.GetComponent<SpriteRenderer>().sortingOrder = 4;
        acknowledged = true;

        if (this.transform.rotation.eulerAngles.z != 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (paperSelected == false)
        {
            paperSelected = true;
        }
        else
        {
            paperSelected = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PaperSlot"))
        {
            MessageCirculation.tabSet("send", "down");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PaperSlot"))
        {
            MessageCirculation.tabSet("send", "up");
        }
    }
}
