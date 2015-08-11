﻿using UnityEngine;
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
    bool isDead;
	void Start () {
        Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isDead)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * playerSpeed, GetComponent<Rigidbody2D>().velocity.y);
            canjump = isGround;
            if (Input.GetKey(KeyCode.Space) && canjump)
            {
                isJumping = true;
                jumpCounter = 0;
            }
            if (!Input.GetKey(KeyCode.Space))
            {
                isJumping = false;
            }
            if(Physics2D.Raycast(WallCheck.position,Vector2.right,wallCheckDistance))
            {
                isDead = true;
            }
            Debug.DrawRay(WallCheck.position, Vector2.right*wallCheckDistance, Color.red);
        }
           
	}
    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);
        if (isJumping && (jumpCounter < jumpTimer))
        {
            jumpCounter += Time.deltaTime;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, minJumpHeight);

        }
    }
}
