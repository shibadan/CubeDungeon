using UnityEngine;
using System.Collections;

public class DeadEffect : MonoBehaviour {

    float frame = 0;

	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
        frame += FrameManager.getTime();
        if (frame > 0.15)
        {
            Destroy(gameObject);
        }
	}
}
