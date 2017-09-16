using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1StockDisplay : MonoBehaviour {

    int stockCount;

	// Use this for initialization
	void Start () 
    {
        
    }
	
	// Update is called once per frame
	void Update () 
    {
        stockCount = GameObject.Find("Player 1").GetComponentInChildren<StockCounter>().currentStockCount;
        GetComponent<Text>().text = "Player 1 Stocks: " + stockCount.ToString("0");
	}
}
