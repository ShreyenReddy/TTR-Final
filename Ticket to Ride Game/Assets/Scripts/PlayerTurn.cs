using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurn : MonoBehaviour
{
    public Button drawButton;
    public Button continueButton;
    public GameObject panel;
    public GameObject[] players;
    public CardSlots gameSlotManager;
    public CardSlots itemSlots;
    public CardScript[] cards;
    public GreenArray green;
    public BlueArray blue;
    public WildArray wild;
    public OrangeArray orange;
    public RedArray red;
    public PinkArray pink;

    private int currentPlayerIndex = 0;
    private int totalClicks;
    private bool isCardSlotsEnabled = true;
    private bool isContinueButtonVisible = false;

    private WaitForSeconds panelDisplayTime = new WaitForSeconds(5f);
    public GameObject DCardsPnl1;
    public GameObject DCardsPnl2;
    public Button DrawBtn1;
    public Button DrawBtn2;
    public EndGame endGame;

    private void Start()
    {
        EnablePlayer(0); // Enables the player 1 panel at the start 
        UpdateContinueButtonVisibility();

        // Adds four random cards to each player
        for (int i = 0; i < players.Length; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                AddRandomCardToPlayer(i);
            }
        }
    }

    // Method called when the draw button is clicked
    public void DrawButtonClick()
    {
        if (totalClicks < 2)
        {
            totalClicks++;

            if (totalClicks >= 2)
            {
                DisableCardSlots();
                EnableContinueButton();
            }

            // Get a random card from the cards array
            CardScript randomCard = GetRandomCard();

            if (randomCard != null)
            {
                string cardTypeName = randomCard.cardType.ToString();
                Debug.Log(cardTypeName + " card drawn");

                

                if (cardTypeName == "green")
                {
                    green.AddCard(randomCard, currentPlayerIndex); // Add the card to the green list
                }
                else if (cardTypeName == "blue")
                {
                    blue.AddCard(randomCard, currentPlayerIndex); // Add the card to the blue list
                }
                else if (cardTypeName == "wildcard")
                {
                    wild.AddCard(randomCard, currentPlayerIndex); // Add the card to the wild list
                }
                else if (cardTypeName == "orange")
                {
                    orange.AddCard(randomCard, currentPlayerIndex); // Add the card to the orange list
                }
                else if (cardTypeName == "red")
                {
                    red.AddCard(randomCard, currentPlayerIndex); // Add the card to the red list
                }
                else if (cardTypeName == "pink")
                {
                    pink.AddCard(randomCard, currentPlayerIndex); // Add the card to the pink list
                }
            }
        }

        UpdateContinueButtonVisibility();
        Debug.Log("Card Drawn");
    }

    // Method to get a random card from the cards array
    public CardScript GetRandomCard()
    {
        if (cards.Length > 0)
        {
            int randomIndex = Random.Range(0, cards.Length);
            CardScript randomCard = cards[randomIndex];

            // Removes the random card from the array and adds it into the list
            List<CardScript> remainingCards = new List<CardScript>(cards);
            remainingCards.RemoveAt(randomIndex);
            cards = remainingCards.ToArray();

            return randomCard;
        }

        return null;
    }

    // Method updates the visibility of the continue button
    private void UpdateContinueButtonVisibility()
    {
        bool areCardSlotsDisabled = !isCardSlotsEnabled;

        if (areCardSlotsDisabled)
        {
            EnableContinueButton();
        }
        else
        {
            DisableContinueButton();
        }
    }

    // Enable the continue button and make it visible
    public void EnableContinueButton()
    {
        continueButton.interactable = true;
        if (!isContinueButtonVisible)
        {
            isContinueButtonVisible = true;
            continueButton.gameObject.SetActive(true);
        }
    }

    // Disable the continue button and make it invisible
    private void DisableContinueButton()
    {
        continueButton.interactable = false;
        if (isContinueButtonVisible)
        {
            isContinueButtonVisible = false;
            continueButton.gameObject.SetActive(false);
        }
    }

    // Method called when the continue button is clicked
    public void ContinueButtonClick()
    {
        if (endGame.GameShouldEnd && currentPlayerIndex == 1)
        {
            endGame.EndOfGame();
        }
        else
        {
            totalClicks = 0;
            EnableCardSlots();
            DisableContinueButton();

            StartCoroutine(OpenPanelForDuration());

            // Disable current player
            DisablePlayer(currentPlayerIndex);

            // Move to the next player
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
            /*if (currentPlayerIndex == 0)
            {
                DCardsPnl1.SetActive(true);
                DCardsPnl2.SetActive(false);
                DrawBtn1.interactable = true;
            }
            if (currentPlayerIndex == 1)
            {
                DCardsPnl1.SetActive(false);
                DCardsPnl2.SetActive(true);
                DrawBtn2.interactable = true;
            }*/
        }


        // Enable the next player
        EnablePlayer(currentPlayerIndex);
    }

    // Enable the CardSlots
    private void EnableCardSlots()
    {
        isCardSlotsEnabled = true;
        foreach (Button button in itemSlots.GetComponentsInChildren<Button>())
        {
            button.interactable = true;
        }
    }

    // Disable the CardSlots
    private void DisableCardSlots()
    {
        isCardSlotsEnabled = false;
        foreach (Button button in itemSlots.GetComponentsInChildren<Button>())
        {
            button.interactable = false;
        }
    }

    // This Coroutine opens up a panel for 5 seconds
    private IEnumerator OpenPanelForDuration()
    {
        panel.SetActive(true);

        yield return panelDisplayTime;

        panel.SetActive(false);

        UpdateContinueButtonVisibility();
    }

    // Enable a specific player by index
    private void EnablePlayer(int playerIndex)
    {
        if (playerIndex >= 0 && playerIndex < players.Length)
        {
            players[playerIndex].SetActive(true);
        }
    }

    // Disable a specific player by index
    private void DisablePlayer(int playerIndex)
    {
        if (playerIndex >= 0 && playerIndex < players.Length)
        {
            players[playerIndex].SetActive(false);
        }
    }

    // Method called when a card is clicked in the CardSlots
    public void DrawCard(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < gameSlotManager.itemSlots.Length && totalClicks < 2)
        {
            CardScript clickedCard = gameSlotManager.itemSlots[slotIndex];

            string cardTypeName = clickedCard.cardType.ToString();
            Debug.Log(cardTypeName + " card drawn");

            if (cardTypeName == "wildcard")
            {
                totalClicks = 2; // Treats the wild card as 2 clicks
            }
            else
            {
                totalClicks++;
            }

            if (totalClicks >= 2)
            {
                DisableCardSlots();
                EnableContinueButton();
            }

            // Remove the card from itemSlots array
            gameSlotManager.RemoveCard(clickedCard);

            // Remove the corresponding scriptable object from the Cards array
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] == clickedCard)
                {
                    // Remove the card from the array
                    List<CardScript> remainingCards = new List<CardScript>(cards);
                    remainingCards.RemoveAt(i);
                    cards = remainingCards.ToArray();
                    break;
                }
            }

            // Add the card to the corresponding list based on its enum in the Cardtype
            if (cardTypeName == "green")
            {
                green.AddCard(clickedCard, currentPlayerIndex); // Add the card to the green list
            }
            else if (cardTypeName == "blue")
            {
                blue.AddCard(clickedCard, currentPlayerIndex); // Add the card to the blue list
            }
            else if (cardTypeName == "wildcard")
            {
                wild.AddCard(clickedCard, currentPlayerIndex); // Add the card to the wild list
            }
            else if (cardTypeName == "orange")
            {
                orange.AddCard(clickedCard, currentPlayerIndex); // Add the card to the orange list
            }
            else if (cardTypeName == "red")
            {
                red.AddCard(clickedCard, currentPlayerIndex); // Add the card to the red list
            }
            else if (cardTypeName == "pink")
            {
                pink.AddCard(clickedCard, currentPlayerIndex); // Add the card to the pink list
            }
        }
    }

    // Method to add a random card to each player
    private void AddRandomCardToPlayer(int playerIndex)
    {
        CardScript randomCard = GetRandomCard();

        if (randomCard != null)
        {
            string cardTypeName = randomCard.cardType.ToString();
            Debug.Log(cardTypeName + " card added to player " + (playerIndex + 1));

            // Add the card to the corresponding list based on its enum in the Cardtype
            if (cardTypeName == "green")
            {
                green.AddCard(randomCard, playerIndex); // Add the card to the green list
            }
            else if (cardTypeName == "blue")
            {
                blue.AddCard(randomCard, playerIndex); // Add the card to the blue list
            }
            else if (cardTypeName == "wildcard")
            {
                wild.AddCard(randomCard, playerIndex); // Add the card to the wild list
            }
            else if (cardTypeName == "orange")
            {
                orange.AddCard(randomCard, playerIndex); // Add the card to the orange list
            }
            else if (cardTypeName == "red")
            {
                red.AddCard(randomCard, playerIndex); // Add the card to the red list
            }
            else if (cardTypeName == "pink")
            {
                pink.AddCard(randomCard, playerIndex); // Add the card to the pink list
            }
        }
    }

}