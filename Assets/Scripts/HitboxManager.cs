using UnityEngine;
using System.Collections;

public class HitboxManager : MonoBehaviour
{
    string player;
    bool hitboxActive;

	void Start()
    {
        player = this.name;
        hitboxActive = false;
	}

    void OnTriggerStay(Collider col)
	{
        if (hitboxActive == true)
        {
            hitboxActive = false;
            Debug.Log(col.gameObject.name + " hit !");
            col.gameObject.GetComponentInChildren<Rigidbody>().AddForce(100, 100, 1000);
            col.gameObject.GetComponentInChildren<HealthCounter>().TakeDamage(10);
           
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