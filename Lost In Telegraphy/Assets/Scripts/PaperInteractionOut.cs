﻿/*
 Game made by: Owen Hellum @ Concordia University
 Project for my COMS 360 and LING 300 classes

 Check out the documentation here: https://bit.ly/LostInTelegraphy
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperInteractionOut : MonoBehaviour
{
    //private bool paperSelected = false;

    public static List<GameObject> attatchedBlocks = new List<GameObject>();

    private void Start()
    {
        attatchedBlocks = new List<GameObject>();

        StartCoroutine(paperOutSlide());
    }

    private void OnMouseDown()
    {
        this.GetComponent<SpriteRenderer>().sortingOrder = 6;

        /*
        if (paperSelected == false)
        {
            paperSelected = true;
        }
        */
    }

    /*
    private void OnMouseUp()
    {
        if (paperSelected == true)
        {
            paperSelected = false;
        }
    }
    */

    /*
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
    */

    //Cosmetic IEnumerator for sliding the outgoing message out
    IEnumerator paperOutSlide()
    {
        float i;
        for (i = this.transform.position.x; i > 2.8; i = (i - 0.03f))
        {
            this.transform.position = new Vector3(i, this.transform.position.y, this.transform.position.z);
            yield return new WaitForSeconds(0);
        }

        this.GetComponent<SpriteRenderer>().sortingOrder = 4;
    }

    //Triggering the tab dropdown
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PaperSlot")/* && WordInteraction.wordSet == MessageCirculation.blockNum*/)
        {
            MessageCirculation.tabSet("send", "down");
        }

        if (collision.CompareTag("WordBlock"))
        {
            attatchedBlocks.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PaperSlot"))
        {
            MessageCirculation.tabSet("send", "up");
        }

        if (collision.CompareTag("WordBlock"))
        {
            int i;
            for (i = 0; i < attatchedBlocks.Count; i ++)
            {
                if (attatchedBlocks[i] == collision.gameObject)
                {
                    attatchedBlocks.Remove(attatchedBlocks[i]);
                }
            }
        }
    }
}
