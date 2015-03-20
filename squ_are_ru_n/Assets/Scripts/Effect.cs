using UnityEngine;
using System.Collections;

public class Effect : MonoBehaviour {

	// Use this for initialization

    public TYPE_EFFECT type;

   public enum TYPE_EFFECT
    {
        TYPE_NONE,
        TYPE_TELEPORT_1,
        TYPE_TELEPORT_2,
        TYPE_JUMP1,
        TYPE_COMPLETED,
        TYPE_JUMP2,
    }

}
