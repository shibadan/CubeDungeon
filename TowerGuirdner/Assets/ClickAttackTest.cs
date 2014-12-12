using UnityEngine;
using System.Collections;

public class ClickAttackTest : MonoBehaviour {

   // string[] skills = { "Arrow", "Slash", "Slash", "Slash", "Slash" };

    SkillSlot skill;

	// Use this for initialization
	void Start () {
        skill = FindObjectOfType<SkillSlot>();
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
                    skill.Use(hit.point);
                }
            }
        }
	}
}
