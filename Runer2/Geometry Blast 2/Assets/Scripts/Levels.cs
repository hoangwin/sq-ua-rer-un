using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour {

	// Use this for initialization
    public static float maxAngle;
    public static int[] Level;
    public static int mLevel;
    //public static int[] Levels1 ={0,3,1,5,4,2,1,5,3,2,1,2,3,4,5,0,1,2,4,3,2,1,6};
    public static int[] Levels1 = { 0, 1, 6, 0, 2, 3, 0, 4, 2, 1, 5, 3, 2, 1, 4, 4, 1, 2, 3, 4, 5, 0, 1, 2, 4, 3, 2, 1, 6, 0, 7, -1, 100 };
    public static int[] Levels2 = { 0, 3, 8, 9, 2, 8, 0, 10, 0, 4, 8, 6, 7, 8, 3, 1, 4, 0, 9, 10, 2, 4, 6, 3, 4, 7, 10, 1, 5, 1, 6, 0, 9, -1, 100 };
    public static int[] Levels3 = {  0, 8, 1, 11,0, 7, -1, 7, -1, 12, -1, 13, -1, 10, 2, 6, 9, 2, 2, 11, 8, -1, 7, -1, 12, -1, 13,4, 5, 0, 1, 11, 7, -1, 7, 10, 1, 9, -1, 10, 0, 12, 0, 8, -1, 100 };
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
        
        maxAngle = (Level.Length + 4) * 360 / 8;
    }
}
