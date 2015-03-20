using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    public GameObject map1;
    public GameObject map2;
    public GameObject map3;
    public GameObject map4;

    public GameObject[] ColectMap;

    public static Level instance;
    public static int index;
    // Use this for initialization
    void Start()
    {
        instance = this;
      //  map1.SetActive(true);
      //  map3.SetActive(false);
        for(int i=2;i<ColectMap.Length;i++)
        {
            if(ColectMap[i] != null)
                ColectMap[i].SetActive(false);
        }
        index = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (index >= 0 && index < ColectMap.Length)
        {
          //  Debug.Log("aaaaaaaaa :" + MouseController.instance.transform.position.x + "," + ColectMap[index].transform.position.x);
            if (ColectMap[index] != null)
            if (MouseController.instance.transform.position.x > ColectMap[index].transform.position.x)
            {
                
                int indexpre = index - 2;
                int indexnext = index + 1;
                if (indexpre >= 0 && ColectMap[indexpre] != null)
                {
                  //  Debug.Log("bbbbbbbbbbbb");
                    GameObject.Destroy(ColectMap[indexpre]);
                    //ColectMap[indexpre].SetActive(false);
                }

                if (indexnext >= 0 && ColectMap[indexnext] != null)
                {
                    ColectMap[indexnext].SetActive(true);
                }

                index++;
            }

        }
    }
}
