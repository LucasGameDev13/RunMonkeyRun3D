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


    public int _PlayerHealth
    {
        set { playerHealth = value; }
    }

    public bool IsRecovery
    {
        get { return isRecovery; }
    }

    //Setting up the player's health
    public void PlayerHealthController()
    {
        if(playerHealth > 0 && !isRecovery)
        {
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
