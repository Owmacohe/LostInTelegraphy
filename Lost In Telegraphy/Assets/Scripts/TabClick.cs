/*
 Game made by: Owen Hellum @ Concordia University
 Project for my COMS 360 and LING 300 classes

 Check out the documentation here: https://bit.ly/LostInTelegraphy
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        /*
        switch (MessageCirculation.infoGender)
        {
            case "Male":
                PaperMessages.identityScores[0, 0]++;
                break;
            case "Female":
                PaperMessages.identityScores[0, 1]++;
                break;
            case "Non-binary":
                PaperMessages.identityScores[0, 2]++;
                break;
            case "Genderfluid":
                PaperMessages.identityScores[0, 3]++;
                break;
            case "Other":
                PaperMessages.identityScores[0, 4]++;
                break;
        }

        if (MessageCirculation.infoAge >= 1 && MessageCirculation.infoAge < 21)
        {
            PaperMessages.identityScores[1, 0]++;
        }
        else if (MessageCirculation.infoAge >= 21 && MessageCirculation.infoAge < 41)
        {
            PaperMessages.identityScores[1, 1]++;
        }
        else if (MessageCirculation.infoAge >= 41 && MessageCirculation.infoAge < 61)
        {
            PaperMessages.identityScores[1, 2]++;
        }
        else if (MessageCirculation.infoAge >= 61 && MessageCirculation.infoAge < 81)
        {
            PaperMessages.identityScores[1, 3]++;
        }
        else if (MessageCirculation.infoAge >= 81 && MessageCirculation.infoAge < 101)
        {
            PaperMessages.identityScores[1, 4]++;
        }

        switch (MessageCirculation.infoEthnicity)
        {
            case "White":
                PaperMessages.identityScores[2, 0]++;
                break;
            case "Black":
                PaperMessages.identityScores[2, 1]++;
                break;
            case "Indigenous":
                PaperMessages.identityScores[2, 2]++;
                break;
            case "Middle Eastern":
                PaperMessages.identityScores[2, 3]++;
                break;
            case "Asian":
                PaperMessages.identityScores[2, 4]++;
                break;
        }

        switch (MessageCirculation.infoPoliticalAlignment)
        {
            case "Authoritarian Right":
                PaperMessages.identityScores[3, 0]++;
                break;
            case "Libertarian Right":
                PaperMessages.identityScores[3, 1]++;
                break;
            case "Authoritarian Left":
                PaperMessages.identityScores[3, 2]++;
                break;
            case "Libertarian Left":
                PaperMessages.identityScores[3, 3]++;
                break;
            case "Apolitical":
                PaperMessages.identityScores[3, 4]++;
                break;
        }
        */

        MessageCirculation.tabSet("sent", "down");
        MessageCirculation.tabSet("send", "up");

        //Destroys the blocks and paper to make room for the next incoming message

        Destroy(MessageCirculation.instPaperOut, 0.5f);
        Destroy(MessageCirculation.instMessage, 0.5f);


        GameObject[] blocks = GameObject.FindGameObjectsWithTag("WordBlock");

        int i;
        for (i = 0; i < blocks.Length; i++)
        {
            Destroy(blocks[i], 0.5f);
        }

        MessageCirculation.infoSheet.transform.position = new Vector3(MessageCirculation.infoSheet.transform.position.x, 8.6f, 0);
    }
}
