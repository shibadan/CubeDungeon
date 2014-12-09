using UnityEngine;
using System.Collections;

public class ClickAttackTest : MonoBehaviour {

    string[] skills = { "Arrow", "Slash", "Slash", "Slash", "Slash" };

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.transform.gameObject;
 
                if (obj.tag == "Ground" || obj.tag == "Enemy")
                {
                    obj = Instantiate(Resources.Load("Prefabs/" + skills[0]), hit.point, Quaternion.identity)as GameObject;

                    obj.SendMessage("setProperty", hit.point);
                }
            }
        }
	}
}
