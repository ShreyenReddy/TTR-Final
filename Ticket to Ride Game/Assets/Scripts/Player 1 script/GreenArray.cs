using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GreenArray   : MonoBehaviour
{
    public List<CardScript> player1GreenCards = new List<CardScript>(); // List for player 1's green cards
    public List<CardScript> player2GreenCards = new List<CardScript>(); // List for player 2's green cards

    public TextMeshProUGUI player1CardCountText; // Reference to the text for player 1's cards 
    public TextMeshProUGUI player2CardCountText; // Reference to the text for player 2's cards 

    // Start is called before the first frame update
    void Start()
    {
        UpdateCardCount(player1CardCountText, player1GreenCards); // Update the card count for player 1
        UpdateCardCount(player2CardCountText, player2GreenCards); // Update the card count for player 2
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method to add a card to the green list of the specific player
    public void AddCard(CardScript card, int playerIndex)
    {
        if (playerIndex == 0)
        {
            player1GreenCards.Add(card); // Adds the card to player 1's green card list
            UpdateCardCount(player1CardCountText, player1GreenCards); // Update the card count for player 1
        }
        else if (playerIndex == 1)
        {
            player2GreenCards.Add(card); // Adds the card to player 2's green card list
            UpdateCardCount(player2CardCountText, player2GreenCards); // Update the card count for player 2
        }
    }

    // Method to update the card count text 
    private void UpdateCardCount(TextMeshProUGUI cardCountText, List<CardScript> cards)
    {
        int cardCount = cards.Count; // Get the card count from the green card list
        cardCountText.text = cardCount.ToString(); // Update the text 
    }
}

