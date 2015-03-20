using UnityEngine;
using System.Collections;

public class PlatformBottom : MonoBehaviour
{

	// Use this for initialization
    public GameObject bg1;
    public GameObject bg2;
    public Renderer rendererbg1;
    public Renderer rendererbg2;
    float size;
    public static int color;
	void Start () {

        size = bg1.collider2D.bounds.size.x;
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        if (bg2.transform.position.x < Camera.main.transform.position.x - size)
        {
            bg2.transform.Translate(size*2, 0, 0);
        }
        
        if (bg1.transform.position.x < Camera.main.transform.position.x - size)
        {
            bg1.transform.Translate(size *2, 0, 0);
        }
    }
}
