/*
 Game made by: Owen Hellum @ Concordia University
 Project for my COMS 360 and LING 300 classes

 Check out the documentation here: https://bit.ly/LostInTelegraphy
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TabClick : MonoBehaviour
{
    public Transform resultsPaper;

    private void OnMouseDown()
    {
        int correctCount = 0;

        //Finds out how many correct words were in the message when sent
        int i;
        for (i = 0; i < PaperInteractionOut.attatchedBlocks.Count; i++)
        {
            int j;
            for (j = 0; j < PaperInteractionIn.parts.Length; j++)
            {
                if (PaperInteractionOut.attatchedBlocks[i].GetComponentInChildren<TextMeshPro>().text == PaperInteractionIn.parts[j])
                {
                    correctCount++;
                }
            }
        }

        //Gets the accuracy and length percentages of the sent message, and adjusts all scores for the sender's identity elements

        float accPercentage = Mathf.Round(((float)correctCount / PaperInteractionIn.parts.Length) * 100);

        if (accPercentage >= MessageCirculation.accThreshhold)
        {
            doScores(PaperMessages.accuracyScores, accPercentage / 100);
        }
        else if (accPercentage < MessageCirculation.accThreshhold)
        {
            doScores(PaperMessages.accuracyScores, -(1 - (accPercentage / 100)));
        }

        float lenPercentage = Mathf.Round(((float)PaperInteractionOut.attatchedBlocks.Count / PaperInteractionIn.parts.Length) * 100);

        if (lenPercentage >= MessageCirculation.lenThreshhold)
        {
            doScores(PaperMessages.lengthScores, lenPercentage / 100);
        }
        else if (lenPercentage < MessageCirculation.lenThreshhold)
        {
            doScores(PaperMessages.lengthScores, -(1 - (lenPercentage / 100)));
        }

        Debug.Log("Accuracy percentage: " + accPercentage + "%" + " Length percentage: " + lenPercentage + "%");
        //Debug.Log("Gender: " + PaperMessages.accuracyScores[0, 0] + " " + PaperMessages.accuracyScores[0, 1] + " " + PaperMessages.accuracyScores[0, 2] + " " + PaperMessages.accuracyScores[0, 3] + " " + PaperMessages.accuracyScores[0, 4] + " /// " + PaperMessages.lengthScores[0, 0] + " " + PaperMessages.lengthScores[0, 1] + " " + PaperMessages.lengthScores[0, 2] + " " + PaperMessages.lengthScores[0, 3] + " " + PaperMessages.lengthScores[0, 4]);

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

        if (MessageCirculation.messageCount >= 13)
        {
            StartCoroutine(slideResults());
        }
    }

    //Cosmetic IEnumerator to go to the next scene (results)
    IEnumerator slideResults()
    {
        float i;
        for (i = resultsPaper.position.y; i > 0; i = (i - 0.1f))
        {
            resultsPaper.position = new Vector3(resultsPaper.position.x, i, 0);
            yield return new WaitForSeconds(0);
        }

        SceneManager.LoadScene("Results Screen");
    }

    //Sets the values of given idenity element possibilities up or down based on the kind (accuracy or length), and the amount (+ or -)
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
            case "41 to 60":
                scoreType[1, 2] += changeType;
                break;
            case "61 to 80":
                scoreType[1, 3] += changeType;
                break;
            case "81 to 100":
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
