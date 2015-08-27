using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour {

	// Use this for initialization

    public static int[] Level;
    public static int[] Levels1 ={0,3,1,5,4,2,1,5,3,2,1,2,3,4,5,0,1,2,4,3,2,1};
    public static void init()
    {
        Level = Levels1;
    }
}
