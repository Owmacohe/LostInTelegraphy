using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultDisplay : MonoBehaviour
{
    public TextMeshPro accuracy;
    public TextMeshPro length;
    public TextMeshPro average;

    private string genderAccuracyResult;
    private string genderLengthResult;

    private string ageAccuracyResult;
    private string ageLengthResult;

    private string ethnicityAccuracyResult;
    private string ethnicityLengthResult;

    private string politicalAlignmentAccuracyResult;
    private string politicalAlignmentLengthResult;

    void Start()
    {
        //Loop through 4 identity elements
        int i;
        for (i = 0; i < 4; i++)
        {
            float acMax = 0;
            string acResult = "";
            float lnMax = 0;
            string lnResult = "";

            //Loop through 5 identity element possibilities
            int j;
            for (j = 0; j < 5; j++)
            {
                if (PaperMessages.accuracyScores[i, j] >= acMax)
                {
                    acMax = PaperMessages.accuracyScores[i, j];
                    acResult = PaperMessages.senderInfo[i, j];
                }

                if (PaperMessages.lengthScores[i, j] >= lnMax)
                {
                    lnMax = PaperMessages.lengthScores[i, j];
                    lnResult = PaperMessages.senderInfo[i, j];
                }
            }

            switch (i)
            {
                case 0:
                    genderAccuracyResult = acResult;
                    genderLengthResult = lnResult;
                    break;
                case 1:
                    ageAccuracyResult = acResult;
                    ageLengthResult = lnResult;
                    break;
                case 2:
                    ethnicityAccuracyResult = acResult;
                    ethnicityLengthResult = lnResult;
                    break;
                case 3:
                    politicalAlignmentAccuracyResult = acResult;
                    politicalAlignmentLengthResult = lnResult;
                    break;
            }
        }

        float genAvMax = 0;
        float ageAvMax = 0;
        float ethAvMax = 0;
        float polAvMax = 0;
        string genderAverage = "";
        string ageAverage = "";
        string ethnicityAverage = "";
        string politicalAlignmentAverage = "";

        int k;
        for (k = 0; k < 5; k++)
        {
            if (PaperMessages.accuracyScores[0, k] + PaperMessages.lengthScores[0, k] >= genAvMax)
            {
                genAvMax = PaperMessages.accuracyScores[0, k] + PaperMessages.lengthScores[0, k];
                genderAverage = PaperMessages.senderInfo[0, k];
            }
            else if (PaperMessages.accuracyScores[1, k] + PaperMessages.lengthScores[1, k] >= ageAvMax)
            {
                ageAvMax = PaperMessages.accuracyScores[1, k] + PaperMessages.lengthScores[1, k];
                ageAverage = PaperMessages.senderInfo[1, k];
            }
            else if (PaperMessages.accuracyScores[2, k] + PaperMessages.lengthScores[2, k] >= ethAvMax)
            {
                ethAvMax = PaperMessages.accuracyScores[2, k] + PaperMessages.lengthScores[2, k];
                ethnicityAverage = PaperMessages.senderInfo[2, k];
            }
            else if (PaperMessages.accuracyScores[3, k] + PaperMessages.lengthScores[3, k] >= polAvMax)
            {
                polAvMax = PaperMessages.accuracyScores[3, k] + PaperMessages.lengthScores[3, k];
                politicalAlignmentAverage = PaperMessages.senderInfo[3, k];
            }
        }

        //Debug.Log("Gender: " + genderAccuracyResult + " Age: " + ageAccuracyResult + " Ethnicity: " + ethnicityAccuracyResult + " Political Alignment: " + politicalAlignmentAccuracyResult);
        //Debug.Log("Gender: " + genderLengthResult + " Age: " + ageLengthResult + " Ethnicity: " + ethnicityLengthResult + " Political Alignment: " + politicalAlignmentLengthResult);

        accuracy.text = "Gender: " + genderAccuracyResult + "\nAge: " + ageAccuracyResult + "\nEthnicity: " + ethnicityAccuracyResult + "\nPolitical Alignment: " + politicalAlignmentAccuracyResult;
        length.text = "Gender: " + genderLengthResult + "\nAge: " + ageLengthResult + "\nEthnicity: " + ethnicityLengthResult + "\nPolitical Alignment: " + politicalAlignmentLengthResult;
        average.text = "Gender: " + genderAverage + "\nAge: " + ageAverage + "\nEthnicity: " + ethnicityAverage + "\nPolitical Alignment: " + politicalAlignmentAverage;
    }
}
