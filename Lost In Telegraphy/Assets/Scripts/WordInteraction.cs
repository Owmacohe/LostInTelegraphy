/*
 Game made by: Owen Hellum @ Concordia University
 Project for my COMS 360 and LING 300 classes

 Check out the documentation here: https://bit.ly/LostInTelegraphy
 View it on my website: https://owmacohe.github.io/games.html
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordInteraction : MonoBehaviour
{
    public static bool shiftedScreens = false;

    private bool blockSelected = false;

    private float outLength;

    public static GameObject block;

    public static GameObject outPaper;

    //Differently-sized sprites for the word blocks
    public Sprite block1;
    public Sprite block2;
    public Sprite block3;
    public Sprite block4;
    public Sprite block5;
    public Sprite block6;
    public Sprite block7;
    private Sprite wordBlockSprite;

    private void Start()
    {
        StartCoroutine(blockSlide());

        outLength = Random.Range(-3.5f, 1.5f);

        block = this.gameObject;

        outPaper = MessageCirculation.instPaperOut;

        this.GetComponentInChildren<MeshRenderer>().sortingOrder = 3;

        //Sets the correct block length depending on the length of the word it contains
        if (this.GetComponentInChildren<TextMeshPro>().text.Length <= 1)
        {
            wordBlockSprite = block1;
            GetComponent<BoxCollider2D>().size = new Vector2(0.02f, 0.02f);
        }
        else if (this.GetComponentInChildren<TextMeshPro>().text.Length > 1 && this.GetComponentInChildren<TextMeshPro>().text.Length <= 3)
        {
            wordBlockSprite = block2;
            GetComponent<BoxCollider2D>().size = new Vector2(0.04f, 0.02f);
        }
        else if (this.GetComponentInChildren<TextMeshPro>().text.Length > 3 && this.GetComponentInChildren<TextMeshPro>().text.Length <= 5)
        {
            wordBlockSprite = block3;
            GetComponent<BoxCollider2D>().size = new Vector2(0.06f, 0.02f);
        }
        else if (this.GetComponentInChildren<TextMeshPro>().text.Length > 5 && this.GetComponentInChildren<TextMeshPro>().text.Length <= 7)
        {
            wordBlockSprite = block4;
            GetComponent<BoxCollider2D>().size = new Vector2(0.08f, 0.02f);
        }
        else if (this.GetComponentInChildren<TextMeshPro>().text.Length > 7 && this.GetComponentInChildren<TextMeshPro>().text.Length <= 9)
        {
            wordBlockSprite = block5;
            GetComponent<BoxCollider2D>().size = new Vector2(0.10f, 0.02f);
        }
        else if (this.GetComponentInChildren<TextMeshPro>().text.Length > 9 && this.GetComponentInChildren<TextMeshPro>().text.Length <= 11)
        {
            wordBlockSprite = block6;
            GetComponent<BoxCollider2D>().size = new Vector2(0.12f, 0.02f);
        }
        else if (this.GetComponentInChildren<TextMeshPro>().text.Length > 11)
        {
            wordBlockSprite = block7;
            GetComponent<BoxCollider2D>().size = new Vector2(0.14f, 0.02f);
        }

        this.gameObject.GetComponent<SpriteRenderer>().sprite = wordBlockSprite;
    }

    private void OnMouseDown()
    {
        if (blockSelected == false && shiftedScreens == false)
        {
            blockSelected = true;
        }
    }

    private void OnMouseUp()
    {
        if (blockSelected == true)
        {
            blockSelected = false;
        }
    }

    //Snapping the block to the cursor when selected
    private void Update()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mouse);

        if (blockSelected == true && shiftedScreens == false)
        {
            this.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
        }
        else
        {
            return;
        }

        if (shiftedScreens == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wordBlockSprite;
        }
    }

    //Cosmetic IEnumerator for sliding the blocks out of the dispenser
    IEnumerator blockSlide()
    {
        float i;
        for (i = this.transform.position.y; i < outLength; i = (i + 0.1f))
        {
            this.transform.position = new Vector3(this.transform.position.x, i, this.transform.position.z);
            yield return new WaitForSeconds(0);
        }

        this.GetComponent<SpriteRenderer>().sortingOrder = 7;
        this.GetComponentInChildren<MeshRenderer>().sortingOrder = 8;
    }
}
