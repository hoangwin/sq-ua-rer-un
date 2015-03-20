using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour {

	// Use this for initialization
    public static ButtonControl instance;
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void MainMenuSelectHeroButton()
    {
        Application.LoadLevel("SelectHero");
    }
    public void MainMenuMPlayButton()
    {
        Application.LoadLevel("SelectLevel");
    }
    public void StatsButton()
    {
        Application.LoadLevel("Stats");
    }
    public void ButtonRatePress()
    {
        //  SoundEngine.getInstance().PlayOneShot(SoundEngine.getInstance()._soundclick);
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.geometry.blast");
#elif UNITY_WP8
        WP8Statics.RateApp("");
#elif UNITY_IOS
        Application.OpenURL("https://itunes.apple.com/us/app/bubble-shoot-free/id914220826?ls=1&mt=8");	
        
         //   IOsStatic.ShowAds(" ", " ");
#endif

    }
    public void MusicButton()
    {
        MainMenu.instance.setMusic(!SoundEngine.isSoundMusic);
    }
    public void SfxButton()
    {
        MainMenu.instance.setSFX(!SoundEngine.isSoundSFX);
    }
    public void ButtonMoreGamePress()
    {
        //  SoundEngine.getInstance().PlayOneShot(SoundEngine.getInstance()._soundclick);

        Application.OpenURL("http://aegamemobile.com");

    }

    public void ReplayButton()
    {
        Application.LoadLevel("GamePlay");
    }
    public void BackMainMenuButton()
    {
        Application.LoadLevel("Menu");
    }
    public void SelectLevelLeftButton()
    {
        SelectLevel.instance.setIndex(-1);
        SoundEngine.instance.PlayOneShot(SoundEngine.instance._soundClick);

    }
    public void SelectLevelRightButton()
    {
        SelectLevel.instance.setIndex(1);
        SoundEngine.instance.PlayOneShot(SoundEngine.instance._soundClick);
    }

    public void SelectLevelPlayButton()
    {
        Application.LoadLevel("GamePlay");
    }

    public void SelectHero1Button()
    {
        MouseController.instance.setAnim(0);
        SoundEngine.instance.PlayOneShot(SoundEngine.instance._soundClick);
    }
    public void SelectHero2Button()
    {
        MouseController.instance.setAnim(1);
        SoundEngine.instance.PlayOneShot(SoundEngine.instance._soundClick);
    }
    public void SelectHero3Button()
    {
        MouseController.instance.setAnim(2);
        SoundEngine.instance.PlayOneShot(SoundEngine.instance._soundClick);
    }
    public void SelectHero4Button()
    {
        MouseController.instance.setAnim(3);
        SoundEngine.instance.PlayOneShot(SoundEngine.instance._soundClick);
    }


    public void ButtonIGM()
    {
        MouseController.instance.AdjustSound(SoundEngine.isSoundMusic);
        GamePlay.instance.GameIGM.SetActive(true);
        GamePlay.instance.SetIGMText();
        Time.timeScale = 0;
        MouseController.instance.MusicSound.Pause();
        GamePlay.instance.GameIngame.SetActive(false);
        MouseController.instance.setAnim(3);
        
    }
    public void ButtonIGMResume()
    {
        GamePlay.instance.GameIGM.SetActive(false);
        GamePlay.instance.GameIngame.SetActive(true);
        Time.timeScale = 1;
        MouseController.instance.setAnim(3);
        MouseController.instance.MusicSound.Play();
        MouseController.instance.AdjustSound(SoundEngine.isSoundMusic);
    }
    public void ButtonIGM_BackMenu()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Menu");
    }
    //
}
