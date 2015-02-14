using UnityEngine;
using System.Collections;

public class Slash2 : MonoBehaviour {

    public Texture2D[] frames = new Texture2D[3];

    float frame = 0;


    // Use this for initialization
    void Start()
    {
        int r = Random.Range(0, 360);
        transform.Rotate(new Vector3(0, 0, r));
    }

    // Update is called once per frame
    void Update()
    {

        frame += FrameManager.getTime();

        if (frame >= 0.2f)
        {
            Destroy(gameObject);
        }
        else gameObject.renderer.material.mainTexture = frames[(int)(3 * frame / 0.2f)];
    }

    void setProperty(Vector3 target)
    {
        transform.position = target;
    }
}
