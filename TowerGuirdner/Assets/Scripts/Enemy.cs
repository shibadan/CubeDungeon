using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private int hp = 10;

    public GameObject target;

    public float speed = 4;

	// Use this for initialization
	void Start () {

        Vector3 direction = target.transform.position - gameObject.transform.position;

        direction.Normalize();

        gameObject.rigidbody.velocity = direction * speed;
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
