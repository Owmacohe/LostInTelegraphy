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
        if (MessageCirculation.sentTab.transform.position.y < 5.6)
        {
            MessageCirculation.tabSet("sent", "up");
        }

        if (WordInteraction.shiftedScreens == false)
        {
            WordInteraction.shiftedScreens = true;
        }
        else if (WordInteraction.shiftedScreens == true)
        {
            WordInteraction.shiftedScreens = false;
        }

        StartCoroutine(slider());
    }

    IEnumerator slider()
    {
        if (direction == "right")
        {
            if (/*WordInteraction.wordSet == MessageCirculation.blockNum && */WordInteraction.outPaper != null)
            {
                GameObject[] blocks = GameObject.FindGameObjectsWithTag("WordBlock");

                int k;
                for (k = 0; k < blocks.Length; k++)
                {
                    int m;
                    for (m = 0; m < PaperInteractionOut.attatchedBlocks.Count; m++)
                    {
                        if (blocks[k] == PaperInteractionOut.attatchedBlocks[m])
                        {
                            blocks[k].transform.parent = WordInteraction.outPaper.transform;

                            blocks[k].GetComponent<SpriteRenderer>().enabled = false;
                            blocks[k].GetComponentInChildren<MeshRenderer>().enabled = false;
                        }
                    }
                }
            }

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
            GameObject[] blocks = GameObject.FindGameObjectsWithTag("WordBlock");

            int l;
            for (l = 0; l < blocks.Length; l++)
            {
                blocks[l].GetComponent<SpriteRenderer>().enabled = true;
                blocks[l].GetComponentInChildren<MeshRenderer>().enabled = true;
            }

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

            if (WordInteraction.outPaper != null)
            {
                WordInteraction.outPaper.transform.DetachChildren();
            }
        }
    }
}
