using UnityEngine;
using System.Collections;

public class MainMC : MonoBehaviour {

	// Use this for initialization
    public Transform groundCheck;
    public LayerMask ground;
    public bool isGround = false;
    float groundRadius = 0.1f;
    bool isJumping;
    bool canjump;
    bool canSpecialjump;
    public float playerSpeed;

    public int minJumpHeight;    
    float jumpCounter;
    public float jumpTimer;// gioi han thoi gian nhay
    public Transform WallCheck;
    public float wallCheckDistance;
    public static bool isDead;
    public DirectionRaycasting2DCollider directionRaycasting2DCollider;
    
	void Start () {
        Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
       
           
	}
    void FixedUpdate()
    {
        if(State.state != State.STATE_GAMEPLAY)
        {
            return;
        }
        isGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);      

        if (!isDead)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * playerSpeed, GetComponent<Rigidbody2D>().velocity.y);
            canjump = isGround;
           // if (Input.GetKey(KeyCode.Space) && canjump)
            if (Input.GetButton("Jump") && canjump) 
          
            {
                isJumping = true;
                jumpCounter = 0;
            }
            //if (!Input.GetKey(KeyCode.Space))
            if (!Input.GetButton("Jump"))
            {
                isJumping = false;
            }
         //   if (Physics2D.Raycast(WallCheck.position, Vector2.right, wallCheckDistance))
         //   {
         //       isDead = true;
         //       State.instance.setGameOver();                
        //    }
        //    Debug.DrawRay(WallCheck.position, Vector2.right * wallCheckDistance, Color.red);
        }
        if (isJumping && (jumpCounter < jumpTimer))
        {
            jumpCounter += Time.deltaTime;
             GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, minJumpHeight);
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, minJumpHeight * 15));
            //isJumping = false;
        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {

        if (isDead)
            return;

        // Debug.Log(coll.gameObject.name);
        // Debug.Log("Up :" + directionRaycasting2DCollider.collisionUp);
        // Debug.Log("Down :" + directionRaycasting2DCollider.collisionDown);
        // Debug.Log("Right :" + directionRaycasting2DCollider.collisionRight);
        // Debug.Log("Left :" + directionRaycasting2DCollider.collisionLeft);

        // if (coll.gameObject.layer.Equals("Ground") || coll.gameObject.tag.Equals("Trap"))
        {
            if (GetComponent<Rigidbody2D>().gravityScale > 0)// truong hop binh thuong
            {
                if (
                    directionRaycasting2DCollider.collisionRight ||
                    directionRaycasting2DCollider.collisionLeft ||
                    directionRaycasting2DCollider.collisionUp)
                {
                      Debug.LogError("tententen2");
                  //  MouseController.instance.HitByTrap();
                }

            }
            else //if (rigidbody2D.gravityScale > 0)// truong hop doi luc hut
            {
                if (
                    directionRaycasting2DCollider.collisionRight ||
                    directionRaycasting2DCollider.collisionLeft ||
                    directionRaycasting2DCollider.collisionDown
                    )
                {
                    Debug.LogError("tententen1 " + directionRaycasting2DCollider.collisionRight + "," + directionRaycasting2DCollider.collisionLeft);
                 //   MouseController.instance.HitByTrap();
                }
            }

        }

    }


    void OnTriggerEnter2D(Collider2D collider)
    {

        //   bool right = contactPoint.x > center.x;
        //   bool top = contactPoint.y > center.y;
        if (!isDead)
        {
            /*
            if (collider.gameObject.CompareTag("Effect"))
            {
                collider.GetComponent<Collider2D>().enabled = false;
                Effect effect = collider.gameObject.GetComponent<Effect>();
                if (effect.type == Effect.TYPE_EFFECT.TYPE_TELEPORT_1)
                {
                    GetComponent<Rigidbody2D>().gravityScale = -GetComponent<Rigidbody2D>().gravityScale;
                    groundCheckTransform.localPosition = new Vector3(groundCheckTransform.localPosition.x, -groundCheckTransform.localPosition.y, groundCheckTransform.localPosition.z);
                    GamePlay.instance.flatformTop.SetActive(true);
                    GamePlay.instance.flatformTop.transform.position = new Vector3(GamePlay.instance.flatformBottom.transform.position.x, GamePlay.instance.flatformTop.transform.position.y, GamePlay.instance.flatformTop.transform.position.z);
                    stateControl = 1;

                }
                else if (effect.type == Effect.TYPE_EFFECT.TYPE_TELEPORT_2)
                {
                    collider.GetComponent<Collider2D>().enabled = false;
                    stateControl = 0;
                    GetComponent<Rigidbody2D>().gravityScale = Mathf.Abs(GetComponent<Rigidbody2D>().gravityScale);
                    groundCheckTransform.localPosition = new Vector3(groundCheckTransform.localPosition.x, -Mathf.Abs(groundCheckTransform.localPosition.y), groundCheckTransform.localPosition.z);
                    GamePlay.instance.flatformTop.SetActive(false);


                }
                else if (effect.type == Effect.TYPE_EFFECT.TYPE_COMPLETED)
                {
                    //here

                    //   animator.SetInteger("State", 0);
                    //ParticleSystem bulletInstance = (ParticleSystem)(Instantiate(effectDie, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))));
                    // Destroy(bulletInstance, 1.5f);
                    //dead = true;
                    GamePlay.changeState(GamePlay.STATE_WAITTING_COMPLETED);
                    SoundEngine.instance.PlayOneShot(SoundEngine.instance._soundEnd);

                }
                else if (effect.type == Effect.TYPE_EFFECT.TYPE_JUMP1)
                {
                    //  Debug.Log("wwwwwwwwwww");
                    isjump = true;
                    //countFrameJump = 0;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jetpackJump1Force));

                }
                else if (effect.type == Effect.TYPE_EFFECT.TYPE_JUMP2)
                {
                    //  Debug.Log("wwwwwwwwwww");
                    isjump = true;
                    //countFrameJump = 0;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jetpackForce));

                }
            */

            }
            if (collider.tag.Equals("Trap"))
            { 
                isDead = true;
                State.instance.setGameOver();                        
            }
        }

    
}
