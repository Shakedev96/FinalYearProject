using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float horizontalInput, verticalInput;
    

    [SerializeField] private float  runSpeed = 10f, currentSpeed;

    [SerializeField] float refFloat;

    private Rigidbody playerRB;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        currentSpeed = runSpeed;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        horizontalInput = Input.GetAxis("Vertical");
        verticalInput = Input.GetAxis("Horizontal");
        // change The axis in vertical and horizontal input to get the desired Vector3.forward ==> forward move with A & D
        Vector3 _inputkey = new Vector3(horizontalInput , 0 ,verticalInput );

        //playerRB.velocity = _inputkey * walkSpeed;

        playerRB.MovePosition(transform.position + _inputkey * currentSpeed * Time.deltaTime);

        
        

        if(_inputkey.magnitude >= 0.1f)
        {
            float rotationAngle = Mathf.Atan2(_inputkey.x,  _inputkey.z) * Mathf.Rad2Deg;
            float smoothRoation = Mathf.SmoothDampAngle(transform.eulerAngles.y , rotationAngle ,ref refFloat , 0.1f);

            transform.rotation = Quaternion.Euler(0 ,smoothRoation ,0);
        }
    }
    
}
