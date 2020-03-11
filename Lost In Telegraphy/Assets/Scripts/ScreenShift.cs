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
            if (MessageCirculation.instMessage != null && PaperInteraction.acknowledged != false)
            {
                MessageCirculation.instMessage.GetComponent<SpriteRenderer>().sprite = flippedPaper;
            }

            int i;
            for (i = 0; i < 16; i++)
            {
                if (MessageCirculation.instMessage != null && PaperInteraction.acknowledged != false)
                {
                    MessageCirculation.instMessage.transform.Translate(1, 0, 0);
                }

                cam.transform.Translate(1, 0, 0);
                yield return new WaitForSeconds(speed);
            }
        }
        else if (direction == "left")
        {
            if (MessageCirculation.instMessage != null)
            {
                MessageCirculation.instMessage.GetComponent<SpriteRenderer>().sprite = MessageCirculation.instMessageSprite;
            }

            int j;
            for (j = 0; j < 16; j++)
            {
                if (MessageCirculation.instMessage != null && PaperInteraction.acknowledged != false)
                {
                    MessageCirculation.instMessage.transform.Translate(-1, 0, 0);
                }

                cam.transform.Translate(-1, 0, 0);
                yield return new WaitForSeconds(speed);
            }
        }
    }
}
