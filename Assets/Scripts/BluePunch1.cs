using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePunch1 : MonoBehaviour
{
    public void Punch1()
	{
		GetComponentInParent<MovementController>().SetCannotMove();
		GetComponentInParent<Animator>().SetTrigger("Punch1");
	}
}
