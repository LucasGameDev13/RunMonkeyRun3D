using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    //Method to load the scene
    public void LoadScene(string _scene)
    {
        GameAudioController.instance.ButtonsSounds();
        StartCoroutine(LoadSceneButtons(_scene));
    }

    //Method to exit the game
    public void GameExit()
    {
        GameAudioController.instance.ButtonsSounds();
        StartCoroutine("ExitButton");
    }

    //Delay to load the scene
    IEnumerator LoadSceneButtons(string _scene)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(_scene);
    }

    //Delay to exit the game
    IEnumerator ExitButton()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Exit Game");
        Application.Quit();
    }

}
