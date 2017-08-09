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
    bool isDead;

    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(hitbyopponent)
        {
            //hit effect etc maybe
        }

        hitbyopponent = false;
    }

    public void TakeDamage(int amount)
    {
        hitbyopponent = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead)
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