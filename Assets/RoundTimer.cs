using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTimer : MonoBehaviour {

    static float timer;
    public bool roundOver;

	// Use this for initialization
	void Start () {
        timer = 99;
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            GetComponent<Text>().text = timer.ToString("0");
        }
        else roundOver = true;
	}
}
