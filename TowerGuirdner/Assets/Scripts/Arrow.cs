using UnityEngine;
using System.Collections;

public class Arrow : Weapon{

    public Texture2D[] frames = new Texture2D[4];

    float frame = 0;

    int curr_tex = 0;

    bool ishit = false;

	// Use this for initialization
	void Start () {
        //transform.rigidbody.velocity = new Vector3(15f, 15f, 0f);
        
	}

    void Update()
    {
        frame += FrameManager.getTime();
        if (frame >= 0.2f && !ishit)
        {
            curr_tex += 1;
            curr_tex %= 2;
            gameObject.renderer.material.mainTexture = frames[curr_tex];
        }
        else if (ishit && frame > 0.2f)
        {
            Destroy(gameObject);
        }
        else if (ishit && frame > 0.1f)
        {
            gameObject.renderer.material.mainTexture = frames[3];
        }
    }
    public void setProperty(Vector3 target)
    {
        transform.position = new Vector3(0, -4, 0);
        Vector3 dir = target - transform.position;
        dir.Normalize();
        transform.rigidbody.velocity = dir * 25f;

        transform.rotation = Quaternion.FromToRotation(Vector3.down, dir);
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "W_DeadLine" || col.gameObject.tag == "Enemy")
        {
            ishit = true;
            frame = 0;
            transform.rigidbody.velocity = Vector3.zero;
            gameObject.renderer.material.mainTexture = frames[2];
        }
    }

}
