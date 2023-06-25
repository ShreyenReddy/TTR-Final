using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PTwoMovement pTwoMovement;
    public GameObject POneWinPnl;
    public GameObject PTwoWinPnl;
    public int P1NumberOfTracksLeft;
    public int P2NumberOfTracksLeft;
    public bool GameShouldEnd = false;
    public GameObject P1ContentPnl;
    public GameObject P2ContentPnl;
    public Transform[] P1ChosenCards;
    public Transform[] P2ChosenCards;
    // Start is called before the first frame update
    void Start()
    {
        P1NumberOfTracksLeft = 45;
        P2NumberOfTracksLeft = 45;

    }

    // Update is called once per frame
    void Update()
    {
        if (P1NumberOfTracksLeft == 0 || P1NumberOfTracksLeft == 1 || P1NumberOfTracksLeft == 2)
        {
            GameShouldEnd = true;
        }
        if (P2NumberOfTracksLeft == 0 || P2NumberOfTracksLeft == 1 || P2NumberOfTracksLeft == 2)
        {
            GameShouldEnd = true;
        }
    }
    
    public void EndOfGame()
    {
        P1ChosenCards = P1ContentPnl.GetComponentsInChildren<Transform>();
        foreach (Transform childTransform in P1ChosenCards)
        {
            DesCardScript desCardScript = childTransform.gameObject.GetComponent<DesCardScript>();
            if (desCardScript != null)
            {
                int subtractInt = desCardScript.AmountToAdd;
                playerMovement.PlayerScore -= subtractInt;
            }
        }
        P2ChosenCards = P2ContentPnl.GetComponentsInChildren<Transform>();
        foreach (Transform childTransform in P2ChosenCards)
        {
            DesCardScript desCardScript = childTransform.gameObject.GetComponent<DesCardScript>();
            if (desCardScript != null)
            {
                int subtractInt = desCardScript.AmountToAdd;
                pTwoMovement.Player2Score -= subtractInt;
            }
        }
        if (playerMovement.PlayerScore < pTwoMovement.Player2Score)
        {
            POneWinPnl.SetActive(true);
        }
        else
        {
            PTwoWinPnl.SetActive(true);
        }
    }
}
