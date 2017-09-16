using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfoCollector : MonoBehaviour
{
    public string selectedCharacter;
    GameObject character;
    public string characterName;
    public int characterHealth;
    public float characterSpeed;
    public int characterStocks;
    public Sprite characterSprite;
    public ArrayList characterMoves;
    public RuntimeAnimatorController characterAnimatorController;
    string prefabPath;

    // Use this for initialization
    void Start()
    {
        if (GetComponent<PlayerInfo>().playerNumber == 1)
            selectedCharacter = GameState.Instance.GetP1Character();
        
        if (GetComponent<PlayerInfo>().playerNumber == 2)
            selectedCharacter = GameState.Instance.GetP2Character();

        //Set the prefab path so we know where to look for character prefabs
        prefabPath = "Characters/" + selectedCharacter;
        //Load the selected character prefab from Resources
		character = Resources.Load(prefabPath) as GameObject;
        LoadCharacter();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadCharacter()
    {
		//Add the selected character prefab to the scene
		Instantiate(character, transform.position, transform.rotation, transform);

		if (character == null)
		{
			Debug.Log("No character selected");
		}

		// Assign character stats based on the prefab chosen by selectedCharacter
		characterName = character.GetComponent<CharacterInfo>().characterName;
        characterHealth = character.GetComponent<CharacterInfo>().characterHealth;
		characterSpeed = character.GetComponent<CharacterInfo>().characterSpeed;
		characterStocks = character.GetComponent<CharacterInfo>().characterStocks;
		characterSprite = character.GetComponent<CharacterInfo>().characterSprite;
		characterMoves = character.GetComponent<CharacterInfo>().characterMoves;

		// Set movement speed because my MovementController script is too dumb to do it alone
        GetComponentInChildren<MovementController>().SetMovementSpeed();

		//Same for the name in the ability script
		GetComponentInChildren<AbilityController>().SetName();
    }

}