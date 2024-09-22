using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [Header("Letters Settings")]
    private GameScoreController gameScoreController;
    private PlayerHealth playerHealth;
    [SerializeField] private List<GameObject> lettersText = new List<GameObject>();
    [SerializeField] private Color letterAlpha;

    [Header("Score Settings")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Player Health Settings")]
    [SerializeField] private TextMeshProUGUI playerHealthText;


    private void Awake()
    {
        gameScoreController = FindObjectOfType<GameScoreController>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetScoreText();
        SetPlayerHealth();
    }

    // Update is called once per frame
    void Update()
    {
        ColletingLetters();
        SetScoreText();
        SetPlayerHealth();
    }

    //Cheking out the letter was collected and changing the UI letter
    private void ColletingLetters()
    {
        foreach (GameObject collectedLetter in gameScoreController.GetGameScoreLetters())
        {
            int collectibleObjIndex = collectedLetter.GetComponent<CollectiblesObjects>().GetObjectIndex();

            if (collectibleObjIndex >= 0 && collectibleObjIndex < lettersText.Count)
            {
                lettersText[collectibleObjIndex].GetComponent<TextMeshProUGUI>().color = letterAlpha;
            }
        }
    }

    private void SetScoreText()
    {
        scoreText.text = gameScoreController.GetGameScore().ToString();
    }

    private void SetPlayerHealth()
    {
        playerHealthText.text = playerHealth.PlayerHealthValue().ToString();
    }
}
