using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    
    [SerializeField] private float jumpForce = 7f; 
    [SerializeField] private int jumpMod = 2;           
    [SerializeField] private Transform groundCheck;           
    [SerializeField] private float groundCheckRadius = 0.3f;  
    [SerializeField] private LayerMask groundLayer;   
    //[SerializeField] public float jumpDelay = 0.5f;   

    private Movement plMove;     
    private Rigidbody playerRB;
    private Animator anim;
    public bool isGrounded, isJump, isFalling;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        plMove = GetComponent<Movement>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        GroundCheck(); 
        HandleJump();  
       
        if(!isGrounded && playerRB.velocity.y < 0)
        {
            isFalling = true;
            anim.SetBool("isFalling",true);
            Debug.Log("Falling down");
        }
        UpdateAnimations();
    }

    void GroundCheck()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        Debug.Log("On the Ground NOW");
       
        //bool check
        if(isGrounded)
        {
            isFalling = false;
            isJump = false;
        }
        
       
    }

    

    void HandleJump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            //bool checks
            isJump = true;
            isGrounded = false;
            Debug.Log("Going UP?");
            // animator parameters
            anim.SetBool("isJump",true);
            anim.SetBool("isGrounded",false);

            // logic
            Vector3 moveDirection = new Vector3(plMove.horizontalInput, 0 , plMove.verticalInput);

            
            Vector3 jumpDirection = moveDirection.normalized;
            
            playerRB.velocity = new Vector3(playerRB.velocity.x, 0, playerRB.velocity.z); 

            if(plMove.horizontalInput != 0 || plMove.verticalInput != 0)
            {
                //playerRB.AddForce((Vector3.up + jumpDirection) * jumpForce, ForceMode.Impulse);//orignal works but can be changed

                playerRB.AddForce((Vector3.up + (jumpDirection/jumpMod)) * jumpForce, ForceMode.Impulse); // the update that needs testing
            }

            else if(plMove.horizontalInput == 0 && plMove.verticalInput == 0)
            {
                playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            
        }
    }

    void UpdateAnimations()
{
    anim.SetBool("isGrounded", isGrounded);
    anim.SetBool("isJump", isJump);
    anim.SetBool("isFalling", isFalling);
}


    
    /* void UpdateAnim()
    {
        if(!isGrounded)
    }
     */
}

/*
*/



