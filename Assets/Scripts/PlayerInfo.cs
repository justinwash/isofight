using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    // which player is this?
    public int playerNumber;

    // initialize input buttons
    [HideInInspector]
    public string horizontalKey;
    [HideInInspector]
    public string verticalKey;
    [HideInInspector]
    public string punch1Key;
    [HideInInspector]
    public string punch2Key;
    [HideInInspector]
    public string kick1Key;
    [HideInInspector]
    public string kick2Key;
    [HideInInspector]
    public string superKey;

    void Start()
    {
        if (playerNumber == 1)
        {
            horizontalKey = "p1Horizontal";
            verticalKey = "p1Vertical";
            punch1Key = "p1Punch1";
            punch2Key = "p1Punch2";
            kick1Key = "p1Kick1";
            kick2Key = "p1Kick2";
            superKey = "p1Super";
        }

        if (playerNumber == 2)
        {
            horizontalKey = "p2Horizontal";
            verticalKey = "p2Vertical";
            punch1Key = "p2Punch1";
            punch2Key = "p2Punch2";
            kick1Key = "p2Kick1";
            kick2Key = "p2Kick2";
            superKey = "p2Super";
        }
    }

}


