﻿
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TestRoomMaker : MonoBehaviour {

	public GameObject prefab;
	//private Box[,,] boxes = new Box[3,3,3];
    //Box[, ,] tmp = new Box[3, 3, 3];

    List<GameObject> boxlist = new List<GameObject>();
    private int[, ,] boxes = new int[3, 3, 3];
    private int[, ,] tmp = new int[3, 3, 3];
    private int[] detatchlist = new int[8];
    private int detatchCount = 10;
    private int turndir = 1;

    //private int[] center = new int[9];
    private int[,] PLUSTURN = new int[,] { { 0, -1 }, { 1, 0 } };
    private int[,] MINUSTURN = new int[,] { { 0, 1 }, { -1, 0 } };

    private float frame = 1;

    private float pre_rotate;

    private bool freetime = false; 

    private bool isTurning = false;
    private TurnProp t_prop = new TurnProp();

	// Use this for initialization
    void Start() {
        int no = 0;
        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){
                for (int k = 0; k < 3; k++){
                    boxlist.Add(Instantiate(Resources.Load("TestRooms/Room" + no.ToString()), new Vector3(i * 10f - 10f, j * 10f - 10f, k * 10f - 10f), Quaternion.identity)as GameObject);
                    boxes[i, j, k] = no;
                    no++;
                }
            }
        }
    }

    public List<GameObject> getBox(){
        return boxlist;
    }

    private int center(int no) {
        switch (no){
            //x固定
            case 0: return boxes[0, 1, 1];
            case 1: return boxes[1, 1, 1];
            case 2: return boxes[2, 1, 1];
            //y固定
            case 3: return boxes[1, 0, 1];
            case 4: return boxes[1, 1, 1];
            case 5: return boxes[1, 2, 1];
            //z固定
            case 6: return boxes[1, 1, 0];
            case 7: return boxes[1, 1, 1];
            case 8: return boxes[1, 1, 2];
            default: Debug.Log("cannot return center"); return -1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (freetime) {
            freetime = false;
        }
        else if (detatchCount < 8){
            detatch(detatchlist[detatchCount]);
            detatchCount++;
            frame = 0;
        }
        else if (isTurning){
            frame += Time.deltaTime;
            t_prop.turn();
            if (frame >= 1){
                isTurning = false;
                t_prop.turn(1f - frame);
                detatchCount = 0;
            }
        }
        else if (frame >= 1){
            int fatherNo = Random.Range(0, 9);
            int axis = fatherNo / 3;
            turndir = Random.Range(0, 2);
            if (turndir == 0) turndir--;
            isTurning = true;

            t_prop.setTurnProp(axis, boxlist[center(fatherNo)], turndir);

            setChildren(fatherNo);

            frame = 0;
            freetime = true;
        }
        else{
            frame += Time.deltaTime;
        }
	}

    private void detatch(int b){
        boxlist[b].transform.parent = null;
    }

    private int[] calc_turn(int i, int j){
        int[] result = new int[2];
        i--;
        j--;
        result[0] = i * PLUSTURN[0, 0] + j * PLUSTURN[0, 1] * turndir;
        result[1] = i * PLUSTURN[1, 0] * turndir + j * PLUSTURN[1, 1];
        result[0]++;
        result[1]++;
        if (result[0] == 1 && result[1] == 1){
            Debug.Log("calc_Bug");
        }
        return result;
    }

    //aをbにコピー
    private void copyToBox(){
        for(int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){
                for(int k = 0; k < 3; k++)
                    boxes[i, j, k] = tmp[i, j, k];
            }
        }
    }

    private void copyToTmp(){
        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){
                for (int k = 0; k < 3; k++)
                    tmp[i, j, k] = boxes[i, j, k];
            }
        }
    }

    private void setChildren(int no){
        copyToTmp();
        int c = 0;
        switch(no){
            case 0:
            case 1:
            case 2:
                int x = no % 3;
                for (int i = 0; i < 3; i++){
                    for (int j = 0; j < 3; j++){
                        if (i != 1 || j != 1){
                            boxlist[boxes[x, i, j]].transform.parent = t_prop.getFather().transform;
                            detatchlist[c] = boxes[x, i, j];
                            c++;
                            int[] p = calc_turn(i, j);
                            tmp[x, p[0], p[1]] = boxes[x, i, j];
                        }
                    }
                }
                break;
            case 3:
            case 4:
            case 5:
                int y = no % 3;
                for (int i = 0; i < 3; i++){
                    for (int j = 0; j < 3; j++){
                        if (i != 1 || j != 1){
                            boxlist[boxes[i, y, j]].transform.parent = t_prop.getFather().transform;
                            detatchlist[c] = boxes[i, y, j];
                            c++;
                            int[] p = calc_turn(j, i);
                            tmp[p[1], y, p[0]] = boxes[i, y, j];
                            
                        }
                    }
                }
                break;
            case 6:
            case 7:
            case 8:
                int z = no % 3;
                for (int i = 0; i < 3; i++) {
                    for (int j = 0; j < 3; j++){
                        if (i != 1 || j != 1){
                            boxlist[boxes[i, j, z]].transform.parent = t_prop.getFather().transform;
                            detatchlist[c] = boxes[i, j, z];
                            c++;
                            int[] p = calc_turn(i, j);
                            tmp[p[0], p[1], z] = boxes[i, j, z];
                        }
                    }
                }
                break;
        }
        copyToBox();
    }

    //回転情報を設定(軸番号[x=0, y=1, z=2], 親オブジェクト, 正の方向かどうか)
    private class TurnProp{
        private Vector3 axis;
        private GameObject father;
        private GameObject t_father;
        private int dir;

        private int speed;

        public void setTurnProp(int n_axis, GameObject n_father, int direction){

            switch (n_axis){
                case 0: axis = new Vector3(1, 0, 0); break;
                case 1: axis = new Vector3(0, 1, 0); break;
                case 2: axis = new Vector3(0, 0, 1); break;
            }
            father = n_father;
            t_father = n_father;
            dir = direction;
            speed = 90 * dir;
        }

        public GameObject getFather(){
            return father;
        }


        //RotateAroundを使えば親子をいじらなくてもいい（？）
        public void turn(){
            float t = Time.deltaTime;
            father.transform.Rotate(new Vector3(t * speed * axis.x, t * speed * axis.y, t * speed * axis.z),Space.World);
        }

        public void turn(float angle){
            father.transform.Rotate(new Vector3(angle * speed * axis.x, angle * speed * axis.y, angle * speed * axis.z),Space.World);
        }
    }

}
