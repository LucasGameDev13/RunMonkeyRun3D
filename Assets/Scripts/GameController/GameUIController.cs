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
    [SerializeField] private List<GameObject> lettersFinalText = new List<GameObject>();
    [SerializeField] private Color letterAlpha;

    [Header("Score Settings")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    [Header("Player Health Settings")]
    [SerializeField] private TextMeshProUGUI playerHealthText;

    [Header("Game Play UI")]
    [SerializeField] private GameObject gameplayUI;

    [Header("Game Overs Settings")]
    [SerializeField] private GameObject[] gameOvers;


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

            bool checkingCondition = collectibleObjIndex < lettersText.Count;
            bool checkingCondition2 = collectibleObjIndex < lettersFinalText.Count;

            if (collectibleObjIndex >= 0 && checkingCondition || checkingCondition2)
            {
                lettersText[collectibleObjIndex].GetComponent<TextMeshProUGUI>().color = letterAlpha;
                lettersFinalText[collectibleObjIndex].GetComponent<TextMeshProUGUI>().color = letterAlpha;
            }
        }
    }

    //Drawing the score on the UI
    private void SetScoreText()
    {
        scoreText.text = gameScoreController.GetGameScore().ToString();
        finalScoreText.text = gameScoreController.GetGameScore().ToString();
    }

    //Drawing the health on the UI
    private void SetPlayerHealth()
    {
        playerHealthText.text = playerHealth.PlayerHealthValue().ToString();
    }

    //Controlling the gameovers windowns
    public void SetActiveGameOvers(bool _lose, bool _win)
    {
        gameOvers[0].SetActive(_lose);
        gameOvers[1].SetActive(_win);
        gameplayUI.SetActive(false);
    }
}
