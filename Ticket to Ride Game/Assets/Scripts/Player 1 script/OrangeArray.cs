using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrangeArray : MonoBehaviour
{
    public int OrangeCardsInt;
    public List<CardScript> player1OrangeCards = new List<CardScript>(); // List for player 1's orange cards
    public List<CardScript> player2OrangeCards = new List<CardScript>(); // List for player 2's orange cards

    public TextMeshProUGUI player1CardCountText; // Reference to the text for player 1's cards 
    public TextMeshProUGUI player2CardCountText; // Reference to the text for player 2's cards 

    // Start is called before the first frame update
    void Start()
    {
        UpdateCardCount(player1CardCountText, player1OrangeCards); // Update the card count for player 1
        UpdateCardCount(player2CardCountText, player2OrangeCards); // Update the card count for player 2
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method to add a card to the orange list of the specific player
    public void AddCard(CardScript card, int playerIndex)
    {
        if (playerIndex == 0)
        {
            player1OrangeCards.Add(card); // Adds the card to player 1's orange card list
            UpdateCardCount(player1CardCountText, player1OrangeCards); // Update the card count for player 1
        }
        else if (playerIndex == 1)
        {
            player2OrangeCards.Add(card); // Adds the card to player 2's orange card list
            UpdateCardCount(player2CardCountText, player2OrangeCards); // Update the card count for player 2
        }
    }

    // Method to update the card count text 
    private void UpdateCardCount(TextMeshProUGUI cardCountText, List<CardScript> cards)
    {
        OrangeCardsInt = cards.Count; // Get the card count from the orange card list
        cardCountText.text = OrangeCardsInt.ToString(); // Update the text 
    }
}

