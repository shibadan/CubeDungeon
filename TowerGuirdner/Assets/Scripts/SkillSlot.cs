using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillSlot : MonoBehaviour {

    //List<int> slot = new List<int>();

    //List<GameObject> skills = new List<GameObject>();

    //GameObject[] obj = new GameObject[5];

    //int curr_slot = 0;

    string[] SKILL = { "Arrow", "Slash", "Arrow", "Slash", "Arrow", "Slash", "Arrow", "Slash", "Arrow", "Slash", "Arrow", "Slash", "Arrow", "Slash", "Arrow", "Slash", "Arrow", "Slash", "Arrow", "Slash", "Arrow", "Slash", "Arrow", "Slash", "Arrow", "Slash", "Arrow", "Slash", "Arrow", "Slash"};

	// Use this for initialization
	void Start () {
        rigidbody.centerOfMass = new Vector3(0, 0, 0);
        rigidbody.angularVelocity = new Vector3(0, 1.0f, 0);
	}
	
	// Update is called once per frame
	void Update () {
        //rigidbody.angularVelocity = new Vector3(0, 1.2f, 0);
	}
    
    public void Use(Vector3 pos)
    {
        float curr_rad = transform.localEulerAngles.y + 6;
        pos.z = 0;
        if (curr_rad >= 360)
        {
            curr_rad -= 360;
        }
        Debug.Log(curr_rad);
        int skill_no = (int)curr_rad / 12;
        GameObject o = Instantiate(Resources.Load("Prefabs/" + SKILL[skill_no])) as GameObject;
        o.SendMessage("setProperty", pos);
    }

}
