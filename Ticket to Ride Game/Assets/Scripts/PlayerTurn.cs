using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurn : MonoBehaviour
{
    public Button drawButton;
    public Button continueButton;
    public GameObject panel;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player5;
    
    public CardSlots gameSlotManager;
    public CardSlots itemSlots;
    private int totalClicks;
    private bool isCardSlotsEnabled = true;
    private bool isContinueButtonVisible = false;
    private int[] clickCounts;

    private WaitForSeconds panelDisplayTime = new WaitForSeconds(5f);

    private void Start()
    {
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
        }

        UpdateContinueButtonVisibility();
        Debug.Log("Card Drawn");
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
        totalClicks = 0;
        EnableCardSlots();
        DisableContinueButton();

        StartCoroutine(OpenPanelForDuration());
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

        player1.SetActive(!player1.activeSelf);
        player2.SetActive(!player2.activeSelf);
        player3.SetActive(!player3.activeSelf);
        player4.SetActive(!player4.activeSelf);
        player5.SetActive(!player5.activeSelf);
            
        

        UpdateContinueButtonVisibility();
    }

    // Method called when a card is clicked in the CardSlots
    public void DrawCard(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < gameSlotManager.itemSlots.Length && totalClicks < 2)
        {
            CardScript clickedCard = gameSlotManager.itemSlots[slotIndex];

            string cardTypeName = clickedCard.cardType.ToString();
            Debug.Log(cardTypeName + " card drawn");

            string enumValueAsString = clickedCard.cardType.ToString();
            Debug.Log("Clicked card enum value: " + enumValueAsString);

            if (enumValueAsString == "wildcard")
            {
                totalClicks = 2; // Treat wildcard as 2 clicks
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
        }
    }

    // Method called when a button is clicked
    public void ButtonClicked(int buttonIndex)
    {
        clickCounts[buttonIndex]++;

        if (clickCounts[buttonIndex] == 2)
        {
            DisableCardSlots();
        }
    }
}