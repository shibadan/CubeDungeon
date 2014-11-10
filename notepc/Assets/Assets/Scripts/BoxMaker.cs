using UnityEngine;
using System.Collections;

public class BoxMaker : MonoBehaviour {

	public GameObject prefab;
	private Box[,,] boxes = new Box[3,3,3];
    Box[, ,] tmp = new Box[3, 3, 3];
    private Box[] center = new Box[7];
    private int[,] PLUSTURN = new int[,] { { 0, -1 }, { 0, 1 } };
    private int[,] MINUSTURN = new int[,] { { 0, 1 }, { 0, -1 } };

    private float frame = 0;

    private bool isTurning = false;
    private TurnProp t_prop = new TurnProp();

	// Use this for initialization
    void Start(){
        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){
                for (int k = 0; k < 3; k++){
                    boxes[i, j, k] = new Box();
                    boxes[i, j, k].setBox(Object.Instantiate(prefab, new Vector3(i * 1f - 1f, j * 1f - 1f, k * 1f - 1f), Quaternion.identity) as GameObject);
                    boxes[i, j, k].setPos(i-1, j-1, k-1);
                    tmp[i, j, k] = new Box();
                }
            }
        }
        center[0] = boxes[0, 1, 1];
        center[1] = boxes[2, 1, 1];
        center[2] = boxes[1, 0, 1];
        center[3] = boxes[1, 2, 1];
        center[4] = boxes[1, 1, 0];
        center[5] = boxes[1, 1, 2];
        center[6] = boxes[1, 1, 1];
    }

    private void boxUpdate(){
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    tmp[i, j, k] = new Box();
                    tmp[boxes[i, j, k].x + 1, boxes[i, j, k].y + 1, boxes[i, j, k].z + 1] = boxes[i, j, k];
                }
            }
        }
        boxes = tmp;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (isTurning){
            frame += Time.deltaTime;
            t_prop.turn();
            if (frame >= 1f){
                isTurning = false;
                t_prop.turn(1f - frame);
                boxUpdate();
                t_prop.detatch();
            }
        }
        else if(frame > 3){
            isTurning = true;
            frame = 0;

            t_prop.setTurnProp(2, boxes[1, 0, 1].getInstance(), -1);

            for (int i = 0; i < 3; i++){
                for (int j = 0; j < 3; j++){
                    if (i != 1 || j != 1)
                        boxes[i, 0, j].getInstance().transform.parent = t_prop.getFather().transform;
                }
            }
        }
        else{
            frame += Time.deltaTime;
        }
	}

    //回転情報を設定(軸番号[x=1, y=2, z=3], 親オブジェクト, 正の方向かどうか)
    private class TurnProp{
        private Vector3 axis;
        private GameObject father;
        private int dir;

        private int speed;

        public void setTurnProp(int n_axis, GameObject n_father, int direction){

            switch (n_axis){
                case 1: axis = new Vector3(1, 0, 0); break;
                case 2: axis = new Vector3(0, 1, 0); break;
                case 3: axis = new Vector3(0, 0, 1); break;
            }
            father = n_father;
            dir = direction;
            speed = 90 * dir;
        }

        public GameObject getFather(){
            return father;
        }

        public void detatch(){
            father.transform.DetachChildren();
        }

        public void turn(){
            float t = Time.deltaTime;
            father.transform.Rotate(new Vector3(t * speed * axis.x, t * speed * axis.y, t * speed * axis.z));
        }

        public void turn(float angle){
            father.transform.Rotate(new Vector3(angle * speed * axis.x, angle * speed * axis.y, angle * speed * axis.z));
        }

    }

    class Box{
        private GameObject box;

        //内部座標
        public int x, y, z;

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
