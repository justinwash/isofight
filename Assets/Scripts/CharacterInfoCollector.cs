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
        prefabPath = "Characters/" + selectedCharacter;
        //Load the selected character prefab from Resources
        character = Resources.Load(prefabPath) as GameObject;
        //Set the Tag of the character to be instantiated so we can find it later.
        character.tag = selectedCharacter;
        //Add the selected character prefab to the scene
        Instantiate(character, new Vector3(0, 0, 0), Quaternion.identity, transform);

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
        GetComponent<MovementController>().SetMovementSpeed();

        //Same for the name in th ability script
        GetComponent<AbilityController>().SetName();

        //Same for the Animator
        GetComponent<Animator>().runtimeAnimatorController = character.GetComponent<CharacterInfo>().characterAnimatorController;
    }

    // Update is called once per frame
    void Update()
    {

    }
}