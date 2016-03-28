using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonControl : MonoBehaviour {

	// Use this for initialization
    public Image imageSoundMusic;
    public Image imageSoundFx;
    public Image imageSoundMusicSelectLevel;
    public Image imageSoundFxSelectLevel;

    public Sprite spriteSoundMusicOn;
    public Sprite spriteSoundMusicOff;
    public Sprite spriteSoundFxOn;
    public Sprite spriteSoundFxOff;

    public static ButtonControl instance;
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void PlayMainMenuButton()
    {
        StateMainmenu.instance.setSelectLevel();
    }
    public void SoundMusicButton()
    {
        SoundEngine.isSoundMusic = !SoundEngine.isSoundMusic;
        if (SoundEngine.isSoundMusic)
        {
            imageSoundMusic.sprite = spriteSoundMusicOn;
            imageSoundMusicSelectLevel.sprite = spriteSoundMusicOn;
        }
        else
        {
            imageSoundMusic.sprite = spriteSoundMusicOff;
            imageSoundMusicSelectLevel.sprite = spriteSoundMusicOff;
            SoundEngine.instance.stopSound();
        }
        SoundEngine.instance.PlayLoop(SoundEngine.instance._soundBGMenu);
    }
    public void SoundFxButton()
    {
        SoundEngine.isSoundSFX = !SoundEngine.isSoundSFX;
        if (SoundEngine.isSoundSFX)
        {
            imageSoundFx.sprite = spriteSoundFxOn;
            imageSoundFxSelectLevel.sprite = spriteSoundFxOn;
        }
        else
        {
            imageSoundFx.sprite = spriteSoundFxOff;
            imageSoundFxSelectLevel.sprite = spriteSoundFxOff;
        }
        SoundEngine.instance.PlayOneShot(SoundEngine.instance._soundClick);
    }
    public void ConfirmNoButton()
    {
        StateMainmenu.instance.setHideQuit();
    }
    public void ConfirmYesButton()
    {
        Application.Quit();
    }
    public void QuitButton()
    {
        if (StateMainmenu.state == StateMainmenu.STATE_SELECT_LEVEL || StateMainmenu.state == StateMainmenu.STATE_SELECTMC)
            StateMainmenu.instance.setMainMenu(true);
        else
            StateMainmenu.instance.setQuit();
        //State.instance.setSelectLevel();
    }
    public void FBShared()
    {
        FBController.ShareToFacebookSample("","","","","","");
    }
    public void ButtonRatePress()
    {
        //  SoundEngine.getInstance().PlayOneShot(SoundEngine.getInstance()._soundclick);
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.geometry.blast");
#elif UNITY_WP8
        WP8Statics.RateApp("");
#elif UNITY_IOS
        Application.OpenURL("https://itunes.apple.com/us/app/geometry-blast/id961515680?ls=1&mt=8");	
        
         //   IOsStatic.ShowAds(" ", " ");
#endif

    }

    public void PlaySelectLevelButton()
    {
        StateMainmenu.instance.LoadGamePlay();
     //   SoundEngine.instance.PlayLoop(SoundEngine.instance._soundBG1);
    }
    public void ChooseMCCharacterButton()
    {

        StateMainmenu.state = StateMainmenu.STATE_SELECTMC;
        StateMainmenu.instance.ColorPanelEffect.gameObject.SetActive(true);
        iTween.ValueTo(StateMainmenu.instance.gameObject, iTween.Hash("from", 0.01, "to", 1, "time", 0.5, "onupdate", "onUpdateValue"));
        // iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("train"), "time", 50));
        //   iTween.ValueTo()

    }
    public void IGMButton()
    {
        State.instance.setIGM();
    }
    public void IGMGOMenuButton()
    {
        Time.timeScale = 1;
        //  State.instance.setMainMenu(true); //here
        Application.LoadLevel("Menu");
    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
        State.instance.setResume();
    }
    public void ReplayButton()
    {
        Time.timeScale = 1;
        State.instance.setReplay();
    }
    public void NextButton()
    {
        //them o day de doi sang man moi
        Time.timeScale = 1;
        State.instance.setReplay();
    }

    public void SelectLevelLeft()
    {
      Levels.mLevel--;
      if (Levels.mLevel < 0)
          Levels.mLevel = 2;
        StateMainmenu.instance.initLevelInFoSelectLevel(Levels.mLevel);
    }
    public void SelectLevelRight()
    {

        Levels.mLevel++;
        if (Levels.mLevel >2)
            Levels.mLevel = 0;
        StateMainmenu.instance.initLevelInFoSelectLevel(Levels.mLevel);
    }
}
