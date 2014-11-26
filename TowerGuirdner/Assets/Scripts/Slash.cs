using UnityEngine;
using System.Collections;

public class Slash : MonoBehaviour {

    public Texture2D[] frames = new Texture2D[9];

    float frame = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        frame += Time.deltaTime;

        if(frame > 0.2f){
            Destroy(gameObject);
        }
        gameObject.renderer.material.mainTexture = frames[(int)(frame / 0.2f *8)];
	}

}
