using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PTwoMovement : MonoBehaviour
{
    public int Player2Score;
    public GameObject PlayerPiece;
    public GameObject[] Blocks;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Player2Score > 0)
        {
            Target = Blocks[Player2Score - 1].transform;
        }
        else
        {
            Target = Target = Blocks[0].transform;
        }
        PlayerPiece.transform.position = Vector2.MoveTowards(PlayerPiece.transform.position, Target.position, 0.5f * Time.deltaTime);
    }
}
