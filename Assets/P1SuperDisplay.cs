using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1SuperDisplay : MonoBehaviour
{

	int superAmount;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
        superAmount = GameObject.Find("Player 1").GetComponentInChildren<SuperCounter>().superPoints;
        GetComponent<Text>().text = "Player 1 Super: " + superAmount.ToString("0");
	}
}