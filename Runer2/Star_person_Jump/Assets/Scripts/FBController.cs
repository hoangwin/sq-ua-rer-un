using UnityEngine;
using System.Collections;

public class FBController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private const string FACEBOOK_APP_ID = "520119834803823";
    private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";

    void ShareToFacebook(string linkParameter, string nameParameter, string captionParameter, string descriptionParameter, string pictureParameter, string redirectParameter)
    {
        Application.OpenURL(FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
        "&link=" + WWW.EscapeURL(linkParameter) +
        "&name=" + WWW.EscapeURL(nameParameter) +
        "&caption=" + WWW.EscapeURL(captionParameter) +
        "&description=" + WWW.EscapeURL(descriptionParameter) +
        "&picture=" + WWW.EscapeURL(pictureParameter) +
        "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
    }
    public static void ShareToFacebookSample(string linkParameter, string nameParameter, string captionParameter, string descriptionParameter, string pictureParameter, string redirectParameter)
    {
        Application.OpenURL(FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
        "&link=" + WWW.EscapeURL("http://aegamemobile.com/web/index.php") +
        "&name=" + WWW.EscapeURL("Geometry Jump") +
        "&caption=" + WWW.EscapeURL("Please try this gameObject. ") +
        "&description=" + WWW.EscapeURL("Please try this gameObject.") +
        "&picture=" + WWW.EscapeURL("https://lh3.googleusercontent.com/7IVM0IjwTHii1gB6tQ5W63qmUfATlfPif3s695kgfyROzeZzr3l51RJF4UjVkZOSxA4=w300-rw") +
        "&redirect_uri=" + WWW.EscapeURL("http://aegamemobile.com/web/index.php"));
    }
}
