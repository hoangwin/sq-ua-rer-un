using UnityEngine;
using System.Collections;

public class BG : MonoBehaviour {
    public float speedRotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(!MainMC.isDead)
            transform.Rotate(0, 0, Time.deltaTime*speedRotation);
	}
}
