using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour {

	// Use this for initialization

    public static int[] Level;
    //public static int[] Levels1 ={0,3,1,5,4,2,1,5,3,2,1,2,3,4,5,0,1,2,4,3,2,1,6};
    public static int[] Levels1 = { 0, 1, 6, 0,2,3,0,4, 2, 1, 5, 3, 2, 1, 2, 3, 4, 5, 0, 1, 2, 4, 3, 2, 1, 6,0,7,100};
    public static void init()
    {
        Level = Levels1;
    }
}
