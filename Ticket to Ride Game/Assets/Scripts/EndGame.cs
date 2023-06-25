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
