using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaCon : MonoBehaviour
{
    private Movement playerMove;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<Movement>();
        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        PLayerMoveAnimCon();
    }

    void PLayerMoveAnimCon()
    {
        if(playerMove.horizontalInput != 0 || playerMove.verticalInput != 0)
        {
            anim.SetBool("isMove",true);
        }

        else if(playerMove.horizontalInput == 0 && playerMove.verticalInput == 0)
        {
            anim.SetBool("isMove",false);
        }
    }
    
}
