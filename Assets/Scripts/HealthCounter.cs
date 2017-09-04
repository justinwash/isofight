using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class HealthCounter : MonoBehaviour
{
    
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    bool hitbyopponent;
    public bool isDead;

    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            // KAYYYYY OHHHHHH
            isDead = true;
        }
    }
    
    public void TakeDamage(int amount)
    {
        hitbyopponent = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

    }
    
}