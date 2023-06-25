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
    private int[,] TrainCarsAmt = new int [6, 5];
    public int RedTrainCarAmt;
    public int BlueTrainCarAmt;
    public int GreenTrainCarAmt;
    public int YellowTrainCarAmt;
    public int BlackTrainCarAmt;

    public TMP_Text TrainTokensTxt;
    public Button TrainCarSlot;
    public GameObject RedTC;
    public GameObject BlueTC;
    public GameObject GreenTC;
    public GameObject YellowTC;
    public GameObject BlackTC;

    public GameObject LastRoundPanelAppear;






    void Start()
    {
        TrainCarsAmt[1, 1] = RedTrainCarAmt = 45;
        TrainCarsAmt[2, 1] = BlueTrainCarAmt = 45;
        TrainCarsAmt[3, 1] = GreenTrainCarAmt = 45;
        TrainCarsAmt[4, 1] = YellowTrainCarAmt = 45;
        TrainCarsAmt[5, 1] = BlackTrainCarAmt = 45;

    }

    void Awake()
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

    public void AmtOfRedTrainsButton()
    {
        if ((RedTrainCarAmt <= 45))
        {
            RedTrainCarAmt--;
            TrainTokensTxt = GameObject.Find("TrainTokensTxt").GetComponent<TextMeshProUGUI>();
            TrainTokensTxt.text = "" + RedTrainCarAmt;
        }

    }

    public void OnRedButtonClick()
    {
        {
            ColorBlock cb = TrainCarSlot.colors;
            cb.normalColor = UnityEngine.Color.red;
            cb.highlightedColor = UnityEngine.Color.red;
            cb.pressedColor = UnityEngine.Color.red;
            TrainCarSlot.colors = cb;
        }
    }

    public void AmtOfBlueTrainsButton()
    {
        if ((BlueTrainCarAmt <= 45))
        {
            BlueTrainCarAmt--;
            TrainTokensTxt = GameObject.Find("TrainTokensTxt").GetComponent<TextMeshProUGUI>();
            TrainTokensTxt.text = "" + BlueTrainCarAmt;
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

    public void AmtOfGreenTrainsButton()
    {
        if ((GreenTrainCarAmt <= 45))
        {
            GreenTrainCarAmt--;
            TrainTokensTxt = GameObject.Find("TrainTokensTxt").GetComponent<TextMeshProUGUI>();
            TrainTokensTxt.text = "" + GreenTrainCarAmt;
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

    public void AmtOfYellowTrainsButton()
    {
        if ((YellowTrainCarAmt <= 45))
        {
            YellowTrainCarAmt--;
            TrainTokensTxt = GameObject.Find("TrainTokensTxt").GetComponent<TextMeshProUGUI>();
            TrainTokensTxt.text = "" + YellowTrainCarAmt;
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

    public void AmtOfBlackTrainsButton()
    {
        if ((BlackTrainCarAmt <= 45))
        {
            BlackTrainCarAmt--;
            TrainTokensTxt = GameObject.Find("TrainTokensTxt").GetComponent<TextMeshProUGUI>();
            TrainTokensTxt.text = "" + BlackTrainCarAmt;
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

    public void LastRoundPanel()
    {
        if (RedTrainCarAmt <= 2 )
        {
            StartCoroutine(LastPanelActivate(2f));

        }

        if (BlueTrainCarAmt <= 2)
        {
            StartCoroutine(LastPanelActivate(2f));
        }
    }
    IEnumerator LastPanelActivate(float delay)
    {
        while (true)
        {
            LastRoundPanelAppear.SetActive(true);
            yield return new WaitForSecondsRealtime(5);
            LastRoundPanelAppear.SetActive(false);

        }
    }







}

