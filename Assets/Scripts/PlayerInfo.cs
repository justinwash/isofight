using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    // which player is this?
    public int playerNumber;

    // initialize input buttons
    public string horizontalKey;
    public string verticalKey;
    public string punchKey;

    void Start()
    {
        if (playerNumber == 1)
        {
            horizontalKey = "p1HorizontalKey";
            verticalKey = "p1VerticalKey";
            punchKey = "p1PunchKey";
        }

        if (playerNumber == 2)
        {
            horizontalKey = "p2HorizontalKey";
            verticalKey = "p2VerticalKey";
            punchKey = "p2PunchKey";
        }
    }

}


