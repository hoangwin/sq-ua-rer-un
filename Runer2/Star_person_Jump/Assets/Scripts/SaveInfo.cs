using UnityEngine;
using System.Collections;

public class SaveInfo : MonoBehaviour {

	// Use this for initialization
    public SuperInt levelCountJump;//dung cho mot level bat ki
    public SuperInt levelCountPlay;//dung cho mot level bat ki
    public SuperInt levelCountPercent;//dung cho mot level bat ki

    public static  int _currentCountJump;//dung cho mot level bat ki
   // public static  int _currentCountPlay;//dung cho mot level bat ki
    public static int _currentCountPercent;//dung cho mot level bat ki
    public SuperInt[][] DataInfo;
    public const int MAXLEVEL = 3;
    public static SaveInfo instance;
	void Start () {
        //PlayerPrefs.DeleteAll();
        loadAll();      
        instance = this;
	}
	void init()
    {
        DataInfo = new SuperInt[MAXLEVEL][];//[MAXLEVEL]();
        for (int i = 0; i < MAXLEVEL; i++)
        {
            DataInfo[i] = new SuperInt[3];
            DataInfo[i][0] = new SuperInt(0, "COUNTJUMP" + 1 + i);
            DataInfo[i][1] = new SuperInt(0, "COUNTPLAY" + 1 + i);
            DataInfo[i][2] = new SuperInt(0, "COUNTPERCENT" + 1 + i);
        }
    }
    public static void resetAllTempVarial()
    {
         _currentCountJump = 0;//dung cho mot level bat ki
       //  _currentCountPlay = 0;//dung cho mot level bat ki
         _currentCountPercent = 0;
    }
    void loadAll()
    {
        init();
        for (int i = 0; i < MAXLEVEL; i++)
        {

            DataInfo[i][0].Load();
            DataInfo[i][1].Load();
            DataInfo[i][2].Load();
        }
    }
    public void setlevel(int level)
    {
        levelCountJump =  DataInfo[level][0];//
        levelCountPlay=  DataInfo[level][1];//
        levelCountPercent = DataInfo[level][2];
    }    

    public void Savelevel(int addjump, int percent,int addCOuntPlay)
    {

        levelCountJump.NUM += addjump;
        levelCountPlay.NUM += addCOuntPlay;
        if (levelCountPercent.NUM < percent)
            levelCountPercent.NUM = percent;
        if (levelCountPercent.NUM >= 100)
            levelCountPercent.NUM = 100;
        levelCountJump.Save();//
        levelCountPlay.Save();//
        levelCountPercent.Save();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
