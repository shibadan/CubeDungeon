using UnityEngine;
using System.Collections;

public class turntest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(new Vector3(0,Time.deltaTime*90f,0));
	}
}
