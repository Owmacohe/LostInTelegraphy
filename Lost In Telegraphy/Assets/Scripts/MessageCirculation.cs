using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCirculation : MonoBehaviour
{
    public GameObject shadow;
    public float shadowStart;

    public GameObject instantiator;
    public GameObject message;

    public Sprite paper1;
    public Sprite paper2;
    public Sprite paper3;
    public Sprite paper4;
    public Sprite paper5;

    void Start()
    {
        newMessage();
    }

    void newMessage()
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
        GameObject newMessage = Instantiate(message, new Vector2(instantiator.transform.position.x, instantiator.transform.position.y), Quaternion.Euler(0, 0, 90));

        int paperNum = Random.Range(1, 5);
        switch (paperNum)
        {
            case 1:
                {
                    newMessage.GetComponent<SpriteRenderer>().sprite = paper1;
                    break;
                }
            case 2:
                {
                    newMessage.GetComponent<SpriteRenderer>().sprite = paper2;
                    break;
                }
            case 3:
                {
                    newMessage.GetComponent<SpriteRenderer>().sprite = paper3;
                    break;
                }
            case 4:
                {
                    newMessage.GetComponent<SpriteRenderer>().sprite = paper4;
                    break;
                }
            case 5:
                {
                    newMessage.GetComponent<SpriteRenderer>().sprite = paper5;
                    break;
                }
        }

        float i;
        for (i = instantiator.transform.position.y; i > 0.5; i = (i - 0.3f))
        {
            newMessage.transform.Translate(-0.5f, 0, 0);
            newMessage.transform.Rotate(0, 0, Random.Range(-10, 10));
            yield return new WaitForSeconds(0.05f);
        }
    }
}
