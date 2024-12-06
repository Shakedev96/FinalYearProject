using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CharController : MonoBehaviour
{
    
    


}
/*
 public float moveSpeed ;
    public float jumpForce;

    public CharacterController charController;

    private Vector3 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed , 0f , Input.GetAxis("Vertical") * moveSpeed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            moveDirection.y = jumpForce;
        }

        charController.Move(moveDirection * Time.deltaTime);
    }

   /*  private void MovePlayer()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed , 0f , Input.GetAxis("Vertical") * moveSpeed);
    }

    private void Jumping()
    {
        moveDirection.y = jumpForce;
    } */

