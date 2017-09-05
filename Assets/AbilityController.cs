using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour {

    string characterName;
    GameObject moveDatabase;
    string currentMove;

	// Use this for initialization
	void Start ()
    {
        characterName = GetComponent<CharacterInfo>().characterName;
        moveDatabase = GameObject.FindGameObjectWithTag("Move Database");
    }
	
	// Update is called once per frame
	void Update ()
    {
		//check for Punch1 input
        if(Input.GetButton(GetComponent<PlayerInfo>().punch1Key))
        {
            currentMove = characterName + "Punch1";
            moveDatabase.GetComponent(currentMove);


        }
	}
}
