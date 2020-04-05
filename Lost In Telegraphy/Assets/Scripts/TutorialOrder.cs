/*
 Game made by: Owen Hellum @ Concordia University
 Project for my COMS 360 and LING 300 classes

 Check out the documentation here: https://bit.ly/LostInTelegraphy
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialOrder : MonoBehaviour
{
    public GameObject contextScreenInput;
    public static GameObject contextScreen;

    public GameObject tutorialScreenInput;
    public static GameObject tutorialScreen;

    public GameObject paper;

    private void Start()
    {
        contextScreen = contextScreenInput;
        tutorialScreen = tutorialScreenInput;

        paper.GetComponentInChildren<MeshRenderer>().sortingOrder = 2;
    }

    //Sets the length of display for the small 'tutorial'
    public static IEnumerator runTutorial(string sceneName)
    {
        contextScreen.SetActive(false);
        tutorialScreen.SetActive(true);

        yield return new WaitForSeconds(15);

        SceneManager.LoadScene(sceneName);
    }
}
