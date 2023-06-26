using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlueArray : MonoBehaviour
{
    public int BlueCardsInt;
    public List<CardScript> player1BlueCards = new List<CardScript>(); // List for player 1's blue cards
    public List<CardScript> player2BlueCards = new List<CardScript>(); // List for player 2's blue cards

    public TextMeshProUGUI player1CardCountText; // Reference to the text for player 1's cards 
    public TextMeshProUGUI player2CardCountText;// Reference to the text for player 2's cards 

    // Start is called before the first frame update
    void Start()
    {
        UpdateCardCount(player1CardCountText, player1BlueCards); // Update the card count for player 1
        UpdateCardCount(player2CardCountText, player2BlueCards); // Update the card count for player 2
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(BlueCardsInt);

    }

    // Method to add a card to the blue list of the specific player
    public void AddCard(CardScript card, int playerIndex)
    {
        if (playerIndex == 0)
        {
            player1BlueCards.Add(card); // Adds the card to player 1's blue card list
            UpdateCardCount(player1CardCountText, player1BlueCards); // Update the card count for player 1
        }
        else if (playerIndex == 1)
        {
            player2BlueCards.Add(card); // Adds the card to player 2's blue card list
            UpdateCardCount(player2CardCountText, player2BlueCards); // Update the card count for player 2
        }
    }

    // Method to update the card count text 
    private void UpdateCardCount(TextMeshProUGUI cardCountText, List<CardScript> cards)
    {
        BlueCardsInt = cards.Count; // Get the card count from the blue card list
        cardCountText.text = BlueCardsInt.ToString(); // Update the text 
    }
}

