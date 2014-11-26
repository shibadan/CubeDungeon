using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private int hp = 10;

	// Use this for initialization
	void Start () {
        gameObject.rigidbody.velocity = new Vector3(-2f, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DeadLine")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Attack")
        {
            hp -= col.GetComponent<Weapon>().getDamage();
            Destroy(col.gameObject);
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
