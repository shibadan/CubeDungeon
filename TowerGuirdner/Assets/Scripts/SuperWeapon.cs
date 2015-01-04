using UnityEngine;
using System.Collections;

public class SuperWeapon : Weapon {

	void Start () {
        setDamage(100);
        rigidbody.velocity = new Vector3(50f, 0, 0);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "W_DeadLine")
        {
            Destroy(gameObject);
        }
    }
}
