using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class DestinationCardManager : ScriptableObject
{
   public  string Destination;
   public int Score;
   public TMP_Text Destinationtxt;
   public TMP_Text ScoreTxt;
   public Button I;
   

}

