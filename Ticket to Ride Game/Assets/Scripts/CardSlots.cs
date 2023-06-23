using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlots : MonoBehaviour
{
    public GameObject GameSlot;
    public CardScript[] itemSlots = new CardScript[5]; // Array for Cards
    public Image[] slotImages = new Image[5]; // Array for Card Images

    private int[] clickCounts = new int[5]; // Array to store click counts

    // Start is called before the first frame update
    void Start()
    {
        //Uses the DrawScript to re-add cards into the CardSlots
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i] == null)
            {
                //itemSlots[i] = DrawScript.Draw();
            }

            // Used for setting the cards image
            if (itemSlots[i] != null)
            {
                slotImages[i] = GameSlot.transform.GetChild(i).GetComponent<Image>();
                slotImages[i].sprite = itemSlots[i].CardImage;

                string enumType = itemSlots[i].cardType.ToString();
                Debug.Log("Enum Type at index " + i + ": " + enumType);
            }
        }
    }
}
