using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	// Use this for initialization
    public bool isHaveNextTrap;
    public bool isSub;
    public int type;//=0//=1:rotation
    public float speedRotation;    
	void Start () {
        isHaveNextTrap = false;
	}
    public Transform targetRotation;
	// Update is called once per frame
	void Update () {
        if (type == 1)
        {

            transform.Rotate(Vector3.forward * Time.deltaTime * speedRotation);
             //   transform.RotateAround(targetRotation.position, Vector3.back, speedRotation * Time.deltaTime);
          
        }
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
