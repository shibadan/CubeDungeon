using UnityEngine;
using System.Collections;

public class Arrowhit : Weapon{

	// Use this for initialization
	void Start () {
        setDamage(10);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "W_DeadLine" || col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
