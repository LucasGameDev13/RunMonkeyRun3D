using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerMoviment playerMoviment;
    private GameScoreController gameScoreController;

    private void Awake()
    {
        gameScoreController = FindObjectOfType<GameScoreController>();
    }

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

                case "Collectibles1":
                    gameScoreController.GameScore(Random.Range(1, 5));
                    Destroy(other.gameObject);
                break;

                case "Collectibles2":
                    gameScoreController.AddGameScoreLetters(other.gameObject);
                    other.gameObject.SetActive(false);
                break ;

                case "Obstacle":
                    Debug.Log("Hit me!!!");
                break;
            }
        }
    }    
}
