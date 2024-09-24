using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public void LoadScene(string _scene)
    {
        GameAudioController.instance.ButtonsSounds();
        StartCoroutine(LoadSceneButtons(_scene));
    }

    public void GameExit()
    {
        GameAudioController.instance.ButtonsSounds();
        StartCoroutine("ExitButton");
    }

    IEnumerator LoadSceneButtons(string _scene)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(_scene);
    }

    IEnumerator ExitButton()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Exit Game");
        Application.Quit();
    }

}
