using UnityEngine;
using System.Collections;

public class Arrow : Weapon{

	// Use this for initialization
	void Start () {
        //transform.rigidbody.velocity = new Vector3(15f, 15f, 0f);
        setDamage(10);
	}

    public void setProperty(Vector3 target)
    {
        transform.position = new Vector3(0, -4, 0);
        Vector3 dir = target - transform.position;
        dir.Normalize();
        transform.rigidbody.velocity = dir * 25f;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "W_DeadLine" || col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
