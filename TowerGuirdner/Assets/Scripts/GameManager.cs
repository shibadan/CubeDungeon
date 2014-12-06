﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    EnemyMaker enemy;
    FrameManager frame;

    Button[] buttons;

	// Use this for initialization
	void Start () {
        enemy = FindObjectOfType<EnemyMaker>();
        frame = FindObjectOfType<FrameManager>();
        buttons = FindObjectsOfType<Button>();
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            enemy.stop();
            frame.stop();
            foreach (Button b in buttons)
            {
                b.stop();
            }
        }

        if (Input.GetKeyDown("w"))
        {
            enemy.restart();
            frame.restart();
            foreach (Button b in buttons)
            {
                b.restart();
            }
        }
    }
	


}