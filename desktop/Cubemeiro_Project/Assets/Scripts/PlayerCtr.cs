using UnityEngine;
using System.Collections;

public class PlayerCtr : MonoBehaviour {
    const float RayCastMaxDistance = 100.0f;
    InputManager inputManager;
    public float attackRange = 1.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (inputManager.Clicked())
        {
            // RayCastで対象物を調べる.
            Ray ray = Camera.main.ScreenPointToRay(inputManager.GetCursorPosition());
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, RayCastMaxDistance, (1 << LayerMask.NameToLayer("Ground")) | (1 << LayerMask.NameToLayer("EnemyHit"))))
            {
                // 地面がクリックされた.
                if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                    SendMessage("SetDestination", hitInfo.point);
                
            }
        }
	}
}
