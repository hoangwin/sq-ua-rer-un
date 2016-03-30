using UnityEngine;
using System.Collections;

public class OneButton : MonoBehaviour {

    // Use this for initialization
    public int m_index;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ButtonCharacterPress()
    {
        SoundEngine.instance.PlayOneShot(SoundEngine.instance._soundClick);
        SelectCharacter.m_instance.setMaterial(m_index);
    }
}
