using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerMoviment playerMoviment;

    private void Start()
    {
        playerMoviment = GetComponent<PlayerMoviment>();
    }


    //Checking out the player's collision with the ground
    //Controlling the jumping condition
    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            switch(other.gameObject.tag)
            {
                case "Ground":
                    playerMoviment.IsJumping = false;
                break;
            }
        }
    }
    //
    
}
