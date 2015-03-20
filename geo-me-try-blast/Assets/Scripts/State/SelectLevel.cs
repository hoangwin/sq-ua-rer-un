using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectLevel : MonoBehaviour {

	// Use this for initialization
    public static int Index = 0;
    public static SelectLevel instance;
    public Text textLevel;
    public Text textName;
    public Text textCompleted;
    public GameObject buttonPlay;

	void Start () {
        if (MouseController.HeroType == null)
        {
            MouseController.HeroType = new SuperInt(0, "HEROTYPE");
        }
        MouseController.HeroType.Load();
        MouseController.instance.setAnim(MouseController.HeroType.NUM);
        Index = 0;
        instance = this;
        SaveGame.init();
        setIndex(0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Menu");
        }
	}
    public void setIndex(int i)
    {
        Index += i;
        if (Index < 0)
            Index = 2;
        else if (Index > 2)
            Index = 0;

        switch(Index)
        {
            case 0:
                buttonPlay.SetActive(true);
                    textLevel.text = "Level 1";
                    textName.text ="RUN AWAY";
                    textCompleted.text = SaveGame.Percent1.NUM.ToString() +"%";
                break;
            case 1:
                buttonPlay.SetActive(true);
                    textLevel.text = "Level 2";
                    textName.text ="JUMP JUMP UNLIMITED";
                    textCompleted.text = SaveGame.Percent2.NUM.ToString() + "%";
                break;
            case 2:
                buttonPlay.SetActive(true);
                    textLevel.text = "Level 3";
                    textName.text ="LAST CHAPTER";
                    textCompleted.text = SaveGame.Percent3.NUM.ToString() + "%";;
                break;
        }
    }
}
