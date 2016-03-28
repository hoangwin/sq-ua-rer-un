using UnityEngine;
using System.Collections;

public class SoundEngine : MonoBehaviour {
	public static bool isSoundSFX = true;
    public static bool isSoundMusic = true;

    //public AudioClip _soundBG1 = null;
    //public AudioClip _soundBG2 = null;
    public AudioSource _soundFx = null;
    public AudioSource _soundMusic = null;

    public AudioClip _soundClick = null;
    public AudioClip _soundJump = null;
    public AudioClip _soundExplotion = null;
    public AudioClip _soundEnd = null;
    public AudioClip _soundBGMenu = null;
    public AudioClip _soundBG1 = null;
    public AudioClip _soundBG2 = null;
    public AudioClip _soundBG3 = null;
    
    public static SoundEngine instance;
    void Start()
    {
        //   if (instance != null)
        //   {
        //       Debug.Log("Destroy This");
        //       Destroy(this);
        //   }
        //   else
        //   {
        //        DontDestroyOnLoad(this);
        //        instance = this;
        //   }
        //  //this.gameObject.
        // //     SoundEngine.getInstance().PlayLoop(SoundEngine.getInstance()._soundBG1);
        
        instance = this;
    }
    public static SoundEngine getInstance()
    {
        if(instance == null)
        {
            instance = new SoundEngine();
        }
        return instance;
    }
    public void PlayOneShot(AudioClip e)
    {

        if (e == null)
            return;
       // if (!e..isPlaying)
            if (isSoundSFX)
            {
            _soundFx.PlayOneShot(e);
            }
    }
    // Update is called once per frame
    public void PlayLoop(AudioClip e)
    {
        
        if (isSoundMusic)
        {
            if (GetComponent<AudioSource>() != null && e != null)
            {
                _soundMusic.clip = e;
                _soundMusic.loop = true;
                if (!_soundMusic.isPlaying)
                    _soundMusic.Play();
            }
        }
    }
    public void stopSound()
    {
        GetComponent<AudioSource>().Stop();
    }

	// Update is called once per frame
	void Update () {
	
	}

	
}
