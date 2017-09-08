using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour {

    public string characterName;
    string currentMove;
    bool canAttack;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		//check for Punch1 input
        if(Input.GetButton(GetComponentInParent<PlayerInfo>().punch1Key) && canAttack)
        {
            currentMove = "Punch1";
            gameObject.BroadcastMessage("Punch1", characterName);
        }
	}

    public void SetName()
    {
        characterName = GetComponentInParent<CharacterInfoCollector>().characterName;
    }

    public void ActivateHitBox()
    {
        GetComponentInChildren<HitboxManager>().ActivateHitbox();
    }

	public void DeactivateHitBox()
	{
        GetComponentInChildren<HitboxManager>().DeactivateHitbox();
	}

    public void MoveFinished()
    {
        GetComponent<Animator>().ResetTrigger(currentMove);
    }

    public void SetCanAttack()
    {
        canAttack = true;
    }

    public void SetCannotAttack()
    {
        canAttack = false;
    }
}
