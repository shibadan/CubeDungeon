using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMaker : MonoBehaviour {

    private float red_frame = 0;
    private float right_frame = 0;
    private float left_frame = 0;

    public float spawn_time = 2f;
    public float right_spawn_time = 1f;
    public float left_spawn_time = 1f;

    const float pai = Mathf.PI;

    List<GameObject> enemys;

    GameManager manager;

    FrameManager f_manager;

	// Use this for initialization
	void Start () {
        manager = FindObjectOfType<GameManager>();
        f_manager = FindObjectOfType<FrameManager>();
        enemys = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        float delta = f_manager.getTime();
        red_frame += delta;
        right_frame += delta;
        left_frame += delta;
        if (red_frame > spawn_time)
        {
            enemys.Add(Instantiate(Resources.Load("Prefabs/RedEnemy"), new Vector3(0, 9, 0), Quaternion.identity) as GameObject);
            red_frame = 0;
        }
        if (right_frame > right_spawn_time)
        {
            int x;
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                x = Random.Range(2, 12);
                enemys.Add(Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(x, 9, 0), Quaternion.identity) as GameObject);
            }
            right_frame = 0;
            right_spawn_time = Random.Range(0.3f, 1.5f);
        }
        if (left_frame > left_spawn_time)
        {
            float x;
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                x = Random.Range(2, 12);
                enemys.Add(Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(-x, 9, 0), Quaternion.identity) as GameObject);
            }
            left_frame = 0;
            left_spawn_time = Random.Range(0.3f, 1.5f);
        }

	}

    public void remove_one(GameObject e){
        enemys.Remove(e);
    }

    public void stop(){
        foreach(GameObject e in enemys){
            e.GetComponent<Enemy>().stop();
        }
    }

    public void restart()
    {
        foreach (GameObject e in enemys)
        {
            e.GetComponent<Enemy>().restart();
        }
    }

    public void killed()
    {
        manager.ScoreUp();
    }

}



/* //円形に敵を出現させる
float rad = Random.Range(0, 180);
float x = Mathf.Cos(pai * rad / 180) * 13f;
float y = Mathf.Sin(pai * rad / 180) * 13f - 3f;
Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(x,y,0), Quaternion.identity);
*/