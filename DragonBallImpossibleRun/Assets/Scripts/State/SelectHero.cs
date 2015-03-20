using UnityEngine;
using System.Collections;

public class SelectHero : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MouseController.instance.setAnim(MouseController.HeroType.NUM);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Menu");
        }
	}
}
