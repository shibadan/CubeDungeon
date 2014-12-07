using UnityEngine;
using System.Collections;

public class Enemy : RigidObject {

    private int hp = 10;

    public GameObject target;

    private float speed = 2f;
    public bool isDead = false;

    private EnemyMaker manager;

	// Use this for initialization
	void Start () {

        /* //生成時にターゲットに向かうよう速度を設定する場合
        Vector3 direction = target.transform.position - gameObject.transform.position;
        direction.Normalize();
        gameObject.rigidbody.velocity = direction * speed;
        */

        gameObject.rigidbody.velocity = new Vector3(0, -1 * speed, 0);

        manager = FindObjectOfType<EnemyMaker>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DeadLine")
        {
            manager.remove_one(gameObject);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Attack")
        {
            hp -= col.GetComponent<Weapon>().getDamage();
        }

        if (hp <= 0)
        {
            manager.killed();
            manager.remove_one(gameObject);
            Destroy(gameObject);
        }
    }
}
