using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class StockCounter : MonoBehaviour
{
    public int startingStocks;
    [HideInInspector]
    public int oldStockCount;
    public int currentStockCount;
    GameObject character;
    public bool isDead;
    Transform respawnParent;
    float respawnTimer;
    int respawnTime = 2;
    string selectedCharacter;
    int playerNumber;
    string objectName;
    public bool isRespawning;


    bool fellOff;

    // Use this for initialization
    void Start()
    {
        startingStocks = GetComponentInParent<CharacterInfoCollector>().characterStocks;

        // Change the name of this object so it doesn't end up with "(clone)" after it when we respawn
        // Was going to use this to find instantiated respawns but I found a beter way to do that.
        selectedCharacter = transform.parent.GetComponentInParent<CharacterInfoCollector>().selectedCharacter;
        playerNumber = transform.parent.GetComponentInParent<PlayerInfo>().playerNumber;
        objectName = selectedCharacter + playerNumber;
        transform.parent.gameObject.name = objectName;

        //Set the selected character as the thing we're gonna make a bunch of (when we fall off)
        character = transform.parent.gameObject;

        // Tell the thing where it should respawn
        respawnParent = transform.parent.transform.parent;

        if (!isRespawning)
        {
            oldStockCount = startingStocks;
            currentStockCount = startingStocks;
        }

        isRespawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        respawnTimer += Time.deltaTime;
        if (gameObject.transform.position.y <= -500 && oldStockCount == currentStockCount)
        {
            FellOff();
            respawnTimer = 0;
        }

        if (respawnTimer > respawnTime && fellOff)
        {
            Respawn();
            respawnTimer = 0;
        }
    }

    void FellOff()
    {
        fellOff = true;
        currentStockCount = oldStockCount - 1;

        if (currentStockCount <= 0 && !isDead)
        {
            // KAYYYYY OHHHHHH
            Death();
        }

    }

    void Respawn()
    {
        if (fellOff && !isDead)
        {
            // Remove the character from the Player gameobject and fix its scale
            transform.parent.transform.parent = null;
            character.transform.localScale = new Vector3(1, 1, 1);

            // Tell the new instance how many lives and health it has, then create it
            character.GetComponentInChildren<StockCounter>().currentStockCount = currentStockCount;
            character.GetComponentInChildren<StockCounter>().oldStockCount = currentStockCount;
            character.GetComponentInChildren<StockCounter>().isRespawning = true;
            character.GetComponentInChildren<HealthCounter>().isRespawning = true;
            character.GetComponentInChildren<HealthCounter>().currentHealth = GetComponent<HealthCounter>().currentHealth;
            Instantiate(character, respawnParent.position, respawnParent.rotation, respawnParent);

            // Trash the old trash that fell off the stage in the first place
            Destroy(transform.parent.gameObject);
        }
    }


    void Death()
    {
        // Set the death flag, have charlie yell something dumb about Cammy
        isDead = true;
    }
}