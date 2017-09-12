using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class StockCounter : MonoBehaviour
{
    public int startingStocks = 6;
    int oldStockCount;
    public int currentStockCount;
    public Rigidbody pleaseStop;
    public Vector3 respawnPosition;
    public Quaternion respawnRotation;
    public GameObject character;
    public bool isDead;

    // Use this for initialization
    void Start()
    {
        character = transform.parent.gameObject;
        pleaseStop = GetComponentInParent<Rigidbody>();
        respawnPosition = gameObject.transform.position;
        respawnRotation = gameObject.transform.rotation;
        oldStockCount = startingStocks;
        currentStockCount = startingStocks;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= -500 && oldStockCount == currentStockCount)
        {
            FellOff();
            Respawn();
        }
    }

    public void FellOff()
    {
        currentStockCount = oldStockCount - 1;

        if (currentStockCount <= 0 && !isDead)
        {
            // KAYYYYY OHHHHHH
            Death();
        }

    }

    public void Respawn()
    {
        
    }

    void Death()
    {
        // Set the death flag, eventually have charlie yell something dumb about Cammy
        isDead = true;
    }
}