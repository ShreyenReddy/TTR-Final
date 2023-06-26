using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class OnDragGreen : MonoBehaviour
{
    public Rigidbody2D BlueTrainCard;
    public Rigidbody2D GreenTrainCard;
    public Rigidbody2D OrangeTrainCard;
    public Rigidbody2D PinkTrainCard;
    public Rigidbody2D RedTrainCard;
    public Rigidbody2D WildCard;
    public GreenArray greenArray;
    public TextMeshProUGUI GreenIntTxt;
    public Vector2 StartPos;
    public GameObject BlueCard;

    Vector2 difference = Vector2.zero;

    private void Start()
    {
        BlueCard = gameObject;
        StartPos = BlueCard.transform.position;
    }

    private void OnMouseDown()
    {
        difference= (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;

    }

    private void OnMouseUp()
    {
        BlueCard.transform.position = StartPos;
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
        
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("CardMinus"))
        {
            greenArray.GreenCardsInt --;
            GreenIntTxt.text = greenArray.GreenCardsInt.ToString();

        }
        
    }
}
