using UnityEngine;
using System.Collections;

public class CubeSpin : MonoBehaviour {

    bool moving = false;
    Vector3 mouse0 = new Vector3();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            moving = true;
            mouse0 = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moving = false;
        }
        else if(moving)
        {
            float distance;
            float cuur_x = Input.mousePosition.x;
            float curr_y = Input.mousePosition.y;
            if ((distance = Vector3.Distance(mouse0, Input.mousePosition)) >= 20)
            {
                transform.Rotate(15,0,0);
            }
        }
	}
}
