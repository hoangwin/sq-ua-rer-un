using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	// Use this for initialization
    public bool isHaveNextTrap;
    public bool isSub;
	void Start () {
        isHaveNextTrap = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("TriggerDestroy"))
        {
            if (!isSub)
                Destroy(this.gameObject);
            else
                Destroy(this.gameObject.transform.parent.gameObject);
        }
        
        //triggerCount++;
        //if (triggerCount < Levels.Level.Length)
        //{
        //    int i = Levels.Level[triggerCount];
        //    int j = triggerCount % 8;
        
        //    GameObject obj = (GameObject)Instantiate(TrapListTemple[i], TrapListPostion[j].position, TrapListPostion[j].rotation);// TrapList[0].SetActive(true);
        //    obj.transform.parent = ParentList.transform;
       // }
    }
}
