using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    //Movement playerMove;
    private Rigidbody playerRB;
    public bool _dashing;
    public float dashForce = 15f;
    [SerializeField, Range(0.1f,1f)] private float dashLimit;
    public float dashCooldown = 3f;        
    private float nextDashTime = 0f;       
    //[SerializeField] private Image dashStamina;
    

    
    private Animator anim;
    private int isDashingHash;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        // Initialize hash for animations if used
        isDashingHash = Animator.StringToHash("isDash");
    }
    void Awake()
    {
        _dashing  = false;
    }

    void Update()
    {
        HandleDash();
        //HandleUI();
    }

    void HandleDash()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextDashTime)
        {
            PerformDash();
            
        }
    }

    public void PerformDash()
    {
        // calculating the a coolDown in total

        nextDashTime = Time.time + dashCooldown;

        
        playerRB.AddForce(transform.forward * dashForce, ForceMode.Impulse);
        _dashing = true;

        
        if (anim != null)
        {
            anim.SetBool(isDashingHash, true);
        }

        
        Invoke("EndDash",dashLimit); // Dash duration 
        
    }

    void EndDash()
    {
        _dashing = false;
        
        // Optional: End dash animation
        if (anim != null)
        {
            anim.SetBool(isDashingHash, false);
        }
    }

    /* void HandleUI()
    {
       float timeSinceDash = nextDashTime - Time.time;

        if (_dashing)
        {
            dashStamina.fillAmount = 0f;  // Stamina bar empty during the dash
        }
        else
        {
            // Calculate fill percentage based on remaining cooldown
            dashStamina.fillAmount = Mathf.Clamp01(1 - (timeSinceDash / dashCooldown));
        }
    } */
}