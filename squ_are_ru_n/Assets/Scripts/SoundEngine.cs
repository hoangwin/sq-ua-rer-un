using UnityEngine;
using System.Collections;

public class SoundEngine : MonoBehaviour {
	public static bool isSoundSFX = true;
    public static bool isSoundMusic = true;
    
    //public AudioClip _soundBG1 = null;
    //public AudioClip _soundBG2 = null;
  
    public AudioClip _soundClick = null;
    public AudioClip _soundExplotion = null;
    public AudioClip _soundEnd = null;
    
    public static SoundEngine instance;
    void Start()
    {
        if (instance != null)
        {
            Debug.Log("Destroy This");
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        //this.gameObject.
   //     SoundEngine.getInstance().PlayLoop(SoundEngine.getInstance()._soundBG1);
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
                audio.PlayOneShot(e);
            }
    }
    // Update is called once per frame
    public void PlayLoop(AudioClip e)
    {
        
        if (isSoundMusic)
        {
            if (audio != null && e != null)
            {
                audio.clip = e;
                audio.loop = true;
                if (!audio.isPlaying)
                    audio.Play();
            }
        }
    }
    public void stopSound()
    {
        audio.Stop();
    }

	// Update is called once per frame
	void Update () {
	
	}

	
}
