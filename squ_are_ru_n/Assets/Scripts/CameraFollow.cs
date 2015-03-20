using UnityEngine;
using System.Collections;


using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public float xMargin = 1f;		// Distance in the x axis the player can move before the camera follows.
    public float yMargin = 1f;		// Distance in the y axis the player can move before the camera follows.
    public float xSmooth = 8f;		// How smoothly the camera catches up with it's target movement in the x axis.
    public float ySmooth = 8f;		// How smoothly the camera catches up with it's target movement in the y axis.
    public Vector2 maxXAndY;		// The maximum x and y coordinates the camera can have.
    public Vector2 minXAndY;		// The minimum x and y coordinates the camera can have.
    public float offset;
    public float offsetY;


    private Transform player;		// Reference to the player's transform.


    void Awake()
    {
        // Setting up the reference.
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    bool CheckXMargin()
    {
        // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
        return Mathf.Abs(transform.position.x - (player.position.x + 5)) > xMargin;
    }


    bool CheckYMargin()
    {
        // Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }


    void FixedUpdate()
    {
        if(GamePlay.state == GamePlay.STATE_RUN)
        TrackPlayer();
    }


    void TrackPlayer()
    {
        // By default the target x and y coordinates of the camera are it's current x and y coordinates.
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        // If the player has moved beyond the x margin...
        if (CheckXMargin())
            // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
            targetX = Mathf.Lerp(transform.position.x, player.position.x+offset, xSmooth * Time.deltaTime);

        // If the player has moved beyond the y margin...
        if (CheckYMargin())
            // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
            targetY = Mathf.Lerp(transform.position.y, player.position.y + offsetY, ySmooth * Time.deltaTime);

        // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
       // targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
       // targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}


class CameraFollow1 : MonoBehaviour {

	public GameObject targetObject;
    public MouseController mouseController;
    public AudioSource Music;
	public float distanceToTarget;

	// Use this for initialization
	void Start () {
		//distanceToTarget = transform.position.x - targetObject.transform.position.x;
        DEF.Init();
        
	}
	
	// Update is called once per frame
	void Update1 () {


        //Music.enabled =SoundEngine.isSoundMusic;
        if (mouseController.dead)
        {
            /*
            Vector3 v3 = targetObject.transform.position;
            v3.z = transform.position.z;
            v3.y = transform.position.y;
            if (Vector3.Distance(v3, targetObject.transform.position) > 0.1)
                transform.position = Vector3.Lerp(transform.position, v3, 0.5f * Time.deltaTime);
             * */
        }
        else
        {
            
            float targetObjectX = targetObject.transform.position.x;
            float targetObjectY = targetObject.transform.position.y;
            Vector3 newCameraPosition = transform.position;
            newCameraPosition.x = targetObjectX + distanceToTarget;
            if (targetObjectY >5)
            newCameraPosition.y = targetObjectY + 3;// distanceToTarget;
            else
                newCameraPosition.y = 0;// distanceToTarget;

            
            transform.position = newCameraPosition;
             
          /*  Vector3 v3 = targetObject.transform.position;
            v3.z = transform.position.z;
            v3.y = transform.position.y;
            v3.x += distanceToTarget;
            if (Vector3.Distance(v3, targetObject.transform.position) > 0.1)
                transform.position = Vector3.Lerp(transform.position, v3, 5f * Time.deltaTime); 
           * */
        }
	}
}
