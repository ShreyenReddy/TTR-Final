using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesCardScript : MonoBehaviour
{
    public PlayerScore playerScore;
    public PlayerMovement playerMovement;
    public PTwoMovement pTwoMovement;
    public int AmountToAdd;
    public GameObject Card;
    public GameObject[] DestinationCards;
    public bool[] IsUsed;
    public int NumberOfChildren;
    public GameObject DrawPanel1;
    public GameObject DrawPanel2;
    public GameObject ContentPanel;
    public GameObject ContentPanel2;
    public Transform[] DrawPanelChildren;
    public Transform[] DrawPanelChildren2;
    public GameObject P2DesPnl;
    public PlayerTurn playerTurn;

    // Start is called before the first frame update
    void Start()
    {
        playerTurn = GameObject.Find("Game Manager").GetComponent<PlayerTurn>();
        DrawPanel1 = GameObject.Find("DestinationDraw");
        DrawPanel2 = GameObject.Find("DestinationDraw2");
        ContentPanel = GameObject.Find("Content");
        ContentPanel2 = GameObject.Find("Content2");
        playerMovement = GameObject.Find("TTR Board").GetComponent<PlayerMovement>();
        pTwoMovement = GameObject.Find("TTR Board").GetComponent<PTwoMovement>();
        P2DesPnl = GameObject.Find("DestinationCardsCanvasP2");
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void OnCardClick()
    {
        if (!P2DesPnl)
        {
            DrawPanelChildren = DrawPanel1.GetComponentsInChildren<Transform>();
            Card = gameObject;
            if (Card.transform.parent.name == "Content")
            {
                playerMovement.PlayerScore = playerMovement.PlayerScore + AmountToAdd;
                Destroy(Card);
            }
            else
            {
                Instantiate(Card, ContentPanel.transform);
                DrawPanel1.transform.position = new Vector2(20, 0);
                foreach (Transform f in DrawPanelChildren)
                {
                    if (f.name != "DestinationDraw")
                    {
                        Destroy(f.gameObject);
                    }
                }

                playerTurn.EnableContinueButton();
            }
        }
        else
        {
            DrawPanelChildren2 = DrawPanel2.GetComponentsInChildren<Transform>();
            Card = gameObject;
            if (Card.transform.parent.name == "Content2")
            {
                pTwoMovement.Player2Score = pTwoMovement.Player2Score + AmountToAdd;
                Destroy(Card);
            }
            else
            {
                Instantiate(Card, ContentPanel2.transform);
                DrawPanel2.transform.position = new Vector2(20, 0);
                foreach (Transform f in DrawPanelChildren2)
                {
                    if (f.name != "DestinationDraw2")
                    {
                        Destroy(f.gameObject);
                    }
                }
                playerTurn.EnableContinueButton();
            }
        }        
    }

    public void OnDrawClick()
    {
        NumberOfChildren = DrawPanel1.transform.childCount;
        DrawPanel1.transform.position = new Vector2(1.9803427f, 0.7206753f);
        for (int i = NumberOfChildren; i < 3; i++)
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Range(0, 30);
            }
            while (IsUsed[randomNumber]);

            Instantiate(DestinationCards[randomNumber], DrawPanel1.transform);
            IsUsed[randomNumber] = true;
        }
    }
}
