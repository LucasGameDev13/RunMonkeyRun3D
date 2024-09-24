using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreController : MonoBehaviour
{
    [Header("Game Score Settings")]
    [SerializeField] private int gameScore;

    [Header("Letters Holder")]
    [SerializeField] private List<GameObject> gameScoreLetters = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CleanGameScoreLetters();
    }

    //Filling up the variable with the letters 
    public void AddGameScoreLetters(GameObject _letter)
    {
        gameScoreLetters.Add(_letter);
    }

    //Cleaning the variable as soon as the game get started
    private void CleanGameScoreLetters()
    {
        foreach (GameObject letters in gameScoreLetters)
        {
            gameScoreLetters.Remove(letters);
        }
    }

    //Getting the variable values (letters)
    public List<GameObject> GetGameScoreLetters()
    {
        return gameScoreLetters;
    }

    //Game score
    public void GameScore(int _score)
    {
        gameScore += _score;
    }

    //Getting the game score
    public int GetGameScore()
    {
        return gameScore;
    }
}
