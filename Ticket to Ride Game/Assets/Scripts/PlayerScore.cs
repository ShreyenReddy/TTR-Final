using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int Score = 0;
    public TextMeshProUGUI PointsText;
    // Start is called before the first frame update
    void Start()
    {
        PointsText = GameObject.Find("PointsTxt").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        PointsText.text = Score.ToString();
    }
}
