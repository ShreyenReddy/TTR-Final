using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Color = System.Drawing.Color;

public class TrainCarColour : MonoBehaviour
{
    public int TrainCarsAmt;
    public TMP_Text TrainTokensTxt;
    public Button TrainCarSlot;
    public GameObject RedTC;
    public GameObject BlueTC;
    public GameObject GreenTC;
    public GameObject YellowTC;
    public GameObject BlackTC;


    void Start()
    {
        TrainCarsAmt = 45;
        TrainTokensTxt = GameObject.Find("TrainTokensTxt").GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        StartCoroutine(HideandShow(2f));
        
    }

    IEnumerator HideandShow(float delay)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(10);
            RedTC.SetActive(false);
            BlueTC.SetActive(false);
            GreenTC.SetActive(false);
            YellowTC.SetActive(false);
            BlackTC.SetActive(false);
            
        }
    }
    
    public void OnRedButtonClick()
    {

        {
            
            TrainTokensTxt.text = "" + TrainCarsAmt;
            ColorBlock cb = TrainCarSlot.colors;
            cb.normalColor = UnityEngine.Color.red;
            cb.highlightedColor = UnityEngine.Color.red;
            cb.pressedColor = UnityEngine.Color.red;
            TrainCarSlot.colors = cb;
            TrainCarsAmt = TrainCarsAmt- 1;
        }
        
    }
    
    public void OnBlueButtonClick()
    {
        
        {
            ColorBlock cb = TrainCarSlot.colors;
            cb.normalColor = UnityEngine.Color.blue;
            cb.highlightedColor = UnityEngine.Color.blue;
            cb.pressedColor = UnityEngine.Color.blue;
            TrainCarSlot.colors = cb;
            
        }
    }
    
    public void OnGreenButtonClick()
    {
        
        {
            ColorBlock cb = TrainCarSlot.colors;
            cb.normalColor = UnityEngine.Color.green;
            cb.highlightedColor = UnityEngine.Color.green;
            cb.pressedColor = UnityEngine.Color.green;
            TrainCarSlot.colors = cb;
            
        }
    }
    public void OnYellowButtonClick()
    {
        
        {
            ColorBlock cb = TrainCarSlot.colors;
            cb.normalColor = UnityEngine.Color.yellow;
            cb.highlightedColor = UnityEngine.Color.yellow;
            cb.pressedColor = UnityEngine.Color.yellow;
            TrainCarSlot.colors = cb;
            
        }
    }
    public void OnBlackButtonClick()
    {
        
        {
            ColorBlock cb = TrainCarSlot.colors;
            cb.normalColor = UnityEngine.Color.black;
            cb.highlightedColor = UnityEngine.Color.black;
            cb.pressedColor = UnityEngine.Color.black;
            TrainCarSlot.colors = cb;
            
        }
    }


    

   
}
