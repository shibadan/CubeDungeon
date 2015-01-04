using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillSlot : MonoBehaviour {

    List<int> slot = new List<int>();

    //List<GameObject> skills = new List<GameObject>();

    GameObject[] obj = new GameObject[5];

    int curr_slot = 0;

    string[] SKILL = { "Arrow", "Slash", "Beam", "Arrow", "Slash" };

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 5; i++)
        {
            obj[i] = Instantiate(Resources.Load("Icons/" + SKILL[1]), new Vector3(i*3f,-6.3f,-2f), Quaternion.Euler(0,0,180)) as GameObject;
            slot.Add(1);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Use(Vector3 pos)
    {
        GameObject o = Instantiate(Resources.Load("Prefabs/" + SKILL[slot[curr_slot]])) as GameObject;
        o.SendMessage("setProperty", pos);
        slot.RemoveAt(curr_slot);

        int r = Random.Range(0, 5);
        slot.Add(r);
        IconUpdate();
    }

    void IconUpdate()
    {
        for (int i = 0; i < 5; i++)
        {
            Destroy(obj[i]);
            obj[i] = Instantiate(Resources.Load("Icons/" + SKILL[slot[i]]), new Vector3(i * 3f, -6.3f, -2f), Quaternion.Euler(0, 0, 180)) as GameObject;
        }
    }

}
