/*
 Game made by: Owen Hellum @ Concordia University
 Project for my COMS 360 and LING 300 classes

 Check out the documentation here: https://bit.ly/LostInTelegraphy
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TabClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        int correctCount = 0;

        int i;
        for (i = 0; i < PaperInteractionOut.attatchedBlocks.Count; i++)
        {
            int j;
            for (j = 0; j < PaperInteractionIn.parts.Length; j++)
            {
                if (PaperInteractionOut.attatchedBlocks[i].GetComponentInChildren<TextMeshPro>().text == PaperInteractionIn.parts[j])
                {
                    //Debug.Log("Correct word: " + PaperInteractionIn.parts[j]);

                    correctCount++;
                }
            }
        }

        float accPercentage = Mathf.Round(((float)correctCount / PaperInteractionIn.parts.Length) * 100);

        if (accPercentage >= 70)
        {
            doScores(PaperMessages.accuracyScores, accPercentage / 100);
        }
        else if (accPercentage < 70)
        {
            doScores(PaperMessages.accuracyScores, -(1 - (accPercentage / 100)));
        }

        float lenPercentage = Mathf.Round(((float)PaperInteractionOut.attatchedBlocks.Count / PaperInteractionIn.parts.Length) * 100);

        if (lenPercentage >= 85)
        {
            doScores(PaperMessages.lengthScores, lenPercentage / 100);
        }
        else if (lenPercentage < 85)
        {
            doScores(PaperMessages.lengthScores, -(1 - (lenPercentage / 100)));
        }

        Debug.Log("Accuracy percentage: " + accPercentage + "%" + " Length percentage: " + lenPercentage + "%" + " /// " + PaperMessages.accuracyScores[1, 0] + " " + PaperMessages.accuracyScores[1, 1] + " " + PaperMessages.accuracyScores[1, 2] + " " + PaperMessages.accuracyScores[1, 3] + " " + PaperMessages.accuracyScores[1, 4]);

        MessageCirculation.tabSet("sent", "down");
        MessageCirculation.tabSet("send", "up");

        //Destroys the blocks and paper to make room for the next incoming message

        Destroy(MessageCirculation.instPaperOut, 0.5f);
        Destroy(MessageCirculation.instMessage, 0.5f);


        GameObject[] blocks = GameObject.FindGameObjectsWithTag("WordBlock");

        int k;
        for (k = 0; k < blocks.Length; k++)
        {
            Destroy(blocks[k], 0.5f);
        }

        MessageCirculation.infoSheet.transform.position = new Vector3(MessageCirculation.infoSheet.transform.position.x, 8.6f, 0);
    }

    void doScores(float[,] scoreType, float changeType)
    {
        switch (MessageCirculation.infoGender)
        {
            case "Male":
                scoreType[0, 0] += changeType;
                break;
            case "Female":
                scoreType[0, 1] += changeType;
                break;
            case "Non-binary":
                scoreType[0, 2] += changeType;
                break;
            case "Genderfluid":
                scoreType[0, 3] += changeType;
                break;
            case "Other":
                scoreType[0, 4] += changeType;
                break;
        }

        switch (MessageCirculation.infoAge)
        {
            case "1 to 20":
                scoreType[1, 0] += changeType;
                break;
            case "21 to 40":
                scoreType[1, 1] += changeType;
                break;
            case "40 to 61":
                scoreType[1, 2] += changeType;
                break;
            case "60 to 81":
                scoreType[1, 3] += changeType;
                break;
            case "80 to 100":
                scoreType[1, 4] += changeType;
                break;
        }

        switch (MessageCirculation.infoEthnicity)
        {
            case "White":
                scoreType[2, 0] += changeType;
                break;
            case "Black":
                scoreType[2, 1] += changeType;
                break;
            case "Indigenous":
                scoreType[2, 2] += changeType;
                break;
            case "Middle Eastern":
                scoreType[2, 3] += changeType;
                break;
            case "Asian":
                scoreType[2, 4] += changeType;
                break;
        }

        switch (MessageCirculation.infoPoliticalAlignment)
        {
            case "Authoritarian Right":
                scoreType[3, 0] += changeType;
                break;
            case "Libertarian Right":
                scoreType[3, 1] += changeType;
                break;
            case "Authoritarian Left":
                scoreType[3, 2] += changeType;
                break;
            case "Libertarian Left":
                scoreType[3, 3] += changeType;
                break;
            case "Apolitical":
                scoreType[3, 4] += changeType;
                break;
        }
    }
}
