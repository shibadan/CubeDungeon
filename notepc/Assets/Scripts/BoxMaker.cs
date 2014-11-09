using UnityEngine;
using System.Collections;

public class BoxMaker : MonoBehaviour {

	public GameObject box;
	private GameObject[,,] boxes = new GameObject[3,3,3];

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 3; i++){
			for(int j = 0; j < 3; j++){
				for(int k = 0; k < 3; k++){
					boxes [i,j,k] = Instantiate(box, new Vector3(i*1f-1f, j*1f-1f,k*1f-1f), Quaternion.identity)as GameObject;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
