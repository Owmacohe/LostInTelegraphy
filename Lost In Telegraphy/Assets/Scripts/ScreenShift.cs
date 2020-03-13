using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShift : MonoBehaviour
{
    public GameObject cam;
    public string direction;
    public float speed;

    public Sprite flippedPaper;

    private void OnMouseDown()
    {
        StartCoroutine(slider());

        if (MessageCirculation.sentTab.transform.position.y < 5.6)
        {
            MessageCirculation.tabSet("sent", "up");
        }
    }

    IEnumerator slider()
    {
        if (direction == "right")
        {
            if (MessageCirculation.instPaperOut != null)
            {
                MessageCirculation.instPaperOut.GetComponent<SpriteRenderer>().sprite = flippedPaper;
            }

            int i;
            for (i = 0; i < 16; i++)
            {
                if (MessageCirculation.instPaperOut != null)
                {
                    MessageCirculation.instPaperOut.transform.Translate(1, 0, 0);
                }

                cam.transform.Translate(1, 0, 0);
                yield return new WaitForSeconds(speed);
            }
        }
        else if (direction == "left")
        {
            if (MessageCirculation.instPaperOut != null)
            {
                MessageCirculation.instPaperOut.GetComponent<SpriteRenderer>().sprite = MessageCirculation.instPaperOutSprite;
            }

            int j;
            for (j = 0; j < 16; j++)
            {
                if (MessageCirculation.instPaperOut != null)
                {
                    MessageCirculation.instPaperOut.transform.Translate(-1, 0, 0);
                }

                cam.transform.Translate(-1, 0, 0);
                yield return new WaitForSeconds(speed);
            }
        }
    }
}
