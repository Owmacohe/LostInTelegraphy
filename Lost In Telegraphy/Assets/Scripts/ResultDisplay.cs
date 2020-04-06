/*
 Game made by: Owen Hellum @ Concordia University
 Project for my COMS 360 and LING 300 classes

 Check out the documentation here: https://bit.ly/LostInTelegraphy
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
            float acMax = -10;
            string acResult = "";
            float lnMax = -10;
            string lnResult = "";

            //Loop through 5 identity element possibilities, and find the greatest identity element possibility
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

            //Setting the proper identity element possibility to its result
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

        /*

        ---> This was a failed attempt to add an average score between accuracy and length, but it was just taking too long, so I scrapped it <---

        float genAvMax = -10;
        float ageAvMax = -10;
        float ethAvMax = -10;
        float polAvMax = -10;
        string genderAverage = "g";
        string ageAverage = "a";
        string ethnicityAverage = "r";
        string politicalAlignmentAverage = "p";

        int k;
        for (k = 0; k < 5; k++)
        {
            Debug.Log("score " + (PaperMessages.accuracyScores[0, k] + PaperMessages.lengthScores[0, k]));
            Debug.Log("max " + genAvMax);

            if ((PaperMessages.accuracyScores[0, k] + PaperMessages.lengthScores[0, k]) >= genAvMax)
            {
                genAvMax = PaperMessages.accuracyScores[0, k] + PaperMessages.lengthScores[0, k];
                genderAverage = PaperMessages.senderInfo[0, k];
            }
            else if ((PaperMessages.accuracyScores[1, k] + PaperMessages.lengthScores[1, k]) >= ageAvMax)
            {
                ageAvMax = PaperMessages.accuracyScores[1, k] + PaperMessages.lengthScores[1, k];
                ageAverage = PaperMessages.senderInfo[1, k];
            }
            else if ((PaperMessages.accuracyScores[2, k] + PaperMessages.lengthScores[2, k]) >= ethAvMax)
            {
                ethAvMax = PaperMessages.accuracyScores[2, k] + PaperMessages.lengthScores[2, k];
                ethnicityAverage = PaperMessages.senderInfo[2, k];

                Debug.Log("Set rac up");
            }
            else if ((PaperMessages.accuracyScores[3, k] + PaperMessages.lengthScores[3, k]) >= polAvMax)
            {
                polAvMax = PaperMessages.accuracyScores[3, k] + PaperMessages.lengthScores[3, k];
                politicalAlignmentAverage = PaperMessages.senderInfo[3, k];

                Debug.Log("Set pol up");
            }
        }
        */

        //Debug.Log("Gender: " + genderAccuracyResult + " Age: " + ageAccuracyResult + " Ethnicity: " + ethnicityAccuracyResult + " Political Alignment: " + politicalAlignmentAccuracyResult);
        //Debug.Log("Gender: " + genderLengthResult + " Age: " + ageLengthResult + " Ethnicity: " + ethnicityLengthResult + " Political Alignment: " + politicalAlignmentLengthResult);
        //Debug.Log("Gender: " + genderAverage + " Age: " + ageAverage + " Ethnicity: " + ethnicityAverage + " Political Alignment: " + politicalAlignmentAverage);

        accuracy.text = "Gender: " + genderAccuracyResult + "\nAge: " + ageAccuracyResult + "\nRace: " + ethnicityAccuracyResult + "\nPolitical Alignment: " + politicalAlignmentAccuracyResult;
        length.text = "Gender: " + genderLengthResult + "\nAge: " + ageLengthResult + "\nRace: " + ethnicityLengthResult + "\nPolitical Alignment: " + politicalAlignmentLengthResult;
        //average.text = "Gender: " + genderAverage + "\nAge: " + ageAverage + "\nRace: " + ethnicityAverage + "\nPolitical Alignment: " + politicalAlignmentAverage;
    }
}
