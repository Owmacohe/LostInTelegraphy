/*
 Game made by: Owen Hellum @ Concordia University
 Project for my COMS 360 and LING 300 classes

 Check out the documentation here: https://bit.ly/LostInTelegraphy
 */

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
            //Gets all of the available word blocks, checks which ones are colliding with the out paper, and attatches those
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

                            //Makes the blocks and their text invisiable when switching screens
                            blocks[k].GetComponent<SpriteRenderer>().enabled = false;
                            blocks[k].GetComponentInChildren<MeshRenderer>().enabled = false;
                        }
                    }
                }
            }

            //Changes the paper sprite to it's flipped equivalent when changing the screen nad slides it

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
            //Changes the paper and block sprites back and slides them

            if (MessageCirculation.instPaperOut != null)
            {
                MessageCirculation.instPaperOut.GetComponent<SpriteRenderer>().sprite = MessageCirculation.instPaperOutSprite;
            }

            GameObject[] blocks = GameObject.FindGameObjectsWithTag("WordBlock");

            int l;
            for (l = 0; l < blocks.Length; l++)
            {
                blocks[l].GetComponent<SpriteRenderer>().enabled = true;
                blocks[l].GetComponentInChildren<MeshRenderer>().enabled = true;
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

            //Detatches all blocks

            if (WordInteraction.outPaper != null)
            {
                WordInteraction.outPaper.transform.DetachChildren();
            }
        }
    }
}
