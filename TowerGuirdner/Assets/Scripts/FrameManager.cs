using UnityEngine;
using System.Collections;

public class FrameManager : MonoBehaviour {

    private static float delta = 0;

    private static bool isstopped = false;

	// Use this for initialization
	void Start () {
        isstopped = false;
        delta = 0;
	}
	
	// Update is called once per frame
    void Update()
    {
        if(!isstopped)
            delta = Time.deltaTime;
    }

    public static void stop(){
        isstopped = true;
        delta = 0;
    }

    public static void restart()
    {
        isstopped = false;
    }

    public static float getTime()
    {
        return delta;
    }
}
