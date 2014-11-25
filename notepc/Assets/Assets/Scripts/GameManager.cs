using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    GameObject room;
    GameObject player;
    FollowCamera camera;
    public BoxMaker box;
    

    int curr_roomNo = 0;

	//Use this for initialization
	void Start () {
        box = Instantiate(Resources.Load("Prefab/BoxMaker")) as BoxMaker;
        camera = FindObjectOfType<FollowCamera>();
        player = Instantiate(Resources.Load("Prefab/Player")) as GameObject;
        camera.lookTarget = player.transform;
        roomMake();
	}
	
	//Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("q")){
            curr_roomNo = 1;
            roomMake();
        }
	}

    //部屋を削除し、新しく生成
    void roomMake(){
        Destroy(room);
        room = Instantiate(Resources.Load("Rooms/room" + curr_roomNo.ToString())) as GameObject;
    }
}
