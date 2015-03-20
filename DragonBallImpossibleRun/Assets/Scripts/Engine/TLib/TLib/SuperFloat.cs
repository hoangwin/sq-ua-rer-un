using UnityEngine;
using System.Collections;

public class SuperFloat : MonoBehaviour {

	public float NUM =0;
	float NUM_DEFAULT =0;
	string KEY = "unitystt";
	public SuperFloat(int initv, string key)
	{
		KEY = key;
		NUM = initv;
		NUM_DEFAULT = initv;
		Load ();
	}
	public float Get()
	{
		return NUM;
	}
	public void Set(float x)
	{
		NUM = x;
	}
	public void SetAndSave(float x)
	{
		NUM = x;
		Save ();
	}
	public void Plus(int x)
	{
		NUM += x;
	}
	public void PlusAndSave(int x)
	{
		NUM += x;
		Save ();
	}
	public void Save()
	{
		PlayerPrefs.SetFloat(KEY, NUM);
	}
	public void Load()
	{
			NUM = PlayerPrefs.GetFloat (KEY, NUM_DEFAULT);
	}
}
