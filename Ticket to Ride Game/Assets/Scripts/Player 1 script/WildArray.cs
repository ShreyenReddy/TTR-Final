using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WildArray : MonoBehaviour
{
    public List<CardScript> player1WildCards = new List<CardScript>(); // List for player 1's wild cards
    public List<CardScript> player2WildCards = new List<CardScript>(); // List for player 2's wild cards

    public TextMeshProUGUI player1CardCountText; // Reference to the text for player 1's cards 
    public TextMeshProUGUI player2CardCountText; // Reference to the text for player 2's cards 

    // Start is called before the first frame update
    void Start()
    {
        UpdateCardCount(player1CardCountText, player1WildCards); // Update the card count for player 1
        UpdateCardCount(player2CardCountText, player2WildCards); // Update the card count for player 2
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method to add a card to the wild array of the specific player
    public void AddCard(CardScript card, int playerIndex)
    {
        if (playerIndex == 0)
        {
            player1WildCards.Add(card); // Adds the card to player 1's wild card list
            UpdateCardCount(player1CardCountText, player1WildCards); // Update the card count for player 1
        }
        else if (playerIndex == 1)
        {
            player2WildCards.Add(card); // Adds the card to player 2's wild card list
            UpdateCardCount(player2CardCountText, player2WildCards); // Update the card count for player 2
        }
    }

    // Method to update the card count text 
    private void UpdateCardCount(TextMeshProUGUI cardCountText, List<CardScript> cards)
    {
        int cardCount = cards.Count; // Get the card count from the wild card list
        cardCountText.text = cardCount.ToString(); // Update the text 
    }
}
