using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

         //タッチ機能を使用するときはこちら
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            if (Physics.Raycast(ray, out hit) && touch.phase == TouchPhase.Began)
            {
                Debug.Log("Tapped");
                GameObject obj = hit.transform.gameObject;

                if (obj.tag == "Button")
                {
                    obj.SendMessage("Tapped");
                }
            }
        }
        

        /*
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.transform.gameObject;

                if (obj.tag == "Button")
                {
                    obj.SendMessage("Tapped");
                }
            }
        }
        */
	}
}
