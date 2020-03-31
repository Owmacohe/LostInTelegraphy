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
        float genderAccuracyMax = 0;
        float genderLengthMax = 0;
        string genderAccuracyResult = "";
        string genderLengthResult = "";

        getScores(0, genderAccuracyMax, genderLengthMax, genderAccuracyResult, genderLengthResult);

        float ageAccuracyMax = 0;
        float ageLengthMax = 0;
        string ageAccuracyResult = "";
        string ageLengthResult = "";

        getScores(1, ageAccuracyMax, ageLengthMax, ageAccuracyResult, ageLengthResult);

        float ethnicityAccuracyMax = 0;
        float ethnicityLengthMax = 0;
        string ethnicityAccuracyResult = "";
        string ethnicityLengthResult = "";

        getScores(2, ethnicityAccuracyMax, ethnicityLengthMax, ethnicityAccuracyResult, ethnicityLengthResult);

        float politicalAlignmentAccuracyMax = 0;
        float politicalAlignmentLengthMax = 0;
        string politicalAlignmentAccuracyResult = "";
        string politicalAlignmentLengthResult = "";

        getScores(3, politicalAlignmentAccuracyMax, politicalAlignmentLengthMax, politicalAlignmentAccuracyResult, politicalAlignmentLengthResult);

        accuracy.text = "Gender: " + genderAccuracyResult + "\nAge: " + ageAccuracyResult + "\nEthnicity: " + ethnicityAccuracyResult + "\nPolitical Alignment: " + politicalAlignmentAccuracyResult;
        length.text = "Gender: " + genderLengthResult + "\nAge: " + ageLengthResult + "\nEthnicity: " + ethnicityLengthResult + "\nPolitical Alignment: " + politicalAlignmentLengthResult;
    }

    void getScores(int identityElement, float acMax, float lnMax, string acRes, string lnRes)
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
                lnRes = PaperMessages.senderInfo[identityElement, i];

            }
        }
    }
}
