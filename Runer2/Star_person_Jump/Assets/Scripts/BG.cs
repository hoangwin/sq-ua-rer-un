using UnityEngine;
using System.Collections;

public class BG : MonoBehaviour {
    public float speedRotation;
	// Use this for initialization
    public static float angleRotation;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!MainMC.isDead)
        {
            angleRotation += Time.deltaTime * speedRotation;
        //    Debug.Log(angleRotation);
            transform.Rotate(0, 0, Time.deltaTime * speedRotation);
        }
	}
}
