using UnityEngine;
using System.Collections;

public class SelectCharacter : MonoBehaviour {
    public static int m_index;
    public Texture[] m_arrayTexture;

    public Material m_MCmatterial;
    public static SelectCharacter m_instance;
    // Use this for initialization
    void Start () {
        //setMaterial(2);
        m_instance = this;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void setMaterial(int index)
    {
        m_MCmatterial.SetTexture("_MainTex", m_arrayTexture[index]);
    }
}
