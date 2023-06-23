using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DragItems : MonoBehaviour
{
    public Rigidbody2D player;
    public Rigidbody2D board;
    public GameObject ReturnPlayer;
    Vector2 difference = Vector2.zero;

    private void OnMouseDown()
    {
        difference= (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;

    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Border"))
        {
            ReturnPlayer.SetActive(true);
           
            Debug.Log("Player is out of bounds");
        }
        
    }

    
}
