using UnityEngine;
using System.Collections;

public class SaveGame : MonoBehaviour {

	// Use this for initialization
    public static SuperInt jumpCount;
    public static SuperInt attemptsCount;
    public static SuperFloat timeCountCount;
    public static SuperInt Percent1;
    public static SuperInt Percent2;
    public static SuperInt Percent3;
    public static void init()
    {
        if (jumpCount == null)
        { 
            jumpCount = new SuperInt(0, "JUMP_COUNT");
            jumpCount.Load();
            attemptsCount= new SuperInt(0, "Attempts_COUNT");
            attemptsCount.Load();
            timeCountCount = new SuperFloat(0, "time_COUNT");
            timeCountCount.Load();

            Percent1 = new SuperInt(0, "Percent1");
            Percent1.Load();
            Percent2 = new SuperInt(0, "Percent2");
            Percent2.Load();
            Percent3 = new SuperInt(0, "Percent3");
            Percent3.Load();
        }
    }

    public static void SaveAll()
    {
        if (jumpCount != null)
        {
            jumpCount.Save();            
            attemptsCount.Save();            
            timeCountCount.Save();
            Percent1.Save();
            Percent2.Save();
            Percent3.Save();
        }
    }
}
