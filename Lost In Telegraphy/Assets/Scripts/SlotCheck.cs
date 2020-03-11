using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paper"))
        {
            Debug.Log("enter");

            //MessageCirculation.tabsSlide("send", "down");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Paper"))
        {
            Debug.Log("exit");

            //MessageCirculation.tabsSlide("send", "up");
        }
    }
}
