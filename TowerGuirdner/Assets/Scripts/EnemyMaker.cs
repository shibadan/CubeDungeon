using UnityEngine;
using System.Collections;

public class EnemyMaker : MonoBehaviour {

    private float frame = 0;

    public float spawn_time = 1f;

    const float pai = Mathf.PI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        frame += Time.deltaTime;
        if (frame > spawn_time)
        {

            float rad = Random.Range(0, 180);

            float x = Mathf.Cos(pai * rad / 180) * 13f;
            float y = Mathf.Sin(pai * rad / 180) * 13f - 3f;

            Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(x,y,0), Quaternion.identity);
            frame = 0;
        }
	}

}
