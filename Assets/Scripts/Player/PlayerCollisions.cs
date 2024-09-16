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

    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            switch(other.gameObject.tag)
            {
                case "Ground":
                    Debug.Log("Ground");
                    playerMoviment.IsJumping = false;
                break;
            }
        }
    }
    //
    
}
