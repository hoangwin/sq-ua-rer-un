﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class State : MonoBehaviour {

	// Use this for initialization
    public static float timer;
    public static State instance;
    public  GameObject panelMainmeneu;
    public  GameObject panelSelectLevel;
    public  GameObject panelIngame;    
    public GameObject panelGamePause;
    public GameObject panelGameOver;
    public GameObject panelGameWin;
    public GameObject panelGameConfirm;

    public Image ColorPanelEffect;   

    public static int state = 0;
    public static int STATE_MAIN_MENU = 0;
    public static int STATE_SELECT_LEVEL = 1;
    public static int STATE_GAMEPLAY = 2;
    public static int STATE_PAUSE = 3;
    public static int STATE_OVER = 4;
    public static int STATE_WIN = 5;
    public static int STATE_QUIT = 6;

    //text select Level
    public Text SelectLevelNumLevel;
    public Text SelectLevelJump;
    public Text SelectLevelPlay;
    public Text SelectLevelPercent;

	void Start () {
        instance = this;
        
        setMainMenu(false);
        
	}

    public void setMainMenu(bool haveeffect)
    {
        state = STATE_MAIN_MENU;
         //iTween.ValueTo(ColorPanelMainmeneu.color,)
        if (haveeffect)
        {
            TrapCollection.instance.destroyAll();
            MainMC.isDead = false;
            ColorPanelEffect.gameObject.SetActive(true);
            iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.01, "to", 1, "time", 0.5, "onupdate", "onUpdateValue"));
        }
        else
        {
            panelMainmeneu.SetActive(true);
            panelSelectLevel.SetActive(false);
            panelIngame.SetActive(false);
            panelGamePause.SetActive(false);
            panelGameOver.SetActive(false);
            panelGameConfirm.SetActive(false);
        }
       
    }

    public void setIGM()
    {
        state = STATE_PAUSE;
        Time.timeScale = 0;
        panelMainmeneu.SetActive(false);
        panelSelectLevel.SetActive(false);
        panelIngame.SetActive(false);
        panelGamePause.SetActive(true);
        panelGameOver.SetActive(false);
    }
    
    public void setResume()
    {
        state = STATE_GAMEPLAY;        
        panelMainmeneu.SetActive(false);
        panelSelectLevel.SetActive(false);
        panelIngame.SetActive(true);
        panelGamePause.SetActive(false);
        panelGameOver.SetActive(false);
    }
    public void setReplay()
    {
        state = STATE_GAMEPLAY;

        panelMainmeneu.SetActive(false);
        panelSelectLevel.SetActive(false);
        panelIngame.SetActive(true);
        panelGamePause.SetActive(false);
        panelGameOver.SetActive(false);
        TrapCollection.instance.destroyAll();
        MainMC.isDead = false;
        TrapCollection.instance.TrapInit();
    }
    public void setGameOver()
    {
        state = STATE_OVER;
        panelMainmeneu.SetActive(false);
        panelSelectLevel.SetActive(false);
        panelIngame.SetActive(false);
        panelGamePause.SetActive(false);
        panelGameOver.SetActive(true);
    }

    public void setQuit()
    {
    
        panelGameConfirm.SetActive(true);
    }
    public void setHideQuit()
    {    
        panelGameConfirm.SetActive(false);
    }
    public void setSelectLevel()
   {

       state = STATE_SELECT_LEVEL;
       ColorPanelEffect.gameObject.SetActive(true);
        initLevel(0);
        iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.01, "to", 1, "time", 0.5, "onupdate", "onUpdateValue"));
       // iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("train"), "time", 50));
     //   iTween.ValueTo()
       
    }


	// Update is called once per frame


    public void setGamePlay()
    {

        state = STATE_GAMEPLAY;
        ColorPanelEffect.gameObject.SetActive(true);
        iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.01, "to", 1, "time", 0.5, "onupdate", "onUpdateValue"));
        // iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("train"), "time", 50));
        //   iTween.ValueTo()

    }
    void onUpdateValue(float i)
    {
        Color c = new Color(ColorPanelEffect.color.r, ColorPanelEffect.color.g, ColorPanelEffect.color.b, i);
        ColorPanelEffect.color = c;
        if (i == 1)
        {
            if(state == STATE_MAIN_MENU)
            {
                panelMainmeneu.SetActive(true);
                panelSelectLevel.SetActive(false);
                panelIngame.SetActive(false);
                panelGamePause.SetActive(false);
                panelGameOver.SetActive(false);
                panelGameConfirm.SetActive(false);
            }
            else if (state == STATE_SELECT_LEVEL)
            {
                panelMainmeneu.SetActive(false);
                panelSelectLevel.SetActive(true);
                panelIngame.SetActive(false);
                panelGamePause.SetActive(false);
                panelGameOver.SetActive(false);

            }
            else if (state == STATE_GAMEPLAY)
            {
                panelMainmeneu.SetActive(false);
                panelSelectLevel.SetActive(false);
                panelIngame.SetActive(true);
                panelGamePause.SetActive(false);
                panelGameOver.SetActive(false);
                TrapCollection.instance.TrapInit();
            }
                iTween.Stop(this.gameObject);
                iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.99, "to", 0, "time", 0.5, "onupdate", "onUpdateValue"));
            

        }
        else if (i == 0)
        {
            ColorPanelEffect.gameObject.SetActive(false);

        }
    }
    public void initLevel(int level)
    {
       SaveInfo.instance.setlevel(level);
    SelectLevelNumLevel.text = "Level "+ (level +1).ToString() ;
    SelectLevelJump.text = "JUMP " + SaveInfo.instance.levelCountJump.NUM.ToString() +" times";
    SelectLevelPlay.text=  "Play " + SaveInfo.instance.levelCountPlay.NUM.ToString() +" times";
    SelectLevelPercent.text = "percent " + SaveInfo.instance.levelCountPercent.NUM.ToString() + " %";
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }
    // Update is called once per frame
  
}