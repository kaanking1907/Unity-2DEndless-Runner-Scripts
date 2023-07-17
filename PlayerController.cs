using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilesStone;
    private float speedIncreaseMilesStoneStore;

    private float speedMilesStoneCount;
    private float speedMilesStoneCountStore;

    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool stoppedJumping;

    private Rigidbody2D myRigidbody;

    public bool grounded; 
    public LayerMask WhatIsGround;
    public Transform gorundCheck;
    public float groundCheckRadius;

    private Collider2D myCollider;

    private Animator myAnimator;

    public GameManager theGameManager;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;

        speedMilesStoneCount = speedIncreaseMilesStone;

        moveSpeedStore = moveSpeed;
        speedMilesStoneCountStore = speedMilesStoneCount;
        speedIncreaseMilesStoneStore = speedIncreaseMilesStone;
    }

    void Update()
    {
        //grounded = Physics2D.IsTouchingLayers(myCollider, WhatIsGround);

        grounded = Physics2D.OverlapCircle(gorundCheck.position, groundCheckRadius, WhatIsGround);

        if(transform.position.x > speedMilesStoneCount)
        {
            speedMilesStoneCount += speedIncreaseMilesStone;

            speedIncreaseMilesStone = speedIncreaseMilesStone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) )
        {
            if(grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                stoppedJumping = false;
            }
        }

        if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0) && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
        }

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
        }

        myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool ("Grounded", grounded);
    }
    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "killbox")
        {
            
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilesStoneCount = speedMilesStoneCountStore;
            speedIncreaseMilesStone = speedIncreaseMilesStoneStore;
        }
    }
}
