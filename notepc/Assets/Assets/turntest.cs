using UnityEngine;
using System.Collections;

public class turntest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.RotateAround(Vector3.zero, Vector3.up, Time.deltaTime*90f);
	}
}
