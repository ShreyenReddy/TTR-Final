using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoDesCards : MonoBehaviour
{
    public DesCardScript desCardScript;
    public PTwoMovement pTwoMovement;
    public int AmountToAdd;
    public GameObject Card;
    public int NumberOfChildren;
    public GameObject DrawPanel2;
    public GameObject ContentPanel;
    public Transform[] DrawPanelChildren;

    // Start is called before the first frame update
    void Start()
    {
        DrawPanel2 = GameObject.Find("DestinationDraw2");
        ContentPanel = GameObject.Find("Content2");
        pTwoMovement = GameObject.Find("TTR Board").GetComponent<PTwoMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    public void OnDrawClick()
    {
        Debug.Log("Clicked");
        NumberOfChildren = DrawPanel2.transform.childCount;
        DrawPanel2.transform.position = new Vector2(1.9803427f, 0.7206753f);
        for (int i = NumberOfChildren; i < 3; i++)
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Range(0, 30);
            }
            while (desCardScript.IsUsed[randomNumber]);

            Instantiate(desCardScript.DestinationCards[randomNumber], DrawPanel2.transform);
            desCardScript.IsUsed[randomNumber] = true;
        }
    }
}
