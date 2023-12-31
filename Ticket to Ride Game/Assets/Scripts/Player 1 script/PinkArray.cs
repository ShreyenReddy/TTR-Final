using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinkArray : MonoBehaviour
{
    public int PinkCardInt;
    public List<CardScript> player1PinkCards = new List<CardScript>(); // List for player 1's pink cards
    public List<CardScript> player2PinkCards = new List<CardScript>(); // List for player 2's pink cards

    public TextMeshProUGUI player1CardCountText; // Reference to the text for player 1's cards 
    public TextMeshProUGUI player2CardCountText; // Reference to the text for player 2's cards 

    // Start is called before the first frame update
    void Start()
    {
        UpdateCardCount(player1CardCountText, player1PinkCards); // Update the card count for player 1
        UpdateCardCount(player2CardCountText, player2PinkCards); // Update the card count for player 2
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method to add a card to the pink list of the specific player
    public void AddCard(CardScript card, int playerIndex)
    {
        if (playerIndex == 0)
        {
            player1PinkCards.Add(card); // Adds the card to player 1's pink card list
            UpdateCardCount(player1CardCountText, player1PinkCards); // Update the card count for player 1
        }
        else if (playerIndex == 1)
        {
            player2PinkCards.Add(card); // Adds the card to player 2's pink card list
            UpdateCardCount(player2CardCountText, player2PinkCards); // Update the card count for player 2
        }
    }

    // Method to update the card count text 
    private void UpdateCardCount(TextMeshProUGUI cardCountText, List<CardScript> cards)
    {
        PinkCardInt = cards.Count; // Get the card count from the pink card list
        cardCountText.text = PinkCardInt.ToString(); // Update the text 
    }
}
