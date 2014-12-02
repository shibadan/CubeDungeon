using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    string[] skills = { "Arrow", "Slash", "Slash", "Slash", "Slash" };

    public int No = 2;

    private Vector3 pos;

    public Texture buttonUp, buttonDown;
    private bool isMouseOver = false;

	// Use this for initialization
	void Start () {
        gameObject.renderer.material.mainTexture = buttonUp;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && isMouseOver)
        {
            gameObject.renderer.material.mainTexture = buttonDown;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //押された瞬間だけ実行したい処理
                Instantiate(Resources.Load("Prefabs/"+skills[No]));
            }
        }
        else
        {
            gameObject.renderer.material.mainTexture = buttonUp;
        }
        isMouseOver = false;
    }

    void OnMouseOver()
    {
        isMouseOver = true;
    }

}
