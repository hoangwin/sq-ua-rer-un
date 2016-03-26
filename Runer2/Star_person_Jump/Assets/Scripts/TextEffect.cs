using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextEffect : MonoBehaviour {

	// Use this for initialization
    public int type;
    public Image image;
    bool isBlinking = true;

    void Start()
    {
      
        //Call coroutine BlinkText on Start
        StartCoroutine(BlinkText());
        //call function to check if it is time to stop the flashing.
     //   StartCoroutine(StopBlinking());
    }

    //function to blink the text 
    public IEnumerator BlinkText()
    {
        //blink it forever. You can set a terminating condition depending upon your requirement. Here you can just set the isBlinking flag to false whenever you want the blinking to be stopped.
        while (isBlinking)
        {
            //set the Text's text to blank
            image.enabled = false;
           
            //display blank text for 0.5 seconds
            yield return new WaitForSeconds(.5f);
            //display “I AM FLASHING TEXT” for the next 0.5 seconds//         
            image.enabled = true;
            yield return new WaitForSeconds(.5f);
        }
    }
    //your logic here. I have set the isBlinking flag to false after 5 seconds
    IEnumerator StopBlinking()
    {
        //wait for 5 seconds
        yield return new WaitForSeconds(5f);
        //stop the blinking
        isBlinking = false;
        //set a different text just for sake of clarity
        //flashingText.text = staticText;
        image.enabled = true;
    }
}
