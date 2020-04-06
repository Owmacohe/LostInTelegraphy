/*
 Game made by: Owen Hellum @ Concordia University
 Project for my COMS 360 and LING 300 classes

 Check out the documentation here: https://bit.ly/LostInTelegraphy
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsOrder : MonoBehaviour
{
    public Transform text1;
    public Transform text2;
    public Transform text3;
    public Transform text4;
    public Transform text5;

    public float speed;
    
    void Start()
    {
        StartCoroutine(slideCredit(text1, "right", -5));
        StartCoroutine(slideCredit(text2, "left", 5));
        StartCoroutine(slideCredit(text3, "down", 0.8f));
        StartCoroutine(slideCredit(text4, "right", -3.5f));
        StartCoroutine(slideCredit(text5, "left", 3.5f));
    }

    //Cosmetic IEnumerator for sliding the credits onto the screen
    IEnumerator slideCredit(Transform credit, string direction, float max)
    {
        if (direction == "down")
        {
            float i;
            for (i = credit.position.y; i > max; i = (i - speed))
            {
                credit.position = new Vector3(credit.position.x, i, credit.position.z);
                yield return new WaitForSeconds(0);
            }
        }
        else if (direction == "right")
        {
            float i;
            for (i = credit.position.x; i < max; i = (i + speed))
            {
                credit.position = new Vector3(i, credit.position.y, credit.position.z);
                yield return new WaitForSeconds(0);
            }
        }
        else if (direction == "left")
        {
            float i;
            for (i = credit.position.x; i > max; i = (i - speed))
            {
                credit.position = new Vector3(i, credit.position.y, credit.position.z);
                yield return new WaitForSeconds(0);
            }
        }
    }
}
