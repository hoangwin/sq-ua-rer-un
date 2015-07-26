using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlay : MonoBehaviour {

	// Use this for initialization

    public GameObject flatformTop;
    public GameObject flatformBottom;
    public GameObject GameCompleted;
    public GameObject GameIGM;    
    public GameObject GameIngame;

    public Text textCompleted;    
    

    public GameObject level;

    public static int state = 0;
    public const int STATE_WAITING = 0;
    public const int STATE_RUN = 1;
    public const int STATE_WATING_OVER = 2;
    public const int STATE_OVER = 3;
    public const int STATE_WAITTING_COMPLETED = 4;
    public const int STATE_COMPLETED = 5;

    public static float timeinSubState;
    public static int preState = 0;
    public static int nextState = 0;

    public int m_percent;
    public int m_percentNext;
    public static float[] m_totalSpace = {628,803,1180};
    

    public AudioSource audioSource;
    public static GamePlay instance;
    void Awake()
    {
        
        Application.targetFrameRate = 60;

        MouseController.instance.MusicSound = gameObject.GetComponent<AudioSource>();
         AudioClip clip = null;
        if (SelectLevel.Index == 0)
        {
            clip = (AudioClip)Resources.Load("Sound/music1") as AudioClip;            

        }
        else if (SelectLevel.Index == 1)
            clip = (AudioClip)Resources.Load("Sound/music2") as AudioClip;
        else if (SelectLevel.Index == 2)
            clip = (AudioClip)Resources.Load("Sound/music3") as AudioClip;

		MouseController.instance.MusicSound.clip = clip;
        MouseController.instance.MusicSound.loop = true;
        MouseController.instance.MusicSound.Play();
		if (SelectLevel.Index == 0)
        {
            level = (GameObject)Instantiate(Resources.Load("Level1"));
            
        }
        else if (SelectLevel.Index == 1)
            level = (GameObject)Instantiate(Resources.Load("Level2"));
        else if (SelectLevel.Index == 2)
            level = (GameObject)Instantiate(Resources.Load("Level3"));
       
    }
	void Start () {

        state = STATE_RUN;
        timeinSubState = 0;
        instance = this;
        
        if (MouseController.HeroType == null)
        {
            MouseController.HeroType = new SuperInt(0, "HEROTYPE");            
        }
        MouseController.HeroType.Load();
        MouseController.instance.setAnim(MouseController.HeroType.NUM);
     //   SelectLevel.Index = 2;// test
        SaveGame.init();

        Debug.Log(m_totalSpace);
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
                ButtonControl.instance.ButtonIGMResume();
            else
                ButtonControl.instance.ButtonIGM();
        }
    }

    void FixedUpdate()
    {
        MainMenu.timeShowAds += Time.deltaTime; 


        timeinSubState += Time.deltaTime;
        switch(state)
        {
            case STATE_WAITING:
                
                break;
            case STATE_RUN:
                break;
            case STATE_WATING_OVER:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.LoadLevel("Menu");
                    return;
                }
                if (timeinSubState > 2)
                {
                   
                    setPercent();
                    SaveGame.SaveAll();
                    if (MainMenu.timeShowAds < 90)
                        Application.LoadLevel("GamePlay");
                    else 
                        Application.LoadLevel("Menu");
                    
                }
                break;
            case STATE_OVER:
                break;
            case STATE_WAITTING_COMPLETED:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.LoadLevel("Menu");
                    return;
                }
                if (timeinSubState > 0.5)
                {
                    MainMenu.ShowADS();
                    GameCompleted.SetActive(true);
                    GameIngame.SetActive(false);
                    changeState(GamePlay.STATE_COMPLETED);
                    setPercent();
                    SaveGame.SaveAll();
                }
                break;                
        }
       
        //Debug.Log(SelectLevel.Index);
        //Debug.Log(m_totalSpace[0]);
        m_percentNext = (int)(100 * MouseController.instance.transform.position.x / m_totalSpace[SelectLevel.Index]);
        if (m_percent != m_percentNext)
        {
            m_percent = m_percentNext;
            textCompleted.text = "COMPLETED " + m_percent.ToString() + "%";
        }


	}
    public void setPercent()
    {

        if(SelectLevel.Index ==0)
        {
            if (SaveGame.Percent1.NUM < m_percent)
                SaveGame.Percent1.NUM = m_percent;
            if (SaveGame.Percent1.NUM > 100)
                SaveGame.Percent1.NUM = 100;
        }
        else if (SelectLevel.Index == 1)
        {
            if (SaveGame.Percent2.NUM < m_percent)
                SaveGame.Percent2.NUM = m_percent;
            if (SaveGame.Percent2.NUM > 100)
                SaveGame.Percent2.NUM = 100;
        }
        else if (SelectLevel.Index == 2)
        {
            if (SaveGame.Percent3.NUM < m_percent)
                SaveGame.Percent3.NUM = m_percent;
            if (SaveGame.Percent3.NUM > 100)
                SaveGame.Percent3.NUM = 100;
        }
        
    }
    public static void changeState(int _state)
    {
        timeinSubState = 0;
        preState = state;
        state = _state;
        //nextState = _state;
    }

    public Text textJump;
    public Text textAttempts;
    public Text textTime;
    public void SetIGMText()
    {
        textJump.text = "Total Jumps: " + SaveGame.jumpCount.NUM.ToString();
        textAttempts.text = "Total Attempts: " + SaveGame.attemptsCount.NUM.ToString();

        int hours = SaveGame.jumpCount.NUM / 3600;
        int minutes = (SaveGame.jumpCount.NUM % 3600) / 60;
        int seconds = (SaveGame.jumpCount.NUM % 3600) % 60;
        Debug.Log(SaveGame.jumpCount.NUM);

        textTime.text = "Total Times: " + hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString();
    }
}
