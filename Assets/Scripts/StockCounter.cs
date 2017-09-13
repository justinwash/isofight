using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class StockCounter : MonoBehaviour
{
    public int startingStocks = 6;
    int oldStockCount;
    public int currentStockCount;
    public Vector3 respawnPosition;
    public Quaternion respawnRotation;
    public GameObject character;
    public bool isDead;
    public Transform respawnParent;
    public float respawnTimer;
    public int respawnTime = 3;
    GameObject respawnedCharacter;

    bool fellOff;

    // Use this for initialization
    void Start()
    {
        character = transform.parent.gameObject;
        respawnPosition = transform.position;
        respawnRotation = transform.rotation;
        respawnParent = transform.parent.transform.parent;
        oldStockCount = startingStocks;
        currentStockCount = startingStocks;
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
        transform.parent.GetComponentInParent<CharacterInfoCollector>().characterStocks = currentStockCount;

        if (currentStockCount <= 0 && !isDead)
        {
            // KAYYYYY OHHHHHH
            Death();
        }

    }

    void Respawn()
    {
        if (fellOff)
        {
            // Remove the character from the Player gameobject and fix its scale
            transform.parent.transform.parent = null;
            character.transform.localScale = new Vector3(1, 1, 1);

            // Make a new player object and destroy the one that fell off screen
            respawnedCharacter = Instantiate(character, respawnParent.position, respawnParent.rotation, respawnParent);

            Destroy(transform.parent.gameObject);

            fellOff = false;;
        }
    }


    void Death()
    {
        // Set the death flag, eventually have charlie yell something dumb about Cammy
        isDead = true;
    }
}