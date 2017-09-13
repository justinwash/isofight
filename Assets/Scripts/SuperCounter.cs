using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCounter : MonoBehaviour {

    public int superPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddSuperPoints(int amount)
    {
        superPoints += amount;
    }
}
