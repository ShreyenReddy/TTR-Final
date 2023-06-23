using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesCardScript : MonoBehaviour
{
    public PlayerScore playerScore;
    public PlayerMovement playerMovement;
    public int AmountToAdd;
    public GameObject Card;
    public GameObject[] DestinationCards;
    public bool[] IsUsed;
    public int NumberOfChildren;
    public GameObject DrawPanel;
    public GameObject ContentPanel;
    public Transform[] DrawPanelChildren;

    // Start is called before the first frame update
    void Start()
    {
        DrawPanel = GameObject.Find("DestinationDraw");
        ContentPanel = GameObject.Find("Content");
        playerMovement = GameObject.Find("TTR Board").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void OnCardClick()
    {
        DrawPanelChildren = DrawPanel.GetComponentsInChildren<Transform>();
        Card = gameObject;
        if (Card.transform.parent.name == "Content")
        {
            playerMovement.PlayerScore = playerMovement.PlayerScore + AmountToAdd;
            Destroy(Card);
        }    
        else
        {
            Instantiate(Card, ContentPanel.transform);
            DrawPanel.transform.position = new Vector2(20, 0);
            foreach (Transform f in DrawPanelChildren)
            {
                if (f.name != "DestinationDraw")
                {
                    Destroy(f.gameObject);
                }
            }
        }
    }

    public void OnDrawClick()
    {
        NumberOfChildren = DrawPanel.transform.childCount;
        DrawPanel.transform.position = new Vector2(0.803427f, -0.7206753f);
        for (int i = NumberOfChildren; i < 3; i++)
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Range(0, 30);
            }
            while (IsUsed[randomNumber]);

            Instantiate(DestinationCards[randomNumber], DrawPanel.transform);
            IsUsed[randomNumber] = true;
        }
    }
}
