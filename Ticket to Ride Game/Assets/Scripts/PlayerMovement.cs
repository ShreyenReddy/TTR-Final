using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int PlayerScore;
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
        if (PlayerScore > 0)
        {
            Target = Blocks[PlayerScore - 1].transform;
        }
        else
        {
            Target = Target = Blocks[0].transform;
        }
        PlayerPiece.transform.position = Vector2.MoveTowards(PlayerPiece.transform.position, Target.position, 0.5f * Time.deltaTime);
    }
}
