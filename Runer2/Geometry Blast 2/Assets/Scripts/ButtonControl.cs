﻿using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void PlayMainMenuButton()
    {
        State.instance.setSelectLevel();
    }
    public void PlaySelectLevelButton()
    {
        State.instance.setGamePlay();
    }
}
