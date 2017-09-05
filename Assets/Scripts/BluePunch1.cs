using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePunch1 : MonoBehaviour
{

	public bool canAttack;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Punch1()
	{
		GetComponent<MovementController>().SetCannotMove();
		GetComponent<Animator>().SetTrigger("Punch1");
		canAttack = false;
	}

	public void Punch1Done()
	{
		GetComponentInChildren<Animator>().ResetTrigger("Punch1");
	}

	public void ActionReset()
	{
		GetComponent<MovementController>().SetCanMove();
		canAttack = true;
	}

	public void AttackDisable()
	{
		canAttack = false;
	}
}
