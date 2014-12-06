using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        
        Rect rect = new Rect(10, 100, 40, 10);
        GUI.TextArea(rect, "a");
    }
}
