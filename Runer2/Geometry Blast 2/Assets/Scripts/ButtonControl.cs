using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonControl : MonoBehaviour {

	// Use this for initialization
    public Image imageSoundMusic;
    public Image imageSoundFx;
    public Sprite spriteSoundMusicOn;
    public Sprite spriteSoundMusicOff;
    public Sprite spriteSoundFxOn;
    public Sprite spriteSoundFxOff;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void PlayMainMenuButton()
    {
        State.instance.setSelectLevel();
    }
    public void SoundMusicButton()
    {
        SoundEngine.isSoundMusic = !SoundEngine.isSoundMusic;
        if(SoundEngine.isSoundMusic)
            imageSoundMusic.sprite = spriteSoundMusicOn;
        else
            imageSoundMusic.sprite = spriteSoundMusicOff;
        //State.instance.setSelectLevel();
    }
    public void SoundFxButton()
    {
        SoundEngine.isSoundSFX = !SoundEngine.isSoundSFX;
        if (SoundEngine.isSoundSFX)
            imageSoundFx.sprite = spriteSoundFxOn;
        else
            imageSoundFx.sprite = spriteSoundFxOff;
        //State.instance.setSelectLevel();
    }
    public void ConfirmNoButton()
    {
        State.instance.setHideQuit();
    }
    public void ConfirmYesButton()
    {
        Application.Quit();
    }
    public void QuitButton()
    {
        if(State.state == State.STATE_SELECT_LEVEL)
            State.instance.setMainMenu(true);
        else
        State.instance.setQuit();
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
        Application.OpenURL("market://details?id=com.geometry.jump");
#elif UNITY_WP8
        WP8Statics.RateApp("");
#elif UNITY_IOS
        Application.OpenURL("https://itunes.apple.com/us/app/geometry-blast/id961515680?ls=1&mt=8");	
        
         //   IOsStatic.ShowAds(" ", " ");
#endif

    }

    public void PlaySelectLevelButton()
    {
        State.instance.setGamePlay();
    }
    public void IGMButton()
    {
        State.instance.setIGM();
    }
}
