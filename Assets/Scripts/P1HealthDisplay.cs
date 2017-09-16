using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1HealthDisplay : MonoBehaviour
{

	int healthAmount;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
        healthAmount = GameObject.Find("Player 1").GetComponentInChildren<HealthCounter>().currentHealth;
        GetComponent<Text>().text = "Player 1 Health: " + healthAmount.ToString("0");
	}
}
