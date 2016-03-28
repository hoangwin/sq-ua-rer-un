using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StateMainmenu : MonoBehaviour {

	// Use this for initialization
    public static float timer;
    public static StateMainmenu instance;
    public  GameObject panelMainmeneu;
    public  GameObject panelSelectLevel;
    public  GameObject panelSelectMC;    
  
    public GameObject panelGameConfirm;

    public Slider slider;

    public Image ColorPanelEffect;   

    public static int state;
    public const int STATE_MAIN_MENU = 0;
    public const int STATE_SELECT_LEVEL = 1;
    public const int STATE_SELECTMC = 2;    
    public const int STATE_QUIT = 6;

    //text select Level
    public Text SelectLevelNumLevel;
    public Text SelectLevelJump;
    public Text SelectLevelPlay;
    public Text SelectLevelPercent;
    public float indexValueWhenTranformEffect;
   public static float percentCompleted;
	void Start () {
        instance = this;
        indexValueWhenTranformEffect = 0;
        setMainMenu(false);
        Debug.Log("state" + state);      
    }

    public void setMainMenu(bool haveeffect)
    {
        state = STATE_MAIN_MENU;

        //iTween.ValueTo(ColorPanelMainmeneu.color,)
        if (haveeffect)
        {
            TrapCollection.instance.destroyAll();
            MainMC.instance.initMC();
            ColorPanelEffect.gameObject.SetActive(true);
            iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.01, "to", 1, "time", 0.5, "onupdate", "onUpdateValue"));
        }
        else
        {
            if (panelMainmeneu != null)
                panelMainmeneu.SetActive(true);
            if (panelSelectLevel != null)
                panelSelectLevel.SetActive(false);
            if (panelSelectMC != null)
                panelSelectMC.SetActive(false);
            
            if (panelGameConfirm != null)
                panelGameConfirm.SetActive(false);
            
        }
     
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
       Levels.mLevel = 0;
       state = STATE_SELECT_LEVEL;
       ColorPanelEffect.gameObject.SetActive(true);
       initLevelInFoSelectLevel(Levels.mLevel);
        iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.01, "to", 1, "time", 0.5, "onupdate", "onUpdateValue"));
       // iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("train"), "time", 50));
     //   iTween.ValueTo()
       
    }


	// Update is called once per frame


  
	
    public void setCharacterMC()
    {
        state = STATE_SELECTMC;
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
        Color c = new Color(ColorPanelEffect.color.r, ColorPanelEffect.color.g, ColorPanelEffect.color.b, i);
        ColorPanelEffect.color = c;
        indexValueWhenTranformEffect = i;
        if (i == 1)
        {
            if(state == STATE_MAIN_MENU)
            {
                if (panelMainmeneu != null)
                    panelMainmeneu.SetActive(true);
                if (panelSelectLevel != null)
                    panelSelectLevel.SetActive(false);
                if (panelSelectMC != null)
                    panelSelectMC.SetActive(false);
               
                if (panelGameConfirm != null)
                    panelGameConfirm.SetActive(false);
               
            }
            else if (state == STATE_SELECT_LEVEL)
            {
                if (panelMainmeneu != null)
                    panelMainmeneu.SetActive(false);
                if (panelSelectLevel != null)
                    panelSelectLevel.SetActive(true);
                if (panelSelectMC != null)
                    panelSelectMC.SetActive(false);
             

            }
            else if (state == STATE_SELECTMC)
            {
                panelMainmeneu.SetActive(false);
                panelSelectLevel.SetActive(false);
                panelSelectMC.SetActive(true);         
            }
                iTween.Stop(this.gameObject);
                iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.99, "to", 0, "time", 0.5, "onupdate", "onUpdateValue"));
            

        }
        else if (i == 0)
        {
            ColorPanelEffect.gameObject.SetActive(false);

        }
    }
    public void initLevelInFoSelectLevel(int level)
    {
        SaveInfo.instance.setlevel(level);
        SelectLevelNumLevel.text = "Level "+ (level +1).ToString() ;
        SelectLevelJump.text = "JUMP " + SaveInfo.levelCountJump.NUM.ToString() +" times";
        SelectLevelPlay.text=  "Play " + SaveInfo.levelCountPlay.NUM.ToString() +" times";
        SelectLevelPercent.text = "percent " + SaveInfo.levelCountPercent.NUM.ToString() + " %";
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
                case STATE_MAIN_MENU:
                    if (panelGameConfirm.activeSelf)
                        StateMainmenu.instance.setHideQuit();
                     else
                        StateMainmenu.instance.setQuit();
                    break;
                case STATE_SELECT_LEVEL:
                    StateMainmenu.instance.setMainMenu(true);
                    break;
                case STATE_SELECTMC:
                    StateMainmenu.instance.setMainMenu(true);
                    break;
              
                case STATE_QUIT: 
                    break;
            }
           // Application.Quit();
        }
        switch (state)
        {
            case STATE_MAIN_MENU:
             
                break;
            case STATE_SELECT_LEVEL:
              
                break;
           
              
                break;
            case STATE_QUIT:
                break;
        }
    }
    public void LoadGamePlay()
    {  
        Debug.Log("State :" + state);
        Application.LoadLevel("Gameplay");

        //ColorPanelEffect.gameObject.SetActive(true);
        //iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.01, "to", 1, "time", 0.5, "onupdate", "onUpdateValue"));

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
