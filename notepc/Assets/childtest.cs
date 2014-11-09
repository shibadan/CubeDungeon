using UnityEngine;
using System.Collections;

public class childtest : MonoBehaviour {

	public GameObject parent;

	// Use this for initialization
	void Start () {
		gameObject.transform.parent = parent.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
