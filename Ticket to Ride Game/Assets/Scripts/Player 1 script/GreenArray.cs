using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GreenArray   : MonoBehaviour
{
    List<CardScript> green = new List<CardScript>();

    public TextMeshProUGUI cardCountText; // Reference to the TextMeshProUGUI component displaying the card count

    // Start is called before the first frame update
    void Start()
    {
        UpdateCardCount();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method to add a card to the green array
    public void AddCard(CardScript card)
    {
        green.Add(card); // Add the card to the list

        UpdateCardCount(); // Update the card count after adding a card
    }

    // Method to update the card count text
    private void UpdateCardCount()
    {
        int cardCount = green.Count; // Get the card count from the green list
        cardCountText.text = cardCount.ToString(); // Update the text component
    }
}

