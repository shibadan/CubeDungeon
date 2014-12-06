using UnityEngine;
using System.Collections;

public class RigidObject : MonoBehaviour {

    Vector3 tmp_speed;

    private bool isstopped = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void stop()
    {
        if (!isstopped)
        {
            isstopped = true;
            tmp_speed = gameObject.rigidbody.velocity;
            gameObject.rigidbody.velocity = Vector3.zero;
        }
    }

    public void restart()
    {
        if (isstopped)
        {
            gameObject.rigidbody.velocity = tmp_speed;
            isstopped = false;
        }
    }

}
