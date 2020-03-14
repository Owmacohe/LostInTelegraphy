﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        MessageCirculation.tabSet("sent", "down");
        MessageCirculation.tabSet("send", "up");

        Destroy(MessageCirculation.instPaperOut, 0.5f);
        Destroy(MessageCirculation.instMessage, 0.5f);

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("WordBlock");

        int i;
        for (i = 0; i < blocks.Length; i++)
        {
            Destroy(blocks[i], 0.5f);
        }
    }
}
