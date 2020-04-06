/*
 Game made by: Owen Hellum @ Concordia University
 Project for my COMS 360 and LING 300 classes

 Check out the documentation here: https://bit.ly/LostInTelegraphy
 View it on my website: https://owmacohe.github.io/games.html
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaperInteractionIn : MonoBehaviour
{
    public static bool acknowledged;

    //Variables for breaking the sentence down into individual words
    public static TextMeshPro messageText;
    public static string sentence;
    public static string[] parts;

    private bool paperSelected = false;

    private void Start()
    {
        this.GetComponentInChildren<MeshRenderer>().sortingOrder = 5;

        int randomMessage;
        messageText = this.GetComponentInChildren<TextMeshPro>();

        //Determines what kind of message will be outputted: casual, serious, or dire
        if (MessageCirculation.messageCount >= 1 && MessageCirculation.messageCount < 5)
        {
            randomMessage = Random.Range(0, PaperMessages.casualMessages.Count);
            messageText.text = PaperMessages.casualMessages[randomMessage];
            PaperMessages.casualMessages.Remove(PaperMessages.casualMessages[randomMessage]);
        }
        else if (MessageCirculation.messageCount >= 5 && MessageCirculation.messageCount < 9)
        {
            randomMessage = Random.Range(0, PaperMessages.seriousMessages.Count);
            messageText.text = PaperMessages.seriousMessages[randomMessage];
            PaperMessages.seriousMessages.Remove(PaperMessages.seriousMessages[randomMessage]);
        }
        else if (MessageCirculation.messageCount >= 9 && MessageCirculation.messageCount < 13)
        {
            randomMessage = Random.Range(0, PaperMessages.direMessages.Count);
            messageText.text = PaperMessages.direMessages[randomMessage];
            PaperMessages.direMessages.Remove(PaperMessages.direMessages[randomMessage]);
        }

        sentence = messageText.text;
        parts = sentence.Split(' ');

        MessageCirculation.messageCount++;
    }

    //For how the paper itself is dragged around
    private void OnMouseDown()
    {
        if (acknowledged == false)
        {
            MessageCirculation.addRandomBlocks(Random.Range(1, (int)(parts.Length / 1.5)));

            MessageCirculation.addBlocks(parts.Length);
            MessageCirculation.addPaperOut();
            StartCoroutine(MessageCirculation.slideInfoSheet());
        }

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
    }

    private void OnMouseUp()
    {
        if (paperSelected == true)
        {
            paperSelected = false;
        }
    }

    //Snapping the paper to the cursor when selected
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
}
