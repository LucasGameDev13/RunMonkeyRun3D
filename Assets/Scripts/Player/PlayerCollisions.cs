using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerMoviment playerMoviment;
    private PlayerHealth playerHealth; 
    private GameScoreController gameScoreController;
    private TimeLineController timeLineController;
    private GameUIController gameUIController;

    [Header("Collisions Effects Settings")]
    [SerializeField] private ParticleSystem hitEffectStars;
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] private ParticleSystem hitEffectLetters;
    [SerializeField] private ParticleSystem BananaHitEffect;


    private void Awake()
    {
        gameScoreController = FindObjectOfType<GameScoreController>();
        timeLineController = FindObjectOfType<TimeLineController>();
        gameUIController = FindObjectOfType<GameUIController>();
    }

    private void Start()
    {
        playerMoviment = GetComponent<PlayerMoviment>();
        playerHealth = GetComponent<PlayerHealth>();
    }



    //Checking out the player's collision with the ground
    //Controlling the jumping condition
    //Controlling the game effects 
    //Controlling the game objects collecting
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
                    GameAudioController.instance.Collectebles1Sounds();
                    BananaHitEffect.Play();
                    gameScoreController.GameScore(Random.Range(1, 5));
                    Destroy(other.gameObject);
                break;

                case "Collectibles2":
                    GameAudioController.instance.Collectebles2Sounds();
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
                        StartCoroutine(CallGameOvers(true, false));
                    }

                break;

                case "Fatal":
                    GameAudioController.instance.PlayerHitSound();
                    Invoke("GameOverLoseSoundEffect", 3f);
                    hitEffect.Play();

                    hitEffectStars.loop = true;
                    hitEffectStars.Play();
                    
                    timeLineController.IsAlive = false;
                    playerHealth._PlayerHealth = 0;
                    StartCoroutine(CallGameOvers(true, false));
                break;
            }
        }

        if (other != null)
        {
            if(other.gameObject.layer == 7)
            {
                Invoke("GameOverWinSoundEffect", 3f);
                GetComponent<PlayerMoviment>().enabled = false;
                StartCoroutine(CallGameOvers(false, true));
            }
        }
    }   
    
    private void GameOverLoseSoundEffect()
    {
        GameAudioController.instance.GameOverLoseSound();
    }

    private void GameOverWinSoundEffect()
    {
        GameAudioController.instance.GameOverWinSound();
    }

    IEnumerator CallGameOvers(bool _lose, bool _win)
    {
        yield return new WaitForSeconds(3f);
        gameUIController.SetActiveGameOvers(_lose, _win);
    }
}
