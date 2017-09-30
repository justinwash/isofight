using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class HealthCounter : MonoBehaviour
{

    public int startingHealth;
    public int currentHealth;
    public bool isDead;
    public bool isRespawning;

    // Use this for initialization
    void Start()
    {
        startingHealth = GetComponentInParent<CharacterInfoCollector>().characterHealth;

        if (!isRespawning)
        {
            currentHealth = startingHealth;
        }

        isRespawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            
            isDead = true;
        }
    }
    
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

    }
    
}