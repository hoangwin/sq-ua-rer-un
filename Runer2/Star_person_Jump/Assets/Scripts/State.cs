﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class State : MonoBehaviour {

	// Use this for initialization
    public static float timer;
    public static State instance;
    public  GameObject panelIngame;    
    public GameObject panelGamePause;
    public GameObject panelGameOver;
    public GameObject panelGameWin;
    public GameObject panelGameConfirm;
    Vector3 posGameOver;
    Vector3 posGameWin;
    public Slider slider;

    public Image ColorPanelEffect;

    public GameObject[] m_Background;
    public Color[] m_ColorCircle;
    public Material m_MaterialCircle;
    public static int state;
    public const int STATE_GAMEPLAY = 2;
    public const int STATE_PAUSE = 3;
    public const int STATE_OVER = 4;
    public const int STATE_WIN = 5;
    public const int STATE_QUIT = 6;
    
    public float indexValueWhenTranformEffect;
   public static float percentCompleted;
    
	void Start () {
        instance = this;
        indexValueWhenTranformEffect = 0;
        
        
        posGameOver = new Vector3(panelGameOver.transform.position.x, panelGameOver.transform.position.y, panelGameOver.transform.position.z);
        posGameWin = new Vector3(panelGameWin.transform.position.x, panelGameWin.transform.position.y, panelGameWin.transform.position.z);
        State.instance.setGamePlay();
        setColorLevel();
    }
  
  

    public void setIGM()
    {
        state = STATE_PAUSE;
        Time.timeScale = 0;
      
        panelIngame.SetActive(false);
        panelGamePause.SetActive(true);
        panelGameOver.SetActive(false);
    }
    
    public void setResume()
    {
        state = STATE_GAMEPLAY;        

        panelIngame.SetActive(true);
        panelGamePause.SetActive(false);
        panelGameOver.SetActive(false);
    }
 
    public void setGameOver()
    {
      
        state = STATE_OVER;
        SaveInfo.instance.Savelevel(SaveInfo._currentCountJump, (int)(percentCompleted * 100)-1, 1);
        panelIngame.SetActive(false);
        panelGamePause.SetActive(false);       
        panelGameOver.SetActive(true);
        panelGameOver.transform.position = new Vector3(posGameOver.x, posGameOver.y, posGameOver.z);
        iTween.MoveFrom(panelGameOver, iTween.Hash("y", -5, "time", 1));
        ShowADS();
    }
    public void setGameWin()
    {   
        SaveInfo.instance.Savelevel(SaveInfo._currentCountJump, 100,1);
      //  MainMC.instance.animator.SetInteger("State", 0);//state 0 = nanim none
        state = STATE_WIN;
        panelIngame.SetActive(false);
        panelGamePause.SetActive(false);
        panelGameOver.SetActive(false);
        panelGameWin.SetActive(true);
        panelGameWin.transform.position = new Vector3(posGameOver.x, posGameOver.y, posGameOver.z);
       iTween.MoveFrom(panelGameWin, iTween.Hash("y", -5, "time", 1));
    }
    public void setQuit()
    {
    
        panelGameConfirm.SetActive(true);
    }
    public void setHideQuit()
    {    
        panelGameConfirm.SetActive(false);
    }


	// Update is called once per frame


  
	 public void setGamePlay()
    {
        
        state = STATE_GAMEPLAY;
      
        ColorPanelEffect.gameObject.SetActive(true);
        iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.01, "to", 1, "time", 0.5, "onupdate", "onUpdateValue"));

    }
	
    public void setReplay()
    {
        
        state = STATE_GAMEPLAY;
        ColorPanelEffect.gameObject.SetActive(true);
        iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.01, "to", 1, "time", 0.5, "onupdate", "onUpdateValue"));
        //state = STATE_GAMEPLAY;
        //panelMainmeneu.SetActive(false);
        //panelSelectLevel.SetActive(false);
        //panelIngame.SetActive(true);
        //panelGamePause.SetActive(false);
        //panelGameOver.SetActive(false);
        //panelGameWin.SetActive(false);        
       // TrapCollection.instance.TrapInit();

    }
    void onUpdateValue(float i)
    {
        if (state != STATE_GAMEPLAY)
        {
            Color c = new Color(ColorPanelEffect.color.r, ColorPanelEffect.color.g, ColorPanelEffect.color.b, i);

            ColorPanelEffect.color = c;
        }
        indexValueWhenTranformEffect = i;
        if (i == 1)
        {
            if (state == STATE_GAMEPLAY)
            {
                panelIngame.SetActive(true);
                panelGamePause.SetActive(false);
                panelGameOver.SetActive(false);
                panelGameWin.SetActive(false);
                SaveInfo.resetAllTempVarial();
                TrapCollection.instance.destroyAll();
                TrapCollection.instance.TrapInit();       
         
                MainMC.instance.initMC();
                BG.angleRotation = 0;
                
                if ( Levels.m_LevelIndex == 0)
                SoundEngine.instance.PlayLoop(SoundEngine.getInstance()._soundBG1);
                else if (Levels.m_LevelIndex == 1)
                    SoundEngine.instance.PlayLoop(SoundEngine.getInstance()._soundBG2);
                else
                    SoundEngine.instance.PlayLoop(SoundEngine.getInstance()._soundBG3);
                
            }
                iTween.Stop(this.gameObject);
                iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.99, "to", 0, "time", 0.5, "onupdate", "onUpdateValue"));
            

        }
        else if (i == 0)
        {
            ColorPanelEffect.gameObject.SetActive(false);

        }
    }

    public void setColorLevel()
    {
        if (Levels.m_LevelIndex == 0)
        {
            m_Background[0].SetActive(true);
            m_Background[1].SetActive(false);
            m_Background[2].SetActive(false);
            m_MaterialCircle.color = m_ColorCircle[0];
        }
        else if (Levels.m_LevelIndex == 1)
        {
            m_Background[0].SetActive(false);
            m_Background[1].SetActive(true);
            m_Background[2].SetActive(false);
            m_MaterialCircle.color = m_ColorCircle[1];
        }
        else
        {
            m_Background[0].SetActive(false);
            m_Background[1].SetActive(false);
            m_Background[2].SetActive(true);
            m_MaterialCircle.color = m_ColorCircle[2];
        }
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }
    void Update()
    {
        timeShowAds += Time.deltaTime; 

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (indexValueWhenTranformEffect != 0 && indexValueWhenTranformEffect != 1)
                return;
            switch(state)
            {
               
                case STATE_GAMEPLAY:
                    State.instance.setIGM();
                    break;
                case STATE_PAUSE:
                    ButtonControl.instance.ResumeButton();;
                    break;
                case STATE_OVER:
                    ButtonControl.instance.IGMGOMenuButton();
                    break;
                case STATE_WIN :
                    ButtonControl.instance.IGMGOMenuButton();
                    break;
                case STATE_QUIT: 
                    break;
            }
           // Application.Quit();
        }
        switch (state)
        {
          
            case STATE_GAMEPLAY:
                updatePercent();
                break;
            case STATE_PAUSE:
              
                break;
            case STATE_OVER:
             
                break;
            case STATE_WIN:
              
                break;
            case STATE_QUIT:
                break;
        }
    }
    void updatePercent()
    {
        if(BG.angleRotation>45)

        {
            percentCompleted = (BG.angleRotation - 45) / Levels.maxAngle;
        slider.value = percentCompleted;
        }
        else
        {
            slider.value = 0.01f;
        }
        //Debug.Log("percentCompleted :" + percentCompleted);
    }
    // Update is called once per frame
    public static bool firstShowAdsAtBegin = false;
    static public float timeShowAds = 0;
    public static void ShowADS()
    {
       // Debug.Log("Ads");
        if (timeShowAds > 90 || !firstShowAdsAtBegin)
        {
          //  Debug.Log("Ads1");
            if (!firstShowAdsAtBegin)
                firstShowAdsAtBegin = true;
            timeShowAds = 0;
#if UNITY_ANDROID
            using (AndroidJavaClass jc = new AndroidJavaClass("com.geometry.blast.UnityPlayerNativeActivity"))
            {
                jc.CallStatic<int>("ShowAds");
            }

#elif UNITY_WP8

            WP8Statics.ShowAds("");
#elif UNITY_IOS
            IOsStatic.ShowAds(" ", " ");
#endif
        }
    }

}
