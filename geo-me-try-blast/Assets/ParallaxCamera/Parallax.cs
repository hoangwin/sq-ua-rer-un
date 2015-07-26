using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{



    public float speed = 0.02f;
    public float offset = 0;
    public static Parallax instance;
    float posXCameraPre;
    // Use this for initialization
    void Start()
    {
        posXCameraPre = Camera.main.transform.position.x;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (posXCameraPre != Camera.main.transform.position.x)
        {
          // Debug.Log("aaaaaaaaaa");
            posXCameraPre = Camera.main.transform.position.x;
            offset += speed;
            if (offset < -1)
                offset += 1;

            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 0);
        }
        

    }
}

