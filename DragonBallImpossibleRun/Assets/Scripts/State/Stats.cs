using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Stats : MonoBehaviour {

	// Use this for initialization
    public Text textJump;
    public Text textAttempts;
    public Text textTime;
	void Start () {
        if (MouseController.HeroType == null)
        {
            MouseController.HeroType = new SuperInt(0, "HEROTYPE");
        }
        MouseController.HeroType.Load();
        MouseController.instance.setAnim(MouseController.HeroType.NUM);
        SaveGame.init();
        textJump.text = "Total Jumps: " +SaveGame.jumpCount.NUM.ToString();
        textAttempts.text = "Total Attempts: " + SaveGame.attemptsCount.NUM.ToString();
       
        int hours = SaveGame.jumpCount.NUM / 3600;
        int minutes = (SaveGame.jumpCount.NUM % 3600) / 60;
        int seconds = (SaveGame.jumpCount.NUM % 3600) % 60;
        Debug.Log(SaveGame.jumpCount.NUM);

        textTime.text = "Total Times: " + hours.ToString() + ":" + minutes.ToString() +":"+ seconds.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Menu");
        }
	}
}
