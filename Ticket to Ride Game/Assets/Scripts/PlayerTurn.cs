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
        EnablePlayer(0); // Enable only player1 at the start
        UpdateContinueButtonVisibility();
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

            // Use the random card for further processing
            if (randomCard != null)
            {
                string cardTypeName = randomCard.cardType.ToString();
                Debug.Log(cardTypeName + " card drawn");

                // Check the active state of the panel
               
                    if (cardTypeName == "green")
                    {
                        green.AddCard(randomCard); // Add the card to the green array
                    }
                    else if (cardTypeName == "blue")
                    {
                        blue.AddCard(randomCard); // Add the card to the blue array
                    }
                    else if (cardTypeName == "wildcard")
                    {
                        wild.AddCard(randomCard); // Add the card to the wild array
                    }
                    else if (cardTypeName == "orange")
                    {
                        orange.AddCard(randomCard); // Add the card to the orange array
                    }
                    else if (cardTypeName == "red")
                    {
                        red.AddCard(randomCard); // Add the card to the red array
                    }
                    else if (cardTypeName == "pink")
                    {
                        pink.AddCard(randomCard); // Add the card to the pink array
                    }
                
            }
        }

        UpdateContinueButtonVisibility();
        Debug.Log("Card Drawn");
    }

    // Method to retrieve a random card from the cards array
    public CardScript GetRandomCard()
    {
        if (cards.Length > 0)
        {
            int randomIndex = Random.Range(0, cards.Length);
            CardScript randomCard = cards[randomIndex];

            // Remove the selected card from the array
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
    private void EnableContinueButton()
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
                totalClicks = 2; // Treat wild card as 2 clicks
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

            // Remove the card from itemSlots
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

            // Add the card to the corresponding array based on its type
            if (cardTypeName == "green")
            {
                green.AddCard(clickedCard); // Add the card to the green array
            }
            else if (cardTypeName == "blue")
            {
                blue.AddCard(clickedCard); // Add the card to the blue array
            }
            else if (cardTypeName == "wildcard")
            {
                wild.AddCard(clickedCard); // Add the card to the wild array
            }
            else if (cardTypeName == "orange")
            {
                orange.AddCard(clickedCard); // Add the card to the orange array
            }
            else if (cardTypeName == "red")
            {
                red.AddCard(clickedCard); // Add the card to the red array
            }
            else if (cardTypeName == "pink")
            {
                pink.AddCard(clickedCard); // Add the card to the pink array
            }
        }
    }

}