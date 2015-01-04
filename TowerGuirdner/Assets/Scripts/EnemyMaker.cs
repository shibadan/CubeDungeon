using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMaker : MonoBehaviour {

    private float red_frame = 0;
    private float right_frame = 0;
    private float left_frame = 0;

    public float spawn_time = 3f;
    public float right_spawn_time = 2f;
    public float left_spawn_time = 2f;

    const float pai = Mathf.PI;

    List<GameObject> enemys;

    GameManager manager;

	// Use this for initialization
	void Start () {
        manager = FindObjectOfType<GameManager>();
        enemys = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        float delta = FrameManager.getTime();
        red_frame += delta;
        right_frame += delta;
        left_frame += delta;

        //中央の敵生成
        if (red_frame > spawn_time)
        {
            enemys.Add(Instantiate(Resources.Load("Prefabs/RedEnemy"), new Vector3(0, 9, 0), Quaternion.Euler(new Vector3(0, 0, 180))) as GameObject);
            red_frame = 0;
        }

        //画面右側の敵生成
        if (right_frame > right_spawn_time)
        {
            int x;
            for (int i = 0; i < Random.Range(1, 3); i++)
            {
                x = Random.Range(1, 6);
                enemys.Add(Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(x*2, 9, 0), Quaternion.Euler(new Vector3(0, 0, 180))) as GameObject);
            }
            right_frame = 0;
            right_spawn_time = Random.Range(1f, 2f);
        }
        
        //画面左側の敵生成
        if (left_frame > left_spawn_time)
        {
            int x;
            for (int i = 0; i < Random.Range(1, 3); i++)
            {
                x = Random.Range(1, 6);
                enemys.Add(Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(-x * 2, 9, 0), Quaternion.Euler(new Vector3(0, 0, 180))) as GameObject);
            }
            left_frame = 0;
            left_spawn_time = Random.Range(1f, 2f);
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