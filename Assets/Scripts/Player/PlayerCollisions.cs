using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerMoviment playerMoviment;
    private PlayerHealth playerHealth; 
    private GameScoreController gameScoreController;
    private TimeLineController timeLineController;

    [Header("Collisions Effects Settings")]
    [SerializeField] private ParticleSystem hitEffectStars;
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] private ParticleSystem hitEffectLetters;
    [SerializeField] private ParticleSystem BananaHitEffect;


    private void Awake()
    {
        gameScoreController = FindObjectOfType<GameScoreController>();
        timeLineController = FindObjectOfType<TimeLineController>();
    }

    private void Start()
    {
        playerMoviment = GetComponent<PlayerMoviment>();
        playerHealth = GetComponent<PlayerHealth>();
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
                    BananaHitEffect.Play();
                    gameScoreController.GameScore(Random.Range(1, 5));
                    Destroy(other.gameObject);
                break;

                case "Collectibles2":
                    hitEffectLetters.Play();
                    gameScoreController.AddGameScoreLetters(other.gameObject);
                    other.gameObject.SetActive(false);
                break ;

                case "Obstacle":

                    if (!playerHealth.IsRecovery)
                    {
                        hitEffectStars.Play();
                        hitEffect.Play();
                    }

                    playerHealth.PlayerHealthController();

                    if(playerHealth.PlayerHealthValue() == 0)
                    {
                        hitEffectStars.loop = true;
                        timeLineController.IsAlive = false;
                    }

                break;

                case "Fatal":
                    Debug.Log("GAMEOVER!!!");
                    hitEffect.Play();

                    hitEffectStars.loop = true;
                    hitEffectStars.Play();
                    
                    timeLineController.IsAlive = false;
                    playerHealth._PlayerHealth = 0;
                break;
            }
        }
    }    
}
