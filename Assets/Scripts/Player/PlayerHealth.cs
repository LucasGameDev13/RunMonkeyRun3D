using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth;
    [SerializeField] private float playerHealthRecoveryTime;
    [SerializeField] private GameObject[] playerMeshRenderer;
    [SerializeField] private float blinkInterval;
    private bool isRecovery;
    private bool playOnce;


    public int _PlayerHealth
    {
        set { playerHealth = value; }
    }

    public bool IsRecovery
    {
        get { return isRecovery; }
    }

    private void Update()
    {
        //Controlling the gameoverlosesound after the player death
        if (playerHealth == 0 && !playOnce)
        {
            Invoke("GameOverLoseSoundEffect", 3f);
            playOnce = true;
        }
    }

    //Method to call the gameover lose sound
    private void GameOverLoseSoundEffect()
    {
        GameAudioController.instance.GameOverLoseSound();
    }

    //Setting up the player's health
    public void PlayerHealthController()
    {
        if(playerHealth > 0 && !isRecovery)
        {
            GameAudioController.instance.PlayerHitSound();
            playerHealth--;
            isRecovery = true;
            StartCoroutine("RecoveryTimeCounting");
        }
    }

    public int PlayerHealthValue()
    {
        return playerHealth;
    }

    //Creating the recovery time effect automatically
    //Creating the recorey time system
    IEnumerator RecoveryTimeCounting()
    {
        float elapsedTime = 0f;

        while (elapsedTime < playerHealthRecoveryTime)
        {
            foreach (GameObject playerMesh in playerMeshRenderer)
            {
                playerMesh.SetActive(!playerMesh.activeSelf);
            }

            yield return new WaitForSeconds(blinkInterval);

            elapsedTime += blinkInterval;
        }

        foreach (GameObject playerMesh in playerMeshRenderer)
        {
            playerMesh.SetActive(true);
        }

        isRecovery = false;
    }
}
