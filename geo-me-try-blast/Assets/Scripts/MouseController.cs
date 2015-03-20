using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {


	public float jetpackForce = 75.0f;
    public float jetpackJump1Force = 75.0f;
	public float forwardMovementSpeed;
    public float speedRotation;
	public Transform groundCheckTransform;
    public LayerMask groundCheckLayerMask;
    public GameObject displayGameObject;
    public Transform rayCastTranform;
	public bool grounded;
    public static bool gameRunning;
	Animator animator;	
    private Vector3 vec3PosBegin;
	public bool dead = false;
    public bool isjump = false;
    public uint distanceMove = 0;
    public int stateControl = 0;//0 binh thuong;1 la hieu ung trai dat;2 la hieu ung chiec thuyen
    public static SuperInt HeroType;//0,1,2,3

    public Sprite[] spriteBoders;
    public Sprite[] spriteHeros;
    public SpriteRenderer spriteHero;
    public SpriteRenderer spriteBoder;
   // int countFrameJump;

    public static MouseController instance;

    public ParticleSystem effectDie;
    public ParticleSystem effectTrack;
    public DirectionRaycasting2DCollider directionRaycasting2DCollider;
    bool pregrounded;
    public AudioSource MusicSound;
	// Use this for initialization
    void Awake()
    {
        instance = this;
        AdjustSound(SoundEngine.isSoundMusic);
      
    }

	void Start ()
 {
     instance = this;
		animator = GetComponent<Animator>();
        MouseController.instance.playSound();
        animator.SetInteger("State", 1);
        gameRunning = true;        
       // Debug.Log("tui ne");
        SaveGame.init();
        SaveGame.attemptsCount.NUM++;
	}
	
	// Update is called once per frame

    Vector2 newVelocity;
    void FixedUpdate()
    {
        SaveGame.timeCountCount.NUM+= Time.deltaTime;
        if (GamePlay.state == GamePlay.STATE_RUN)
        {
            // countFrameJump++;
            bool jetpackActive = Input.GetButton("Fire1");
            // Debug.Log(jetpackActive);

            jetpackActive = jetpackActive && !dead;
            if (!grounded)
                displayGameObject.transform.Rotate(0, 0, speedRotation);
            if (stateControl == 0) // dieu khien binh thuong
            {
                if (jetpackActive && grounded && !isjump)
                {
                    isjump = true;
                    //countFrameJump = 0;
                    rigidbody2D.velocity = new Vector2(0, 0);
                    rigidbody2D.AddForce(new Vector2(0, jetpackForce));
                    SaveGame.jumpCount.NUM++;

                }
            }
            if (stateControl == 1) // dieu khien luc hut trai dat
            {
                if (jetpackActive && grounded && !isjump)
                {
                    //loi bi chet khi tren hay duoi
                    groundCheckTransform.localPosition = new Vector3(groundCheckTransform.localPosition.x, -groundCheckTransform.localPosition.y, groundCheckTransform.localPosition.z);
                    rigidbody2D.gravityScale = -rigidbody2D.gravityScale;
                    //rigidbody2D.AddForce(new Vector2(0, -jetpackForce));
                    SaveGame.jumpCount.NUM++;
                }

            }

            if (!dead)
            {
              //  Debug.Log("zzzzzzzz");
                newVelocity = rigidbody2D.velocity;
                newVelocity.x = forwardMovementSpeed;
              
                
                rigidbody2D.velocity = newVelocity;
            }

            UpdateGroundedStatus();
            AdjustJetpack(jetpackActive, grounded);

            
        }
    }
    
	void UpdateGroundedStatus()
	{
        pregrounded = grounded;
		grounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);
      //  Debug.Log(grounded);


        if (!pregrounded && grounded)
        {
            isjump = false;
            if (!Input.GetButton("Fire1"))
            {


               // Debug.Log(displayGameObject.transform.rotation.eulerAngles.z);
                float i = displayGameObject.transform.rotation.eulerAngles.z;
                if (i <= 45)
                {
                    displayGameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                    //displayGameObject.transform.rotation= new Quaternion(0,0,180,0);
                }
                else if (i <= 135)
                {
                    displayGameObject.transform.eulerAngles = new Vector3(0, 0, 90);
                    //displayGameObject.transform.rotation= new Quaternion(0,0,180,0);
                }
                else if (i <= 225)
                {
                    displayGameObject.transform.eulerAngles = new Vector3(0, 0, 180);
                    //displayGameObject.transform.rotation= new Quaternion(0,0,180,0);
                }
                else if (i > 225)
                {
                    displayGameObject.transform.eulerAngles = new Vector3(0, 0, 270);

                    //displayGameObject.transform.rotation= new Quaternion(0,0,180,0);
                }
             //   Debug.Log("aa:" + displayGameObject.transform.rotation.eulerAngles.z);
            }
        }
		
		//animator.SetBool("grounded", grounded);
	}

    void AdjustJetpack(bool jetpackActive, bool grounded)
    {
        effectTrack.enableEmission = grounded&& !dead;
        //effectTrack.emissionRate = jetpackActive ? 20 : 0f;
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {

        if (!gameRunning)
            return;
      
       // Debug.Log(coll.gameObject.name);
       // Debug.Log("Up :" + directionRaycasting2DCollider.collisionUp);
       // Debug.Log("Down :" + directionRaycasting2DCollider.collisionDown);
       // Debug.Log("Right :" + directionRaycasting2DCollider.collisionRight);
       // Debug.Log("Left :" + directionRaycasting2DCollider.collisionLeft);

       // if (coll.gameObject.layer.Equals("Ground") || coll.gameObject.tag.Equals("Trap"))
        {
            if (rigidbody2D.gravityScale > 0)// truong hop binh thuong
            {
                if (
                    directionRaycasting2DCollider.collisionRight ||
                    directionRaycasting2DCollider.collisionLeft ||
                    directionRaycasting2DCollider.collisionUp)
                {
                  //  Debug.LogError("tententen2");
                    MouseController.instance.HitByTrap();
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
                    MouseController.instance.HitByTrap();
                }
            }

        }

    }
    

	void OnTriggerEnter2D(Collider2D collider)
	{
       
     //   bool right = contactPoint.x > center.x;
     //   bool top = contactPoint.y > center.y;
        if (!dead)
        {
            if (collider.gameObject.CompareTag("Effect"))
                {
                    collider.collider2D.enabled = false;
                    Effect effect = collider.gameObject.GetComponent<Effect>();
                    if (effect.type == Effect.TYPE_EFFECT.TYPE_TELEPORT_1)
                    {
                        rigidbody2D.gravityScale = -rigidbody2D.gravityScale;
                        groundCheckTransform.localPosition = new Vector3(groundCheckTransform.localPosition.x, -groundCheckTransform.localPosition.y, groundCheckTransform.localPosition.z);
                        GamePlay.instance.flatformTop.SetActive(true);
                        GamePlay.instance.flatformTop.transform.position = new Vector3(GamePlay.instance.flatformBottom.transform.position.x, GamePlay.instance.flatformTop.transform.position.y, GamePlay.instance.flatformTop.transform.position.z);
                        stateControl = 1;

                    }
                    else if (effect.type == Effect.TYPE_EFFECT.TYPE_TELEPORT_2)
                    {
                        collider.collider2D.enabled = false;
                        stateControl = 0;
                        rigidbody2D.gravityScale = Mathf.Abs(rigidbody2D.gravityScale);
                        groundCheckTransform.localPosition = new Vector3(groundCheckTransform.localPosition.x,-Mathf.Abs( groundCheckTransform.localPosition.y), groundCheckTransform.localPosition.z);
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
                        rigidbody2D.velocity = new Vector2(0, 0);
                        rigidbody2D.AddForce(new Vector2(0, jetpackJump1Force));

                    }
                    else if (effect.type == Effect.TYPE_EFFECT.TYPE_JUMP2)
                    {
                        //  Debug.Log("wwwwwwwwwww");
                        isjump = true;
                        //countFrameJump = 0;
                        rigidbody2D.velocity = new Vector2(0, 0);
                        rigidbody2D.AddForce(new Vector2(0, jetpackForce));

                    }


                }
            if (collider.tag.Equals("Trap"))
            {
                MouseController.instance.HitByTrap();
            }
        }

	}
		
	
   public void HitByTrap()
    {
        Debug.Log("Hit by trap");
        

       if(!dead)
       {
           animator.SetInteger("State", 0);
           ParticleSystem bulletInstance = (ParticleSystem)(Instantiate(effectDie, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))));
          // Destroy(bulletInstance, 1.5f);
           dead = true;
           GamePlay.changeState(GamePlay.STATE_WATING_OVER);
           SoundEngine.instance.PlayOneShot(SoundEngine.instance._soundExplotion);
           
       }
       /*
        if (!dead)
            laserCollider.gameObject.audio.Play();
        dead = true;
        animator.SetBool("dead", true);

        GameObject bulletInstance = null;// (GameObject)(Instantiate(electron, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))));
        Destroy(laserCollider);
        Destroy(bulletInstance, 1.5f);
        bulletInstance.transform.parent = transform;
        bulletInstance.transform.Translate(0, 0.3f, 0);
        */
    }

    public void AdjustSound(bool isActive)    
	{

        //Debug.Log( GamePlay.isGamePlaying );
        if (MusicSound!= null)
            MusicSound.enabled =  SoundEngine.isSoundMusic && (Time.timeScale !=0);
            
            //jetpackAudio.volume = jetpackActive ? 1.0f : 0.5f;       
        
 
	}
    public void StopAdjustFootstepsAndJetpackSound()
    {
         
    }

    public void playSound()
    {
        
        
    }

    public void setAnim(int i)
    {
        if (MouseController.HeroType == null)
        {
            MouseController.HeroType = new SuperInt(0, "HEROTYPE");
            MouseController.HeroType.Load();
        }
        if (HeroType.NUM != i)
        {
            HeroType.NUM = i;
            HeroType.Save();
        }
        spriteHero.sprite = spriteHeros[i];
        spriteBoder.sprite = spriteBoders[i];
    }
/*

    Vector3 HitRelative;
    bool hitTop = false;
    bool hitBottom = false;
    bool hitLeft = false;
    bool hitRight = false;
    public void checkDrirectionColider(GameObject obj)
    {
        hitTop = false;
        hitBottom = false;
        hitLeft = false;
        hitRight = false;
        Transform cam = obj.transform;
        HitRelative = cam.InverseTransformPoint(transform.position);
        
        
        if (HitRelative.x > 0)
            hitRight = true;//Debug.Log("The object is in front of the camera");
        else
            hitLeft = true;// Debug.Log("The object is behind the camera");

        if (HitRelative.y > 0)
            hitTop = true;//Debug.Log("The object is in front of the camera");
        else
            hitBottom = true;// Debug.Log("The object is behind the camera");
        Debug.Log(hitRight +"," + hitLeft +"," + hitTop +","+ hitBottom);
    }
*/
}
