using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator playerAnim;
    private PlayerMoviment playerMoviment;
    private TimeLineController timeLineController;

    private void Awake()
    {
        timeLineController = FindObjectOfType<TimeLineController>();
    }

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
        DeathAnimation();
    }

    //Setting Up the Player's movement animation
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

    //Setting Up the Player's Jumping animation
    private void JumpingAnimation()
    {
        if(playerMoviment.IsJumping)
        {
            playerAnim.SetInteger("transition", 2);
        }
    }


    //Setting Up the Player's animation death
    private void DeathAnimation()
    {
        playerAnim.SetBool("isAlive", timeLineController.IsAlive);
    }


}
