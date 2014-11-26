using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    string[] skills = { "Arrow", "Slash", "Slash", "Slash", "Slash" };

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        float x = Screen.width / 7f;
        float y = Screen.height / 5f;

        for (int i = 1; i < 6; i++)
        {
            Rect rect = new Rect(x*i, y * 3, x, y);
            if (GUI.Button(rect, "B"+i.ToString()))
            {
                Instantiate(Resources.Load("Prefabs/" + skills[i-1]));
            }
        }
    }
}
