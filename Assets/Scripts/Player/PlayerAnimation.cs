using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator playerAnim;
    private PlayerMoviment playerMoviment;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerMoviment = GetComponent<PlayerMoviment>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementAnimation();
        JumpingAnimation();
    }

    private void MovementAnimation()
    {
        if(!playerMoviment.IsMoving)
        {
            playerAnim.SetInteger("transition", 0);
        }
        else
        {
            playerAnim.SetInteger("transition", 1);
        }
    }

    private void JumpingAnimation()
    {
        if(playerMoviment.IsJumping)
        {
            playerAnim.SetInteger("transition", 2);
        }
    }


}
