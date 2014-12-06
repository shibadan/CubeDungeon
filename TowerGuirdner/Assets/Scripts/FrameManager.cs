using UnityEngine;
using System.Collections;

public class FrameManager : MonoBehaviour {

    private float delta = 0;

    private bool isstopped = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if(!isstopped)
            delta = Time.deltaTime;
    }

    public void stop(){
        isstopped = true;
        delta = 0;
    }

    public void restart()
    {
        isstopped = false;
    }

    public float getTime()
    {
        return delta;
    }
}
