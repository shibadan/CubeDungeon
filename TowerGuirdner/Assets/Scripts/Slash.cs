using UnityEngine;
using System.Collections;

public class Slash : Skill {

    public Texture2D[] frames = new Texture2D[9];

    float frame = 0;


	// Use this for initialization
	void Start () {
        manager = FindObjectOfType<FrameManager>();
        int r = Random.Range(0, 360);
        transform.Rotate(new Vector3(0,0,r));
	}
	
	// Update is called once per frame
	void Update () {

        frame += manager.getTime();

        if(frame > 0.2f){
            Destroy(gameObject);
        }
        gameObject.renderer.material.mainTexture = frames[(int)(frame / 0.2f *7)];
	}

}
