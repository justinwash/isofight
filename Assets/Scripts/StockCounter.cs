using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class StockCounter : MonoBehaviour
{
    public int startingStocks = 6;
    int oldStockCount;
    public int newStockCount;
    Rigidbody pleaseStop;
    Vector3 respawnPosition;
    Quaternion respawnRotation;
    public bool isDead;

    // Use this for initialization
    void Start()
    {
        pleaseStop = GetComponent<Rigidbody>();
        respawnPosition = gameObject.transform.position;
        respawnRotation = gameObject.transform.rotation;
        oldStockCount = startingStocks;
        newStockCount = startingStocks;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= -500 && oldStockCount == newStockCount)
        {
            FellOff();
        }

        if (gameObject.transform.position.y <= -1000 && !isDead)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // eventually respawn the character on the stage, then set 
        // oldStockCount the same as newStockCount so FellOff()works next timme we fall off
        pleaseStop.velocity = Vector3.zero;
        gameObject.transform.position = respawnPosition;
        gameObject.transform.rotation = respawnRotation;
        oldStockCount = newStockCount;
    }

    public void FellOff()
    {
        newStockCount = oldStockCount - 1;

        if (newStockCount <= 0 && !isDead)
        {
            // KAYYYYY OHHHHHH
            Death();
        }

        
    }
    void Death()
    {
        // Set the death flag, eventually have charlie yell something dumb about Cammy
        isDead = true;
    }
}