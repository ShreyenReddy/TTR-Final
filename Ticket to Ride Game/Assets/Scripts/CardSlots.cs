using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CardSlots : MonoBehaviour
{
    public GameObject GameSlot;
    public CardScript[] itemSlots = new CardScript[4]; // Array for Cards
    public Image[] slotImages = new Image[4]; // Array for Card Images
    public PlayerTurn playerTurns;

    private int[] clickCounts = new int[4]; // Array to store click counts

    private void Start()
    {
        playerTurns = GetComponent<PlayerTurn>();

        if (itemSlots.All(slot => slot == null))
        {
            FillItemSlotsFromCards();
        }

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i] != null)
            {
                slotImages[i] = GameSlot.transform.GetChild(i).GetComponent<Image>();
                slotImages[i].sprite = itemSlots[i].CardImage;

                string enumType = itemSlots[i].cardType.ToString();
                Debug.Log("Enum Type at index " + i + ": " + enumType);
            }
        }

        StartCoroutine(CheckItemSlots());
    }

    private IEnumerator CheckItemSlots()
    {
        while (true)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i] == null)
                {
                    AddRandomCard(i);
                }
            }
            yield return null;
        }
    }

    private void FillItemSlotsFromCards()
    {
        CardScript[] cards = playerTurns.cards;

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (cards.Length > 0)
            {
                itemSlots[i] = GetRandomCardFromCards(ref cards);
            }
            else
            {
                Debug.LogWarning("No more cards available to fill itemSlots array.");
                break;
            }
        }
    }

    private CardScript GetRandomCardFromCards(ref CardScript[] cards)
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

    private void AddRandomCard(int index)
    {
        CardScript[] cards = playerTurns.cards;

        if (cards.Length > 0)
        {
            itemSlots[index] = GetRandomCardFromCards(ref cards);
            slotImages[index].sprite = itemSlots[index].CardImage;
        }
        else
        {
            Debug.LogWarning("No more cards available to add to itemSlots array.");
        }
    }

    public void RemoveCard(CardScript card)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i] == card)
            {
                itemSlots[i] = null;
                slotImages[i].sprite = null; // Clear the slot image
                return;
            }
        }
    }


}



