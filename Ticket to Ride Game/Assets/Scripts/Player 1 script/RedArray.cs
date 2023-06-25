using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RedArray : MonoBehaviour
{
    public List<CardScript> player1RedCards = new List<CardScript>(); // List for player 1's red cards
    public List<CardScript> player2RedCards = new List<CardScript>(); // List for player 2's red cards

    public TextMeshProUGUI player1CardCountText; // Reference to the text for player 1's cards 
    public TextMeshProUGUI player2CardCountText; // Reference to the text for player 2's cards 
    // Start is called before the first frame update
    void Start()
    {
        UpdateCardCount(player1CardCountText, player1RedCards); // Update the card count for player 1
        UpdateCardCount(player2CardCountText, player2RedCards); // Update the card count for player 2
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method to add a card to the red list of the specific player
    public void AddCard(CardScript card, int playerIndex)
    {
        if (playerIndex == 0)
        {
            player1RedCards.Add(card); // Adds the card to player 1's red card list
            UpdateCardCount(player1CardCountText, player1RedCards); // Update the card count for player 1
        }
        else if (playerIndex == 1)
        {
            player2RedCards.Add(card); // Adds the card to player 1's red card list
            UpdateCardCount(player2CardCountText, player2RedCards); // Update the card count for player 2
        }
    }

    // Method to update the card count text 
    private void UpdateCardCount(TextMeshProUGUI cardCountText, List<CardScript> cards)
    {
        int cardCount = cards.Count; // Get the card count from the red card list
        cardCountText.text = cardCount.ToString(); // Update the text 
    }
}
