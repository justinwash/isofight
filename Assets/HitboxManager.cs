using UnityEngine;
using System.Collections;

public class HitboxManager : MonoBehaviour
{

    bool hitboxActive;

	void Start()
	{
        hitboxActive = false;
	}

    void OnTriggerStay(Collider col)
	{
        if (hitboxActive == true)
        {
            hitboxActive = false;
            Debug.Log(gameObject.name + " hit !");
        }
	}

    void ActivateHitbox()
    {
        hitboxActive = true;
    }

    void DeactivateHitbox()
    {
        hitboxActive = false;
    }
}