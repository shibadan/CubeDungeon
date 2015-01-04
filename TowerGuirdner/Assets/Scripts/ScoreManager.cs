using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public GameObject[] num_plate = new GameObject[5];

    public Material[] numbers = new Material[10];

    int score = 0;

    GameManager manager;

	// Use this for initialization
	void Start () {
        manager = FindObjectOfType<GameManager>();
        for(int i = 0; i < 5; i++){
            num_plate[i].renderer.material = numbers[0];
        }
	}
	
	// Update is called once per frame
	void Update () {
        int s;
        if ((s = manager.getScore()) != score)
        {
            score = s;
            for (int i = 0; i < 5; i++)
            {
                int keta = (int)Mathf.Pow(10, i);
                num_plate[i].renderer.material = numbers[calc_num(keta)];
            }
        }


	}

    int calc_num(int keta)
    {
        int result = score;

        result /= keta;
        result %= 10;
        return result;
    }
}
