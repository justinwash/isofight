using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour {

    public string characterName;
    string currentMove;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		//check for Punch1 input
        if(Input.GetButton(GetComponent<PlayerInfo>().punch1Key))
        {
            currentMove = characterName + "Punch1";

            GameObject.FindWithTag("Red").GetComponent<RedPunch1>().Punch1();


        }
	}

    public void SetName()
    {
        characterName = GetComponent<CharacterInfoCollector>().characterName;
    }
}
