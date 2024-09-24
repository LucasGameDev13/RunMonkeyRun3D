using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CallingCoroutine", 3f);
    }

    private void CallingCoroutine()
    {
        StartCoroutine("LoadingGame");
    }

    IEnumerator LoadingGame()
    {
        AsyncOperation asyLoad = SceneManager.LoadSceneAsync("GamePlay");

        while(!asyLoad.isDone)
        {
            yield return null;
        }
    }
}
