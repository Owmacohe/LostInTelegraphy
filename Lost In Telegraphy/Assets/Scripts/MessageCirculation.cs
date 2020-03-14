using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCirculation : MonoBehaviour
{
    public GameObject shadow;
    public float shadowStart;

    public GameObject messageInstantiator;
    public GameObject message;

    public Sprite paper1;
    public Sprite paper2;
    public Sprite paper3;
    public Sprite paper4;
    public Sprite paper5;

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

    public int blockNumInput;
    public static int blockNum;

    void Start()
    {
        newMessage();

        sendTab = sendInput;
        sentTab = sentInput;

        blockInstantiator = blockInstantiatorInput;
        block = blockInput;

        paperOut = paperOutInput;

        blockNum = blockNumInput;
    }

    public void newMessage()
    {
        StartCoroutine(slideShadow(2));
    }

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

    public static void addBlocks(int blockNum)
    {
        int i;
        for (i = 0; i < blockNum; i++)
        {
            float rand = Random.Range(-4.8f, 0f);

            Instantiate(block, new Vector2(rand, blockInstantiator.transform.position.y), Quaternion.identity);
        }
    }

    public static void addPaperOut()
    {
        instPaperOut = Instantiate(paperOut, new Vector2(6.5f, -3.2f), Quaternion.identity);
        instPaperOutSprite = instPaperOut.GetComponent<SpriteRenderer>().sprite;
    }
}
