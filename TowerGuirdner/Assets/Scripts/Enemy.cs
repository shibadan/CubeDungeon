using UnityEngine;
using System.Collections;

public class Enemy : RigidObject {

    private int hp = 10;

    public GameObject target;

    private float speed = 2f;
    public bool isDead = false;

    private float frame = 0;
    private int curr_tex = 0;

    public Material[] tex = new Material[2];

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
	void Update (){ 
        frame += FrameManager.getTime();
        if (frame > 0.5)
        {
            curr_tex++;
            curr_tex %= 2;
            renderer.material = tex[curr_tex];
            frame = 0;
        }
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
            Instantiate(Resources.Load("Effect/DeadEffect"), transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
    }
}
