using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2StockDisplay : MonoBehaviour
{

	int stockCount;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		stockCount = GameObject.Find("Player 2").GetComponentInChildren<StockCounter>().currentStockCount;
		GetComponent<Text>().text = "Player 2 Stocks: " + stockCount.ToString("0");
	}
}