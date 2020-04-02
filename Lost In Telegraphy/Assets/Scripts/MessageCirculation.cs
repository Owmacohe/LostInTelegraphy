/*
 Game made by: Owen Hellum @ Concordia University
 Project for my COMS 360 and LING 300 classes

 Check out the documentation here: https://bit.ly/LostInTelegraphy
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageCirculation : MonoBehaviour
{
    public GameObject shadow;
    public float shadowStart;

    public GameObject messageInstantiator;
    public GameObject message;

    //Random paper sprites that can be assigned
    public Sprite paper1;
    public Sprite paper2;
    public Sprite paper3;
    public Sprite paper4;
    public Sprite paper5;

    //Editor inputs for static variables

    public GameObject sendInput;
    public static GameObject sendTab;
    public GameObject sentInput;
    public static GameObject sentTab;

    public static GameObject instMessage;
    public static Sprite instMessageSprite;

    public static GameObject instPaperOut;
    public static Sprite instPaperOutSprite;

    public static string sendDirection;
    public static string sentDirection;

    public GameObject blockInput;
    public static GameObject block;

    public GameObject blockInstantiatorInput;
    public static GameObject blockInstantiator;

    public GameObject paperOutInput;
    public static GameObject paperOut;

    //Seriousness level
    public static int messageCount = 11;

    public GameObject infoSheetInput;
    public static GameObject infoSheet;

    public GameObject sheetTitle;

    public GameObject sheetInfoInput;
    public static GameObject sheetInfo;

    public static string infoGender;
    public static string infoAge;
    public static string infoEthnicity;
    public static string infoPoliticalAlignment;

    void Start()
    {
        //Starts the cycle
        newMessage();

        //Setting all of the static variables equal to their values given in the editor

        sendTab = sendInput;
        sentTab = sentInput;

        blockInstantiator = blockInstantiatorInput;
        block = blockInput;

        paperOut = paperOutInput;

        infoSheet = infoSheetInput;
        sheetInfo = sheetInfoInput;

        sheetTitle.GetComponent<MeshRenderer>().sortingOrder = 4;
        sheetInfo.GetComponent<MeshRenderer>().sortingOrder = 4;
    }

    private void newMessage()
    {
        StartCoroutine(slideShadow(2));
    }

    //Cosmetic IEnumerator for making the person's shadow slide in, stop, then slide out
    IEnumerator slideShadow(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        float i;
        for (i = shadow.transform.position.x; i < -0.25f; i = (i + 0.5f))
        {
            yield return new WaitForSeconds(0.075f);
            shadow.transform.Translate(0.5f, 0, 0);
        }

        StartCoroutine(slideMessage());

        yield return new WaitForSeconds(seconds);

        float j;
        for (j = shadow.transform.position.x; j < 10.2; j = (j + 0.5f))
        {
            yield return new WaitForSeconds(0.075f);
            shadow.transform.Translate(0.5f, 0, 0);
        }

        shadow.transform.position = new Vector2(-10.2f, shadow.transform.position.y);
    }

    //Creates in the in message, gives it one of 5 sprites, and slides it down the typing dessk
    IEnumerator slideMessage()
    {
        instMessage = Instantiate(message, new Vector2(messageInstantiator.transform.position.x, messageInstantiator.transform.position.y), Quaternion.Euler(0, 0, 90));

        int paperNum = Random.Range(1, 5);
        switch (paperNum)
        {
            case 1:
                {
                    instMessage.GetComponent<SpriteRenderer>().sprite = paper1;
                    break;
                }
            case 2:
                {
                    instMessage.GetComponent<SpriteRenderer>().sprite = paper2;
                    break;
                }
            case 3:
                {
                    instMessage.GetComponent<SpriteRenderer>().sprite = paper3;
                    break;
                }
            case 4:
                {
                    instMessage.GetComponent<SpriteRenderer>().sprite = paper4;
                    break;
                }
            case 5:
                {
                    instMessage.GetComponent<SpriteRenderer>().sprite = paper5;
                    break;
                }
        }

        instMessageSprite = instMessage.GetComponent<SpriteRenderer>().sprite;

        float i;
        for (i = messageInstantiator.transform.position.y; i > 0.5; i = (i - 0.3f))
        {
            instMessage.transform.Translate(-0.5f, 0, 0);
            instMessage.transform.Rotate(0, 0, Random.Range(-10, 10));
            yield return new WaitForSeconds(0.05f);
        }
    }

    //Checking to see which tabs are up and down, and setting them according to parameters
    private void Update()
    {
        if (sendDirection == "up" && sendTab.transform.position.y < 5.6)
        {
            sendTab.transform.position = new Vector3(sendTab.transform.position.x, sendTab.transform.position.y + 1.6f, sendTab.transform.position.z);
        }
        else if (sendDirection == "down" && sendTab.transform.position.y > 4.4)
        {
            sendTab.transform.position = new Vector3(sendTab.transform.position.x, sendTab.transform.position.y - 1.6f, sendTab.transform.position.z);
        }
        if (sentDirection == "up" && sentTab.transform.position.y < 5.6)
        {
            sentTab.transform.position = new Vector3(sentTab.transform.position.x, sentTab.transform.position.y + 1.4f, sentTab.transform.position.z);

            //Starts the process again when the sent tab pops back up (when the screen shifts back)
            PaperInteractionIn.acknowledged = false;
            newMessage();
        }
        else if (sentDirection == "down" && sentTab.transform.position.y > 4.4)
        {
            sentTab.transform.position = new Vector3(sentTab.transform.position.x, sentTab.transform.position.y - 1.4f, sentTab.transform.position.z);
        }
    }

    public static void tabSet(string tab, string direction)
    {
        if (tab == "send")
        {
            if (direction == "up")
            {
                sendDirection = "up";
            }
            else if (direction == "down")
            {
                sendDirection = "down";
            }
        }
        else if (tab == "sent")
        {
            if (direction == "up")
            {
                sentDirection = "up";
            }
            else if (direction == "down")
            {
                sentDirection = "down";
            }
        }
    }

    public static void addBlocks(int addNum)
    {
        int i;
        for (i = 0; i < addNum; i++)
        {
            //Instantiates all the block words of the words in the incoming message
            block.GetComponentInChildren<TextMeshPro>().text = PaperInteractionIn.parts[i];

            Instantiate(block, new Vector2(Random.Range(-4.8f, 0f), blockInstantiator.transform.position.y), Quaternion.identity);

            //Debug.Log(i + ": " + PaperInteractionIn.parts[i]);

            int j;
            for (j = 0; j < (PaperMessages.synonyms.Length / 7); j++)
            {
                if (block.GetComponentInChildren<TextMeshPro>().text == PaperMessages.synonyms[j, 0])
                {
                    //Debug.Log("found synonym for: " + block.GetComponentInChildren<TextMeshPro>().text);

                    addSynonyms(j);
                }
            }
        }
    }

    //Adds a random number of synonyms pertaining to a select few words in the message
    public static void addSynonyms(int wordSelection)
    {
        block.GetComponentInChildren<TextMeshPro>().text = PaperMessages.synonyms[wordSelection, Random.Range(1, 7)];

        Instantiate(block, new Vector2(Random.Range(-4.8f, 0f), blockInstantiator.transform.position.y), Quaternion.identity);

        //Debug.Log("added synonym: " + COMSmessages.synonyms[wordSelection, rand]);
    }

    public static void addRandomBlocks(int addNum)
    {
        int i;
        for (i = 0; i < addNum; i++)
        {
            block.GetComponentInChildren<TextMeshPro>().text = PaperMessages.getRandomWord();

            Instantiate(block, new Vector2(Random.Range(-4.8f, 0f), blockInstantiator.transform.position.y), Quaternion.identity);
        }
    }

    //Adds and assigns the the sprite of the outgoing message
    public static void addPaperOut()
    {
        instPaperOut = Instantiate(paperOut, new Vector2(6.5f, -3.2f), Quaternion.identity);
        instPaperOutSprite = instPaperOut.GetComponent<SpriteRenderer>().sprite;
    }

    public static IEnumerator slideInfoSheet()
    {
        infoGender = PaperMessages.senderInfo[0, Random.Range(0, 5)];
        infoAge = PaperMessages.senderInfo[1, Random.Range(0, 5)];
        infoEthnicity = PaperMessages.senderInfo[2, Random.Range(0, 5)];
        infoPoliticalAlignment = PaperMessages.senderInfo[3, Random.Range(0, 5)];

        sheetInfo.GetComponent<TextMeshPro>().text = "Gender: " + infoGender + "\nAge: " + infoAge + "\nEthnicity: " + infoEthnicity + "\nPolitical Alignment: " + infoPoliticalAlignment;

        float i;
        for (i = infoSheet.transform.position.y; i > 6.05f; i = (i - 0.02f))
        {
            infoSheet.transform.Translate(0, -0.02f, 0);
            yield return new WaitForSeconds(0);
        }
    }
}
