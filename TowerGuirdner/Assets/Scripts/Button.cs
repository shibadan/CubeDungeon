using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

   // float inst_y, inst_z;

	// Use this for initialization
	void Start () {
        //rigidbody.velocity = new Vector3(-10, 0, 0);
       // inst_y = transform.parent.position.y;
        //inst_z = transform.parent.position.z;
	}
	
	// Update is called once per frame
    void Update()
    {
        //if (transform.position.x < -11)
        //{
        //    transform.position = new Vector3(11, inst_y, inst_z);
        //}
    }

    public void stop()
    {
       // isstopped = true;
    }

    public void restart()
    {
      //  isstopped = false;
    }


}
