using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Script/Train Card colour")]
public class CardScript : ScriptableObject
{
    public string CardColourName;
    public Sprite CardImage;
    public CardType cardType;
    public enum CardType
    {
        red,
        blue,
        orange,
        yellow,
        black,
        green,
        pink,
        white,
        wildcard,

    }
}
