using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPunch1 : MonoBehaviour {

    public bool canAttack;

    public void Punch1()
    {
        GetComponentInParent<MovementController>().SetCannotMove();
        GetComponentInParent<Animator>().SetTrigger("Punch1");
    }
}

