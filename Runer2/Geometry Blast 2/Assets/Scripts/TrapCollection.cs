using UnityEngine;
using System.Collections;

public class TrapCollection : MonoBehaviour {

	// Use this for initialization
    //Transform[] listTranform;
    public GameObject parent;
    public Transform[] TrapListPostion;//8 list tren man hinh
    public GameObject[] TrapListTemple;//list tong
    public GameObject TrapEmpty;//list tong
    public GameObject ParentList;//list tong
    int triggerCount;
    public static TrapCollection instance;
	void Start () {
        instance = this;
        triggerCount = 0;
     
        //listTranform = new Transform[8];
        for (int i = 0; i < TrapListPostion.Length; i++)
        {
           // listTranform
            TrapListPostion[i].gameObject.SetActive(false);
            
        }
        //TrapInit();
	}
	public void TrapInit()
    {
        Levels.init();
        parent.transform.rotation = new Quaternion(0, 0, 180, 0);
        GameObject obj = (GameObject)Instantiate(TrapListTemple[0], TrapListPostion[0].position, TrapListPostion[0].rotation);// TrapList[0].SetActive(true);
        obj.transform.parent = ParentList.transform;
    }
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
      //  Debug.Log("AAA");
        if (other.tag.Equals("Trap") || other.tag.Equals("Bone"))
        {
            Trap trap = other.GetComponent<Trap>();
            if (!trap.isHaveNextTrap)
            {
                if (triggerCount < Levels.Level.Length-1)
                {
                    trap.isHaveNextTrap = true;
                    triggerCount++;
                    int i = Levels.Level[triggerCount];
                    int j = triggerCount % 8;
                    Debug.Log(" " + i + "," + j);
                    GameObject obj;
                    if (i != -1)//-1 LA O TRONG
                    {
                         obj = (GameObject)Instantiate(TrapListTemple[i], TrapListPostion[j].position, TrapListPostion[j].rotation);// TrapList[0].SetActive(true);
                        
                    }
                    else
                    {
                        obj = (GameObject)Instantiate(TrapEmpty, TrapListPostion[j].position, TrapListPostion[j].rotation);// TrapList[0].SetActive(true);    TrapEmpty
                    }
                    obj.transform.parent = ParentList.transform;
                }
            }
        }
    }
  //  void OnCollisionEnter2D(Collision2D coll)
  // {
  //   Debug.Log("bbbbbb");
  //    }
    public void destroyAll()
    {
        Transform[] T = ParentList.GetComponentsInChildren<Transform>();
        foreach(Transform t in T)
        {
            if (t == ParentList.transform)
                continue;
            Destroy(t.gameObject);
        }
        triggerCount = 0;
    }
}
