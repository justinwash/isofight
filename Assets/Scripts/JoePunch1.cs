using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoePunch1 : MonoBehaviour {

    public bool canAttack;
    public bool canMove;

    // Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("p1Punch1") && canAttack == true) // Punch1 if Punch1 is pressed and we're allowed to
        {

            Punch1();
        }
    }

    void Punch1()
    {
	    canMove = false;
	    GetComponentInChildren<Animator>().SetTrigger("Punch1");
	    canAttack = false;
    }

    public void Punch1Done()
    {
	    GetComponentInChildren<Animator>().ResetTrigger("Punch1");
    }

    public void ActionReset()
    {
	    canMove = true;
	    canAttack = true;
    }

    public void AttackDisable()
    {
        canAttack = false;
    }
}

