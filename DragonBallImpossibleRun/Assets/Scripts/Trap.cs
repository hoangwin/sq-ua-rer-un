using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	// Use this for initialization
    
    public bool typeCanJump = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.tag);
        if(collider.tag.Equals("Player"))
        {
            MouseController.instance.HitByTrap();
        }
 
   
    }
    /*
    public bool right = false, left = false, up = true, down = false;
    void OnCollisionEnter2D(Collision2D coll)
    {


        {
            if (coll.contacts.Length == 2)
            {
                //chack are two points on x axis the same
                if (coll.contacts[0].point.x == coll.contacts[1].point.x)
                {
                    // chack where they are in regards to game object origin
                    if (coll.contacts[0].point.x > transform.position.x)
                    {
                        right = true;
                    }
                    else
                    {
                        left = true;
                    }
                }
                else if (coll.contacts[0].point.y == coll.contacts[1].point.y)
                {
                    if (coll.contacts[0].point.y > transform.position.y)
                    {
                        up = true;
                    }
                    else
                    {
                        down = true;
                    }
                }
                Debug.Log(coll.transform.name + " : + up+:" + up + ", down: " + down + ", right:" + right + ", left:" + left);
            }
            else
            {
                Debug.LogError("This script is defined only for 2D collisions : " + coll.transform.name + " " + coll.contacts.Length);
            }

        }
    }

    
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.contacts.Length == 2)
        {
            if (coll.contacts[0].point.x == coll.contacts[1].point.x)
            {
                if (coll.contacts[0].point.x > transform.position.x)
                {
                    right = false;
                }
                else
                {
                    left = false;
                }
            }
            else if (coll.contacts[0].point.y == coll.contacts[1].point.y)
            {
                if (coll.contacts[0].point.y > transform.position.y)
                {
                    up = false;
                }
                else
                {
                    down = false;
                }
            }
        }
    }
     */
}
