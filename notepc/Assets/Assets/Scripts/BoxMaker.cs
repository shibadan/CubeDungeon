using UnityEngine;
using System.Collections;

public class BoxMaker : MonoBehaviour {

	public GameObject prefab;
	private Box[,,] boxes = new Box[3,3,3];
    private int[,] PLUSTURN = new int[,] { { 0, -1 }, { 0, 1 } };
    private int[,] MINUSTURN = new int[,] { { 0, 1 }, { 0, -1 } };

	// Use this for initialization
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    boxes[i, j, k] = new Box();
                    boxes[i, j, k].setBox(Object.Instantiate(prefab, new Vector3(i * 1f - 1f, j * 1f - 1f, k * 1f - 1f), Quaternion.identity) as GameObject);
                    boxes[i, j, k].setPos(i, j, k);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    class Box{
        private GameObject box;

        private int x, y, z;

        //オブジェクトを持たせる
        public void setBox(GameObject obj){
            box = obj;
        }

        //内部座標の設定
        public void setPos(int nx, int ny, int nz){
            x = nx;
            y = ny;
            z = nz;
        }

        //オブジェクトインスタンスの取得
        public GameObject getInstance(){
            return box;
        }

    }
}
