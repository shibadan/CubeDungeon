using UnityEngine;
using System.Collections;

public class EnemyMaker : MonoBehaviour {

    private float frame = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        frame += Time.deltaTime;
        if (frame > 2f)
        {
            Instantiate(Resources.Load("Prefabs/Enemy"));
            frame = 0;
        }
	}
}
