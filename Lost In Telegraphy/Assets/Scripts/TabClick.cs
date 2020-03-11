using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        MessageCirculation.tabSet("sent", "down");
        MessageCirculation.tabSet("send", "up");

        Destroy(MessageCirculation.instMessage, 0.5f);
    }
}
