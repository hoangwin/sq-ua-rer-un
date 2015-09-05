using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour {

	// Use this for initialization
    public static float maxAngle;
    public static int[] Level;
    public static int mLevel;
    //public static int[] Levels1 ={0,3,1,5,4,2,1,5,3,2,1,2,3,4,5,0,1,2,4,3,2,1,6};
    public static int[] Levels1 = { 0, 1, 6, 0, 2, 3, 0, 4, 2, 1, 5, 3, 2, 1, 4, 4, 1, 2, 3, 4, 5, 0, 1, 2, 4, 3, 2, 1, 6, 0, 7, -1, 100 };
    public static int[] Levels2 = { 0, 5, 3, 0, 2, 3, 0, 4, 2, 1, 5, 3, 2, 1, 4, 4, 1, 2, 3, 4, 5, 0, 1, 2, 4, 3, 2, 1, 6, 0, 7, -1, 100 };
    public static int[] Levels3 = { 0, 6, 0, 7, 2, 3, 0, 4, 2, 1, 5, 3, 2, 1, 4, 4, 1, 2, 3, 4, 5, 0, 1, 2, 4, 3, 2, 1, 6, 0, 7, -1, 100 };
    public static void init()
    {
        switch (mLevel)
        {
            case 0:
                Level = Levels1;
                break;
            case 1:
                Level = Levels2;
                break;
            case 2:
                Level = Levels3;
                break;
        }
        
        maxAngle = (Level.Length + 1) * 360 / 8;
    }
}
