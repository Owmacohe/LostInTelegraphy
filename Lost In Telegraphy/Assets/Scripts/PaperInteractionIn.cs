using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaperInteractionIn : MonoBehaviour
{
    public static bool acknowledged = false;

    public static TextMeshPro messageText;

    public static string sentence;
    public static string[] parts;

    private bool paperSelected = false;


    private void Start()
    {
        this.GetComponentInChildren<MeshRenderer>().sortingOrder = 5;

        messageText = this.GetComponentInChildren<TextMeshPro>();
        int rand = Random.Range(0, COMSmessages.casualMessages.Length);
        messageText.text = COMSmessages.casualMessages[rand];

        sentence = messageText.text;
        parts = sentence.Split(' ');
    }

    private void OnMouseDown()
    {
        if (acknowledged == false)
        {
            MessageCirculation.addBlocks(parts.Length);
            MessageCirculation.addPaperOut();
        }

        this.GetComponent<SpriteRenderer>().sortingOrder = 4;
        acknowledged = true;

        if (this.transform.rotation.eulerAngles.z != 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (paperSelected == false)
        {
            paperSelected = true;
        }
        else
        {
            paperSelected = false;
        }
    }

    private void Update()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mouse);

        if (paperSelected == true)
        {
            this.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
        }
        else
        {
            return;
        }
    }
}
