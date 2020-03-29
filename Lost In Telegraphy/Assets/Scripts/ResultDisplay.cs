using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultDisplay : MonoBehaviour
{
    public TextMeshPro accuracy;
    public TextMeshPro length;
    public TextMeshPro average;

    void Start()
    {
        int genderAccuracyMax = 0;
        int genderLengthMax = 0;
        string genderAccuracyResult = "";
        string genderLengthResult = "";

        getScores(0, genderAccuracyMax, genderLengthMax, genderAccuracyResult, genderLengthResult);

        //age

        int ethnicityAccuracyMax = 0;
        int ethnicityLengthMax = 0;
        string ethnicityAccuracyResult = "";
        string ethnicityLengthResult = "";

        getScores(0, ethnicityAccuracyMax, ethnicityLengthMax, ethnicityAccuracyResult, ethnicityLengthResult);

        int politicalAlignmentAccuracyMax = 0;
        int politicalAlignmentLengthMax = 0;
        string politicalAlignmentAccuracyResult = "";
        string politicalAlignmentLengthResult = "";

        getScores(0, politicalAlignmentAccuracyMax, politicalAlignmentLengthMax, politicalAlignmentAccuracyResult, politicalAlignmentLengthResult);

        accuracy.text = "Gender: " + genderAccuracyResult + "\nAge: " /*+  */+ "\nEthnicity: " + ethnicityAccuracyResult + "\nPolitical Alignment: " + politicalAlignmentAccuracyResult;
        length.text = "Gender: " + genderLengthResult + "\nAge: " /*+  */+ "\nEthnicity: " + ethnicityLengthResult + "\nPolitical Alignment: " + politicalAlignmentLengthResult;
    }

    void getScores(int identityElement, int acMax, int lnMax, string acRes, string lnRes)
    {
        int i;
        for (i = 0; i < 5; i++)
        {
            if (PaperMessages.accuracyScores[identityElement, i] > acMax)
            {
                acMax = PaperMessages.accuracyScores[identityElement, i];
                acRes = PaperMessages.senderInfo[identityElement, i];

            }

            if (PaperMessages.lengthScores[identityElement, i] > lnMax)
            {
                lnMax = PaperMessages.lengthScores[identityElement, i];
                acRes = PaperMessages.senderInfo[identityElement, i];

            }
        }
    }
}
