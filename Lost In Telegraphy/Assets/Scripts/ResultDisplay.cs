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
        getScores();

        Debug.Log("Gender: " + genderAccuracyResult + " Age: " + ageAccuracyResult + " Ethnicity: " + ethnicityAccuracyResult + " Political Alignment: " + politicalAlignmentAccuracyResult);
        Debug.Log("Gender: " + genderLengthResult + " Age: " + ageLengthResult + " Ethnicity: " + ethnicityLengthResult + " Political Alignment: " + politicalAlignmentLengthResult);

        accuracy.text = "Gender: " + genderAccuracyResult + "\nAge: " + ageAccuracyResult + "\nEthnicity: " + ethnicityAccuracyResult + "\nPolitical Alignment: " + politicalAlignmentAccuracyResult;
        length.text = "Gender: " + genderLengthResult + "\nAge: " + ageLengthResult + "\nEthnicity: " + ethnicityLengthResult + "\nPolitical Alignment: " + politicalAlignmentLengthResult;
    }

    void getScores()
    {
        float acMax = 0;
        string acRes = "";
        float lnMax = 0;
        string lnRes = "";

        int i;
        for (i = 0; i < 4; i++)
        {
            int j;
            for (j = 0; j < 5; j++)
            {
                if (PaperMessages.accuracyScores[i, j] >= acMax)
                {
                    acMax = PaperMessages.accuracyScores[i, j];
                    acRes = PaperMessages.senderInfo[i, (int)acMax];
                }

                if (PaperMessages.lengthScores[i, j] >= lnMax)
                {
                    lnMax = PaperMessages.lengthScores[i, j];
                    lnRes = PaperMessages.senderInfo[i, (int)lnMax];
                }
            }

            switch (i)
            {
                case 0:
                    genderAccuracyResult = acRes;
                    genderLengthResult = lnRes;
                    break;
                case 1:
                    ageAccuracyResult = acRes;
                    ageLengthResult = lnRes;
                    break;
                case 2:
                    ethnicityAccuracyResult = acRes;
                    ethnicityLengthResult = lnRes;
                    break;
                case 3:
                    politicalAlignmentAccuracyResult = acRes;
                    politicalAlignmentLengthResult = lnRes;
                    break;
            }
        }
    }
}
