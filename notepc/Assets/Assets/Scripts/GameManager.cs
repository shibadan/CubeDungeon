using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    GameObject room;
    GameObject player;
    FollowCamera camera;

    //Vector3 roomPos = new Vector3(0, 

	// Use this for initialization
	void Start () {
        camera = FindObjectOfType<FollowCamera>();
        player = Instantiate(Resources.Load("Prefab/Player")) as GameObject;
        camera.lookTarget = player.transform;
        room = Instantiate(Resources.Load("Rooms/room0")) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        player.GetComponent(CharacterController);
	}
}
