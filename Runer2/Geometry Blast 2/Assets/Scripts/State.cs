using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class State : MonoBehaviour {

	// Use this for initialization
    public static float timer;
    public static State instance;
    public  GameObject panelMainmeneu;
    public  GameObject panelSelectLevel;
    public  GameObject panelIngameMenu;
    
    

    public Image ColorPanelEffect;
   

    public static int state = 0;
    public static int STATE_MAIN_MENU = 0;
    public static int STATE_SELECT_LEVEL = 1;
    public static int STATE_GAMEPLAY = 2;
	void Start () {
        instance = this;
        
        setMainMenu(false);
        
	}

    public void setMainMenu(bool haveeffect)
    {
        state = STATE_MAIN_MENU;
         //iTween.ValueTo(ColorPanelMainmeneu.color,)
        if (true)
        {
            ColorPanelEffect.gameObject.SetActive(true);
            iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.99, "to", 0, "time", 0.5, "onupdate", "onUpdateValue"));
        }
        panelMainmeneu.SetActive(true);
        panelSelectLevel.SetActive(false);
        panelIngameMenu.SetActive(false);
        
    }
  
    public void setSelectLevel()
   {

       state = STATE_SELECT_LEVEL;
       ColorPanelEffect.gameObject.SetActive(true);
        iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.01, "to", 1, "time", 0.5, "onupdate", "onUpdateValue"));
       // iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("train"), "time", 50));
     //   iTween.ValueTo()
       
    }
	// Update is called once per frame


    public void setGamePlay()
    {

        state = STATE_GAMEPLAY;
        ColorPanelEffect.gameObject.SetActive(true);
        iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.01, "to", 1, "time", 0.5, "onupdate", "onUpdateValue"));
        // iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("train"), "time", 50));
        //   iTween.ValueTo()

    }
    void onUpdateValue(float i)
    {
        Color c = new Color(ColorPanelEffect.color.r, ColorPanelEffect.color.g, ColorPanelEffect.color.b, i);
        ColorPanelEffect.color = c;
        if (i == 1)
        {
            if (state == STATE_SELECT_LEVEL)
            {
                panelMainmeneu.SetActive(false);
                panelSelectLevel.SetActive(true);
                panelIngameMenu.SetActive(false);

            }
            else if (state == STATE_GAMEPLAY)
            {
                panelMainmeneu.SetActive(false);
                panelSelectLevel.SetActive(false);
                panelIngameMenu.SetActive(true);
                TrapCollection.instance.TrapInit();
            }
                iTween.Stop(this.gameObject);
                iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.99, "to", 0, "time", 0.5, "onupdate", "onUpdateValue"));
            

        }
        else if (i == 0)
        {
            ColorPanelEffect.gameObject.SetActive(false);

        }
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }
    // Update is called once per frame
  
}
