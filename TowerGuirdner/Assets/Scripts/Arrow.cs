using UnityEngine;
using System.Collections;

public class Arrow : Weapon{

	// Use this for initialization
	void Start () {
        transform.rigidbody.velocity = new Vector3(15f, 0f, 0f);
        setDamage(10);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "W_DeadLine" || col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
