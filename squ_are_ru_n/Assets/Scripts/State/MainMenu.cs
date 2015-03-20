using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
    public Image imageMusic;
    public Image imageSfx;

    public Sprite imageMusicOn;
    public Sprite imageMusicOff;
    public Sprite imageSfxOn;
    public Sprite imageSfxOff;
    public static MainMenu instance;
	void Start () {
        instance = this;
        GamePlay.state = GamePlay.STATE_RUN;
        if (MouseController.HeroType == null)
        {
            MouseController.HeroType = new SuperInt(0, "HEROTYPE");
        }
        MouseController.HeroType.Load();
        MouseController.instance.setAnim(MouseController.HeroType.NUM);
       // Debug.Log(MouseController.instance);
       // Debug.Log(MouseController.HeroType);
        SaveGame.init();
        if (timeShowAds > 90 || !firstShowAdsAtBegin)
        {

            ShowADS();

        }
        MainMenu.instance.setMusic(SoundEngine.isSoundMusic);        
        MainMenu.instance.setSFX(SoundEngine.isSoundSFX);
     //   MouseController.instance.setAnim(MouseController.HeroType.NUM);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
    public static bool firstShowAdsAtBegin = false;
    static public float timeShowAds = 0;
    public static void ShowADS()
    {
        Debug.Log("Ads");
        if (timeShowAds > 90 || !firstShowAdsAtBegin)
        {
            Debug.Log("Ads1");
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
    public void setMusic(bool isMusic)
    {
        SoundEngine.isSoundMusic = isMusic;
        MouseController.instance.AdjustSound(SoundEngine.isSoundMusic);
        if (SoundEngine.isSoundMusic)
            imageMusic.sprite = imageMusicOn;
        else
            imageMusic.sprite = imageMusicOff;
    }

    public void setSFX(bool issfx)
    {
        SoundEngine.isSoundSFX = issfx;
        if (SoundEngine.isSoundSFX)
            imageSfx.sprite = imageSfxOn;
        else
            imageSfx.sprite = imageSfxOff;
        SoundEngine.instance.PlayOneShot(SoundEngine.instance._soundClick);
    }
}
